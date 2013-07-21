using myStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStore.Domain.Concrete
{
    public class MyStoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
