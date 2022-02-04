using DataAccessLayer;
using FrameworkPart.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkPart.UnitOfworks
{
    public interface IShoppingUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepositroy { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
    }
}
