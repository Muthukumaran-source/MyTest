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
    public class TransOrderControllerUnitTest
    {
        [TestMethod]
        public async Task GetTransOrdersTest()
        {
            var controller = new TransOrderController();
            var outputResult = await controller.GetOrders();
            var Result = outputResult.Result;
            var data = Result.TryGetPropertyValue<List<TransOrder>>("Value");
            Type type = typeof(List<TransOrder>);
            Assert.IsInstanceOfType(data, type);
        }

        [TestMethod]
        public async Task GetTransOrderByIdTest()
        {
            int id = 1;
            var controller = new TransOrderController();
            var outputResult = await controller.GetOrder(id);
            var Result = outputResult.Result;
            var data = Result.TryGetPropertyValue<TransOrder>("Value");
            Type type = typeof(TransOrder);
            Assert.IsInstanceOfType(data, type);
        }

        [TestMethod]
        public async Task PutMasterProductTest()
        {
            var controller = new TransOrderController();
            int pkid = 1;
            var transOrder = new TransOrder()
            {
                ProductId = 1,
                OrderedQuantity = 1,
                PaymentMode = "COD",
                DeliveryAddress = "Delhi",
                OrderedBy = 1,
                OrderedDate = DateTime.Now
            };

            var outputResult = await controller.PutTransOrder(pkid, transOrder);
            var result = outputResult.Result;
            var data = result.TryGetPropertyValue<bool>("isUpdate");
            Type type = typeof(bool);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public async Task PostTransOrderTest()
        {
            var controller = new TransOrderController();
            var transOrder = new TransOrder()
            {
                ProductId = 1,
                OrderedQuantity = 1,
                PaymentMode = "COD",
                DeliveryAddress = "Chennai-600077",
                OrderedBy = 1,
                OrderedDate = DateTime.Now
            };

            var outputResult = await controller.PostTransOrder(transOrder);
            var result = outputResult.Result;
            var data = result.TryGetPropertyValue<bool>("isInsert");
            Type type = typeof(bool);
            Assert.IsNotNull(data);
        }
    }
}
