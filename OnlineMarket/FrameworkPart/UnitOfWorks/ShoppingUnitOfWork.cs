using DataAccessLayer;
using FrameworkPart.Contexts;
using FrameworkPart.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkPart.UnitOfworks
{
    public class ShoppingUnitOfWork : UnitOfWork, IShoppingUnitOfWork
    {
        public IProductRepository ProductRepositroy { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public ShoppingUnitOfWork(ShopingContext context, 
            IProductRepository productRepositroy,
            ICategoryRepository categoryRepository
            )
            : base(context)
        {
            ProductRepositroy = productRepositroy;
            CategoryRepository = categoryRepository;
        }
    }
}
