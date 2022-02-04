using DataAccessLayer;
using FrameworkPart.Contexts;
using FrameworkPart.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkPart.Repositories
{
    public class CategoryRepository : Repository<Category, int, ShopingContext>, ICategoryRepository
    {
        public CategoryRepository(ShopingContext dbContext)
            : base(dbContext)
        {

        }
    }
}
