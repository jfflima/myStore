using myStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myStore.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Detail(Guid productId)
        {
            return View(repository.Products.First(p => p.Id == productId));
        }
    }
}
