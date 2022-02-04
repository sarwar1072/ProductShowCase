using Autofac;
using FrameworkPart.Contexts;
using FrameworkPart.Repositories;
using FrameworkPart.Services;
using FrameworkPart.UnitOfworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworkPart
{
    public class FoundationModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FoundationModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShopingContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ShoppingUnitOfWork>().As<IShoppingUnitOfWork>()
                .InstancePerLifetimeScope();
            //builder.RegisterType<PurchaseService>().As<IPurchaseService>()
            //    .InstancePerLifetimeScope();
            builder.RegisterType<ShopService>().As<IShopService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
