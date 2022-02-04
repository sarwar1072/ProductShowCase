using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OnlineMarket.web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineMarket.web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WebModule(string connectionString, string migrationAssemblyName
            , IWebHostEnvironment webHostEnvironment
         )
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;   
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductUpdateModel>().AsSelf();
            builder.RegisterType<ProductsModel>().AsSelf();

            base.Load(builder);
        }
    }
}
