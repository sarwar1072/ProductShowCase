using FrameworkPart.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkPart.Services
{
    public interface IShopService
    {
        //void CreateCategory(string name);
        //void CreateCategory(CategoryInfo category);
        (int total, int totalDisplay, IList<Product> records) GetProductList(int pageIndex,
            int pageSize, string searchText, string orderBy);
        void CreateProduct(Product product);
        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
