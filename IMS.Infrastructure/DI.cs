using IMS.Core.Caching;
using IMS.Core.CoreInterface;
using IMS.Infrastructure.Core;
using IMS.Infrastructure.Data;
using IMS.Infrastructure.Repositories.BrandRepository;
using IMS.Infrastructure.Repositories.CustomerRepository;
using IMS.Infrastructure.Repositories.ProductCategoryRepository;
using IMS.Infrastructure.Repositories.ProductRepository;
using IMS.Infrastructure.Repositories.PurchageOrderItemRepository;
using IMS.Infrastructure.Repositories.PurchageOrderRepository;
using IMS.Infrastructure.Repositories.SellerOrderItemRepository;
using IMS.Infrastructure.Repositories.SellerOrderRepository;
using IMS.Infrastructure.Repositories.SupplierRepository;
using IMS.Infrastructure.Repositories.WarehouseReceivedProductRepository;
using IMS.Infrastructure.Repositories.WareHouseRepository;
using IMS.Infrastructure.Repositories.WareHouseStockRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static IMS.Core.CoreInterface.IReadRepository;

namespace IMS.Infrastructure
{
    public static class DI
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationWriteDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("WriteConnection"),
                    npgsqlOptions => npgsqlOptions.MigrationsAssembly(typeof(ApplicationWriteDbContext).Assembly.FullName)));

            services.AddDbContext<ApplicationReadDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ReadConnection"))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            var readConnectionString = configuration.GetConnectionString("ReadConnection");
            var writeConnectionString = configuration.GetConnectionString("WriteConnection");
            services.AddSingleton<IReadDbConnectionFactory>(
                sp => new DbConnectionFactory(readConnectionString));
            services.AddSingleton<IWriteDbConnectionFactory>(
                sp => new DbConnectionFactory(writeConnectionString)); 
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "IMS_";
            });
            services.AddScoped<IUnitOfWorks, UnitOfWorks>();
            services.AddScoped<IProductCategoryReadRepository, ProductCategoryReadRepository>();
            services.AddScoped<IProductCategoryWriteRepository, ProductCategoryWriteRepository>();
            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<ISupplierWriteRepository, SupplierWriteRepository>();
            services.AddScoped<ISupplierReadRepository, SupplierReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();
            services.AddScoped<IWareHouseReadRepository, WareHouseReadRepository>();
            services.AddScoped<IWareHouseWriteRepository, WareHouseWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IPurchageOrderReadRepository, PurchageOrderReadRepository>();
            services.AddScoped<IPurchageOrderWriteRepository, PurchageOrderWriteRepository>();
            services.AddScoped<IPurchageOrderItemReadRepository, PurchageOrderItemReadRepository>();
            services.AddScoped<IPurchageOrderItemWriteRepository, PurchageOrderItemWriteRepository>();
            services.AddScoped<IWareHouseStockReadRepository, WareHouseStockReadRepository>();
            services.AddScoped<IWareHouseStockWriteRepository, WareHouseStockWriteRepository>();
            services.AddScoped<ISellerOrderReadRepository,SellerOrderReadRepository>();
            services.AddScoped<ISellerOrderWriteRepository, SellerOrderWriteRepository>();
            services.AddScoped<ISellerOrderItemReadRepository, SellerOrderItemReadRepository>();
            services.AddScoped<ISellerOrderItemWriteRepository,  SellerOrderItemWriteRepository>();
            services.AddScoped<IWarehouseReceivedProductReadRepository, WarehouseReceivedProductReadRepository>();
            services.AddScoped<IWarehouseReceivedProductWriteRepository, WarehouseReceivedProductWriteRepository>();
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IRedisCacheService, RedisCacheService>();
            return services;
        }

    }
}
