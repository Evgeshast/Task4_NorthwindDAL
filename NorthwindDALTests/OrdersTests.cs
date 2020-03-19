using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthwindDAL.Entities;
using NorthwindDAL.Repositories;

namespace NorthwindDALTests
{
    [TestClass]
    public class OrdersTests
    {
        [TestMethod]
        public void GetAllOrdersTest()
        {
            //Arrange
            Orders orders = new Orders();

            //Act
            IEnumerable<Order> ordersList = orders.GetAll();

            //Assert
            Assert.AreNotEqual(0, ordersList.Count());
        }

        [TestMethod]
        public void GetOrder()
        {
            //Arrange
            Orders orders = new Orders();

            //Act
            Order order = orders.Get(10257);

            //Assert
            Assert.IsNotNull(order);
        }
        
        [TestMethod]
        public void GetOrderInformation()
        {
            //Arrange
            Orders orders = new Orders();

            //Act
            var orderInformation = orders.GetOrderInformation(10257);

            //Assert
            Assert.AreEqual("HILAA", orderInformation.Order.CustomerID);
            Assert.AreEqual(3, orderInformation.Products.Count);
        }
        
        [TestMethod]
        public void CreateNewOrder()
        {
            //Arrange
            Orders orders = new Orders();
            var ordersCount = orders.GetAll().Count();
            DateTime deliveryTime = DateTime.Now.AddDays(5);
            decimal freight = 26.75m;
            Order order = new Order("BONAP", 6, deliveryTime, 3, freight,
                "Ernst Handel", "Kirchgasse 6", "Graz", null, "8010", "Austria");

            //Act
            orders.Create(order);

            //Assert
            Assert.AreEqual(ordersCount + 1, orders.GetAll().Count());
        }

        [TestMethod]
        public void SetNewOrderInProgress()
        {
            //Arrange
            Orders orders = new Orders();
            DateTime deliveryTime = DateTime.Now.AddDays(5);
            decimal freight = 26.75m;
            Order order = new Order("BONAP", 6, deliveryTime, 3, freight,
                "Ernst Handel", "Kirchgasse 6", "Graz", null, "8010", "Austria");

            //Act
            int orderID = orders.Create(order).OrderID;
            orders.SetInProgress(order);
            order = orders.Get(orderID);

            //Assert
            Assert.IsNotNull(order.OrderDate);
        }
        
        [TestMethod]
        public void UpdateNewOrder()
        {
            //Arrange 
            string newPostalCode = "1488";

            //Act
            Orders orders = new Orders();
            DateTime deliveryTime = DateTime.Now.AddDays(5);
            decimal freight = 26.75m;
            Order order = new Order("BONAP", 6, deliveryTime, 3, freight,
                "Ernst Handel", "Kirchgasse 6", "Graz", null, "8010", "Austria");
            int orderID = orders.Create(order).OrderID;
            order.ShipPostalCode = newPostalCode;
            orders.Update(order);
            order = orders.Get(orderID);

            //Assert
            Assert.AreEqual(newPostalCode, order.ShipPostalCode);
        }
    }
}
