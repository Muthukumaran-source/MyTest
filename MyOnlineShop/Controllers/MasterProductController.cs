using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOS.BusinessLayer;
using MOS.Domain.SqlModels;

namespace MyOnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterProductController : ControllerBase
    {
        // GET: api/MasterProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterProduct>>> GetMasterProducts()
        {
            IBusiness<MasterProduct> productBusiness = BusinessFactory<MasterProduct>.Create();
            var result = await productBusiness.SelectAll();
            return Ok(result);
        }

        // GET: api/MasterProduct/5
        [HttpGet("{productId}")]
        public async Task<ActionResult<MasterProduct>> GetMasterProduct(long productId)
        {
            IBusiness<MasterProduct> productBusiness = BusinessFactory<MasterProduct>.Create();
            var result = await productBusiness.Select(productId);
            return Ok(result);
        }

        // PUT: api/MasterProduct/5
        [HttpPut("{productId}")]
        public async Task<ActionResult<dynamic>> PutMasterProduct(long productId, MasterProduct masterProduct)
        {
            if (productId != masterProduct.ProductId)
            {
                return BadRequest();
            }

            IBusiness<MasterProduct> productBusiness = BusinessFactory<MasterProduct>.Create();
            bool isUpdate = false, isProductNameExisting = false;
            var productModel = await productBusiness.SingleOrDefaultAsync(x => (bool)x.Status && x.ProductId == productId);
            if (productModel != null)
            {
                isProductNameExisting = await productBusiness.Any(x => x.ProductId != masterProduct.ProductId && (bool)x.Status && x.ProductName.ToLower() == masterProduct.ProductName.ToLower());
                if (!isProductNameExisting)
                {
                    productModel.ProductName = masterProduct.ProductName;
                    productModel.Quantity = masterProduct.Quantity;
                    productModel.Price = masterProduct.Price;
                    productModel.Availablity = masterProduct.Quantity <= 0 ? false : true;
                    productModel.Status = masterProduct.Status;
                    productModel.EntryBy = masterProduct.EntryBy;
                    productModel.EntryDate = DateTime.Now;
                    isUpdate = await productBusiness.Update(productModel, productId);
                }
            }

            dynamic saveResult = new { isUpdate, isProductNameExisting };
            return Ok(saveResult);
        }

        // POST: api/MasterProduct
        [HttpPost]
        public async Task<ActionResult<dynamic>> PostMasterProduct(MasterProduct masterProduct)
        {
            IBusiness<MasterProduct> productBusiness = BusinessFactory<MasterProduct>.Create();
            bool isInsert = false, isProductNameExisting = false;
            isProductNameExisting = await productBusiness.Any(x => (bool)x.Status && x.ProductName.ToLower() == masterProduct.ProductName.ToLower());
            if (!isProductNameExisting)
            {
                isInsert = await productBusiness.Insert(masterProduct);
            }

            dynamic result = new { isInsert, isProductNameExisting };
            return Ok(result);
        }


        // DELETE: api/MasterProduct/5
        [HttpDelete("{productId}")]
        public async Task<ActionResult<bool>> DeleteMasterProduct(int productId)
        {
            IBusiness<MasterProduct> productBusiness = BusinessFactory<MasterProduct>.Create();
            var result = await productBusiness.Delete(productId);
            return Ok(result);
        }
    }
}
