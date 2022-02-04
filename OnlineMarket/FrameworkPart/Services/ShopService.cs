using FrameworkPart.Entities;
using FrameworkPart.UnitOfworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkPart.Services
{
    public class ShopService : IShopService
    {
        private readonly IShoppingUnitOfWork _shopingUnitOfWork;
        public ShopService(IShoppingUnitOfWork shopingUnitOfWork)
        {
            _shopingUnitOfWork = shopingUnitOfWork;
        }
        public void CreateProduct(Product product)
        {
            _shopingUnitOfWork.ProductRepositroy.Add(product);
            _shopingUnitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            var product = _shopingUnitOfWork.ProductRepositroy.Get(x => x.Id == id, "Images").FirstOrDefault();
            _shopingUnitOfWork.ProductRepositroy.Remove(product);
            _shopingUnitOfWork.Save();
        }

        public Product GetProduct(int id)
        {
            var productEntity = _shopingUnitOfWork.ProductRepositroy.Get(x => x.Id == id, orderBy: null,
               "Images", true).FirstOrDefault();

            return productEntity;
        }

        public (int total, int totalDisplay, IList<Product> records) GetProductList(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            (IList<Product> data, int total, int totalDisplay) result = (null, 0, 0);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                 result = _shopingUnitOfWork.ProductRepositroy.GetDynamic(null,
                orderBy, "Images", pageIndex, pageSize, true);
            }
            else
            {
                result = _shopingUnitOfWork.ProductRepositroy.GetDynamic(x => x.Name == searchText,
               orderBy, "Images", pageIndex, pageSize, true);
            }
            
            return (result.total,result.totalDisplay,result.data);
        }

        public void UpdateProduct(Product product)
        {
            var productList = _shopingUnitOfWork.ProductRepositroy.Get(x => x.Id == product.Id, orderBy: null, "Images", true).FirstOrDefault();
            productList.Name = product.Name;
            productList.Price = product.Price;
            productList.Images.Clear();
            productList.Images = (from x in product.Images
                                  select new ProductImage
                                  {
                                      AlternativeText=x.AlternativeText,
                                      Url=x.Url
                                  }
                                ).ToList();

            _shopingUnitOfWork.Save();
        }
    }
}
