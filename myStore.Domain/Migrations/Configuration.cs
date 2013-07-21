namespace myStore.Domain.Migrations
{
    using myStore.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<myStore.Domain.Concrete.MyStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(myStore.Domain.Concrete.MyStoreDbContext context)
        {
            for (var index = 0; index < 11; index++)
            {
                context.Products.Add(new Product { Id = Guid.NewGuid(), Name = string.Format("Product {0}", index), Description = string.Format("This is a very long product description for {0}.", index) });
            }
        }
    }
}
