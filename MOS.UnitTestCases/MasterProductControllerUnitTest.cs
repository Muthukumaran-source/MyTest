using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOS.Domain.SqlModels;
using MyOnlineShop.Controllers;
using Namotion.Reflection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MOS.UnitTestCases
{
    [TestClass]
    public class MasterProductControllerUnitTest
    {
        [TestMethod]
        public async Task GetMasterProductsTest()
        {
            var controller = new MasterProductController();
            var outputResult = await controller.GetMasterProducts();
            var Result = outputResult.Result;
            var data = Result.TryGetPropertyValue<List<MasterProduct>>("Value");
            Type type = typeof(List<MasterProduct>);
            Assert.IsInstanceOfType(data, type);
        }

        [TestMethod]
        public async Task GetMasterProductByIdTest()
        {
            int id = 1;
            var controller = new MasterProductController();
            var outputResult = await controller.GetMasterProduct(id);
            var Result = outputResult.Result;
            var data = Result.TryGetPropertyValue<MasterProduct>("Value");
            Type type = typeof(MasterProduct);
            Assert.IsInstanceOfType(data, type);
        }


        [TestMethod]
        public async Task PutMasterProductTest()
        {
            var controller = new MasterProductController();
            int pkid = 1;
            var masterProduct = new MasterProduct()
            {
                ProductId = 1,
                ProductName = "IPhone series",
                Quantity = 1,
                Price = 80000,
                Availablity = true,
                Status = true,
                EntryBy = 1,
                EntryDate = DateTime.Now
            };

            var outputResult = await controller.PutMasterProduct(pkid, masterProduct);
            var result = outputResult.Result;
            var data = result.TryGetPropertyValue<bool>("isUpdate");
            Type type = typeof(bool);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public async Task PostMasterProductTest()
        {
            var controller = new MasterProductController();
            var masterProduct = new MasterProduct()
            {
                ProductName = "Moto X4",
                Quantity = 20,
                Price = 14000,
                Availablity = true,
                Status = true,
                EntryBy = 1,
                EntryDate = DateTime.Now
            };

            var outputResult = await controller.PostMasterProduct(masterProduct);
            var result = outputResult.Result;
            var data = result.TryGetPropertyValue<bool>("isInsert");
            Type type = typeof(bool);
            Assert.IsNotNull(data);
        }
    }
}
