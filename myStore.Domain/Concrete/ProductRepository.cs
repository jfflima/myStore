using myStore.Domain.Abstract;
using myStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStore.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        MyStoreDbContext context = new MyStoreDbContext();

        public IQueryable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }
    }
}
