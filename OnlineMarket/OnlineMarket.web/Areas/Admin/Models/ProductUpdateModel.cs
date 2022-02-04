using Autofac;
using FrameworkPart.Entities;
using FrameworkPart.Services;
using Microsoft.AspNetCore.Http;
using OnlineMarket.web.Models;
using System.Collections.Generic;
using System.Linq;
namespace OnlineMarket.web.Areas.Admin.Models
{
    public class ProductUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public IFormFile ImageFile { get; set; }

        private readonly IShopService _shopService;

        public ProductUpdateModel ()
        {
            _shopService = Startup.AutofacContainer.Resolve<IShopService>();
        }

        internal void UpdateProduct()
        {
            var product = new Product
            {
                Id = Id,
                Name = Name,
                Price = Price

            };
            if (ImageFile != null)
            {
                var imageInfo = StoreFile(ImageFile);
                product.Images = new List<ProductImage>();
                product.Images.Add(new ProductImage()
                {
                    Url = imageInfo.filePath,
                    AlternativeText = $"{product.Name} Image"
                });
            }
            _shopService.UpdateProduct(product);
        }

        internal void CreateProduct()
        {
            var product = new Product
            {
                Id = Id,
                Name = Name,
                Price = Price
            };
            if (ImageFile != null)
            {
                var imageInfo = StoreFile(ImageFile);
                product.Images = new List<ProductImage>();
                product.Images.Add(new ProductImage()
                {
                    Url = imageInfo.filePath,
                    AlternativeText = $"{product.Name} Image"
                });
            }
           // var product = ConvertToProduct();
            _shopService.CreateProduct(product);
        }

        internal void LoadData(int id)
        {
            var product = _shopService.GetProduct(id);
            if (product != null)
            {
                Name = product.Name;
                Price = product.Price;
                Id = product.Id;
                ImagePath = product.Images.ToString();
                    //FormatImageUrl(product.Images?.FirstOrDefault()?.Url);
            }
        }

        //private Product ConvertToProduct()
        //{
        //    var product = new Product
        //    {
        //        Id = Id,
        //        Name = Name,
        //        Price = Price
        //    };

        //    if (ImageFile != null)
        //    {
        //        var imageInfo = StoreFile(ImageFile);
        //        product.Images = new List<Image>();
        //        product.Images.Add(new Image()
        //        {
        //            Location = imageInfo.filePath,
        //            AlternativeText = $"{product.Name} Image"
        //        });
        //    }

        //    return product;
        //}

        internal void DeleteProduct()
        {
            _shopService.DeleteProduct(Id);
        }
    }
}
