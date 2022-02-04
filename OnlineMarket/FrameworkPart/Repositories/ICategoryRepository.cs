using DataAccessLayer;
using FrameworkPart.Contexts;
using FrameworkPart.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkPart.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int, ShopingContext>
    {
    }
}
