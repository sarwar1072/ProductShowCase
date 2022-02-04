using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FrameworkPart.Services;
using OnlineMarket.web.Models;

namespace OnlineMarket.web.Areas.Admin.Models
{
    public class ProductsModel : BaseModel
    {
        private readonly IShopService _shopService;
        public ProductsModel(IShopService shopService) { _shopService = shopService; }

        public ProductsModel()
        {
            _shopService = Startup.AutofacContainer.Resolve<IShopService>();
        }

        internal object GetProducts(DataTablesAjaxRequestModel tableModel)
        {
            var data = _shopService.GetProductList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "Price" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                FormatImageUrl(record.Images?.FirstOrDefault()?.Url),
                                record.Price.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}
