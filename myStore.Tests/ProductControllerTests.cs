using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using myStore.Domain.Abstract;
using myStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using myStore.Controllers;
using System.Web.Mvc;

namespace myStore.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void should_be_able_to_see_list_of_all_products()
        {
            var product = new Product { Id = new Guid(), Name = "Product 1", Description = "Product 1 Description" };
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(m => m.Products).Returns(new List<Product>{ product }.AsQueryable());

            var result = (IQueryable<Product>)((ViewResult)new ProductController(mockRepository.Object).Index()).Model;

            Assert.AreEqual(1, result.Count(), "Expected product count 1");
            Assert.AreEqual(product.Id, result.First().Id, "Expected same product id");
        }

        [TestMethod]
        public void should_be_able_to_see_product_details()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void should_be_able_to_add_a_valid_product()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void should_not_be_able_to_add_a_invalid_product()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void should_be_able_to_edit_a_product()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void should_be_able_to_delete_a_product()
        {
            throw new NotImplementedException();
        }
    }
}
