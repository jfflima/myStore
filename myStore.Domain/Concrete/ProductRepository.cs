using myStore.Domain.Abstract;
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

        public IQueryable<Entities.Product> Products
        {
            get
            {
                return context.Products;
            }
        }
    }
}
