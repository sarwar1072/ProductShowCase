using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer;
using FrameworkPart.Contexts;
using FrameworkPart.Entities;

namespace FrameworkPart.Repositories
{
    public class ProductRepository : Repository<Product, int, ShopingContext>, IProductRepository
    {
        public ProductRepository(ShopingContext dbContext)
            : base(dbContext)
        {

        }

        public IList<Product> GetLatestProducts()
        {
            throw new NotImplementedException();
        }
    }
}
