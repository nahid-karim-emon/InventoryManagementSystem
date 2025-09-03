using IMS.Service.Services.AdminService;
using IMS.Service.Services.BrandService;
using IMS.Service.Services.CustomerService;
using IMS.Service.Services.ProductCategoryService;
using IMS.Service.Services.ProductOrderItemService;
using IMS.Service.Services.ProductService;
using IMS.Service.Services.PurchageOrderService;
using IMS.Service.Services.SellerOrderItemService;
using IMS.Service.Services.SellerOrderService;
using IMS.Service.Services.StockManagerService;
using IMS.Service.Services.StockReceivedProductService;
using IMS.Service.Services.SupplierService;
using IMS.Service.Services.WareHouseService;
using IMS.Service.Services.WareHouseStockService;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.Service
{
    public static class DI
    {
        public static IServiceCollection AddServiceDI(this IServiceCollection services)
        {
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IWareHouseService, WareHouseService>();  
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchageOrderService, PurchageOrderService>();
            services.AddScoped<IProductOrderItemService, ProductOrderItemService>();
            services.AddScoped<IWareHouseStockService, WareHouseStockService>();
            services.AddScoped<ISellerOrderService, SellerOrderService>();
            services.AddScoped<ISellerOrderItemService, SellerOrderItemService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IStockManagerService, StockManagerService>();
            services.AddScoped<IStockReceivedProductService, StockReceivedProductService>();
            return services;
        }
    }
}
