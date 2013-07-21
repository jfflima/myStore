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
        List<Product> productList = new List<Product>()
        {
            new Product { Id = new Guid(), Name = "Product 1", Description = "Product 1 Description" },
            new Product { Id = new Guid(), Name = "Product 3", Description = "Product 3 Description" },
            new Product { Id = new Guid(), Name = "Product 2", Description = "Product 2 Description" },
            new Product { Id = new Guid(), Name = "Product 5", Description = "Product 5 Description" },
            new Product { Id = new Guid(), Name = "Product 4", Description = "Product 4 Description" },
            new Product { Id = new Guid(), Name = "Product 6", Description = "Product 6 Description" },
        };

        Mock<IProductRepository> GetProductMockRepository()
        {
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(m => m.Products).Returns(productList.AsQueryable());
            return mockRepository;
        }

        [TestMethod]
        public void should_be_able_to_see_list_of_all_products()
        {
            var mockRepository = GetProductMockRepository();

            var result = (IQueryable<Product>)((ViewResult)new ProductController(mockRepository.Object).Index()).Model;

            Assert.AreEqual(productList.Count, result.Count());
            Assert.AreEqual(productList[0].Id, result.First().Id);
            Assert.AreEqual(productList[5].Id, result.Last().Id);
        }
                

        [TestMethod]
        public void should_be_able_to_see_product_details()
        {
            var mockRepository = GetProductMockRepository();

            var result = (Product)((ViewResult)new ProductController(mockRepository.Object).Detail(productList[0].Id)).Model;

            Assert.AreEqual(productList[0], result);
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
