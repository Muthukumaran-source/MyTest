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
    public class TransOrderController : ControllerBase
    {
        // GET: api/TransOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransOrder>>> GetOrders()
        {
            IBusiness<TransOrder> orderBusiness = BusinessFactory<TransOrder>.Create();
            var result = await orderBusiness.SelectAll();
            return Ok(result);
        }

        // GET: api/TransOrder/5
        [HttpGet("{orderId}")]
        public async Task<ActionResult<TransOrder>> GetOrder(long orderId)
        {
            IBusiness<TransOrder> orderBusiness = BusinessFactory<TransOrder>.Create();
            var result = await orderBusiness.Select(orderId);
            return Ok(result);
        }

        // PUT: api/TransOrder/5
        [HttpPut("{orderId}")]
        public async Task<ActionResult<dynamic>> PutTransOrder(long orderId, TransOrder transOrder)
        {
            if (orderId != transOrder.OrderId)
            {
                return BadRequest();
            }

            IBusiness<TransOrder> orderBusiness = BusinessFactory<TransOrder>.Create();
            bool isUpdate = false, isProductUpdate = false;
            var orderModel = await orderBusiness.SingleOrDefaultAsync(x => x.OrderId == orderId);

            IBusiness<MasterProduct> productBusiness = BusinessFactory<MasterProduct>.Create();
            var productModel = await productBusiness.SingleOrDefaultAsync(x => (bool)x.Status && x.ProductId == transOrder.ProductId);

            if (orderModel != null && productModel != null && productModel.Availablity && productModel.Quantity >= orderModel.OrderedQuantity )
            {
                orderModel.OrderedQuantity = transOrder.OrderedQuantity;
                orderModel.TotalAmount = transOrder.OrderedQuantity > 0 ? transOrder.OrderedQuantity * productModel.Price : 0;
                orderModel.PaymentMode = transOrder.PaymentMode;
                orderModel.DeliveryAddress = transOrder.DeliveryAddress;
                orderModel.IsCancelled = transOrder.IsCancelled;
                orderModel.CancelledDate = DateTime.Now;
                orderModel.IsShipped = transOrder.IsShipped;
                orderModel.ShippedDate = DateTime.Now;
                orderModel.IsDelivered = transOrder.IsDelivered;
                orderModel.DeliveredDate = DateTime.Now;
                orderModel.IsReturned = transOrder.IsReturned;
                orderModel.ReturnedDate = DateTime.Now;
                orderModel.OrderedBy = transOrder.OrderedBy;
                orderModel.OrderedDate = DateTime.Now;
                isUpdate = await orderBusiness.Update(orderModel, orderId);                
            }
            if (orderModel != null && productModel != null && ((orderModel.IsCancelled != null && (bool)orderModel.IsCancelled) ||
                (orderModel.IsReturned != null && (bool)orderModel.IsReturned)))
            {

                productModel.Quantity += orderModel.OrderedQuantity;
                productModel.Availablity = productModel.Quantity > 0;
                isProductUpdate = await productBusiness.Update(productModel, transOrder.ProductId);
            }

            dynamic saveResult = new { isUpdate, isProductUpdate };
            return Ok(saveResult);
        }

        // POST: api/TransOrder
        [HttpPost]
        public async Task<ActionResult<dynamic>> PostTransOrder(TransOrder transOrder)
        {
            IBusiness<TransOrder> orderBusiness = BusinessFactory<TransOrder>.Create();
            IBusiness<MasterProduct> productBusiness = BusinessFactory<MasterProduct>.Create();
            bool isOrderInsert = false, isProductUpdate = false;
            var productModel = await productBusiness.SingleOrDefaultAsync(x => (bool)x.Status && x.ProductId == transOrder.ProductId && (bool)x.Availablity);
            if(productModel != null && productModel.Quantity >= transOrder.OrderedQuantity)
            {
                transOrder.ProductPrice = productModel.Price;
                transOrder.TotalAmount = productModel.Price * transOrder.OrderedQuantity;
                isOrderInsert = await orderBusiness.Insert(transOrder);
                productModel.Quantity -= transOrder.OrderedQuantity;
                productModel.Availablity = productModel.Quantity > 0;
                isProductUpdate = await productBusiness.Update(productModel, transOrder.ProductId);
            }

            dynamic result = new { isOrderInsert, isProductUpdate };
            return Ok(result);
        }


        // DELETE: api/TransOrder/5
        [HttpDelete("{productId}")]
        public async Task<ActionResult<bool>> DeleteTransOrder(int productId)
        {
            IBusiness<TransOrder> orderBusiness = BusinessFactory<TransOrder>.Create();
            var result = await orderBusiness.Delete(productId);
            return Ok(result);
        }

    }
}
