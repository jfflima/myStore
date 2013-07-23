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

        Mock<IProductRepository> GetProductMockRepository(List<Product> products = null)
        {
            var mockRepository = new Mock<IProductRepository>();
            var list = products ?? productList;
            mockRepository.Setup(m => m.Products).Returns(list.AsQueryable());
            mockRepository.Setup(m => m.Add(It.IsAny<Product>())).Callback((Product p) => { list.Add(p); });
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
            var products = new List<Product>();
            var mockRepository = GetProductMockRepository(products);
            var newProduct = new Product { Id = Guid.NewGuid(), Name = "New Product", Description = "New Product Description"};
            
            var result = (RedirectToRouteResult)new ProductController(mockRepository.Object).Add(newProduct);

            Assert.AreEqual(1, products.Count);
            Assert.AreEqual(newProduct.Id, products[0].Id);
        }

        [TestMethod]
        public void should_not_be_able_to_add_a_invalid_product()
        {
            var products = new List<Product>();
            var mockRepository = GetProductMockRepository(products);
            var newProduct = new Product { Id = Guid.NewGuid(), Name = "", Description = "" };
            var controller = new ProductController(mockRepository.Object);
            controller.ModelState.AddModelError("Error", new ArgumentException("Error"));

            var result = (ViewResult)controller.Add(newProduct);

            Assert.AreEqual(0, products.Count);
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
