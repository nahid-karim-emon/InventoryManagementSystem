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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Core
{
    public interface IUnitOfWorks : IDisposable
    {
        IProductCategoryReadRepository ProductCategoryReadRepository { get; }
        IProductCategoryWriteRepository ProductCategoryWriteRepository { get; }
        IBrandReadRepository BrandReadRepository { get; }
        IBrandWriteRepository BrandWriteRepository { get; }

        ISupplierReadRepository SupplierReadRepository { get; }
        ISupplierWriteRepository SupplierWriteRepository { get; }
        ICustomerWriteRepository CustomerWriteRepository { get; }
        ICustomerReadRepository CustomerReadRepository { get; }

        IWareHouseReadRepository WareHouseReadRepository { get; }
        IWareHouseWriteRepository WareHouseWriteRepository { get; }
        IProductReadRepository ProductReadRepository { get; }
        IProductWriteRepository ProductWriteRepository { get; }
        IPurchageOrderReadRepository PurchageOrderReadRepository { get; }
        IPurchageOrderWriteRepository PurchageOrderWriteRepository { get; }

        IPurchageOrderItemReadRepository PurchageOrderItemReadRepository { get;  }
        IPurchageOrderItemWriteRepository PurchageOrderItemWriteRepository { get; }

        IWareHouseStockReadRepository WareHouseStockReadRepository { get; }
        IWareHouseStockWriteRepository WareHouseStockWriteRepository { get; }

        ISellerOrderReadRepository SellerOrderReadRepository { get; }
        ISellerOrderWriteRepository SellerOrderWriteRepository { get; }

        ISellerOrderItemReadRepository SellerOrderItemReadRepository{ get; }
        ISellerOrderItemWriteRepository SellerOrderItemWriteRepository { get; }

        IWarehouseReceivedProductReadRepository WarehouseReceivedProductReadRepository { get; }
        IWarehouseReceivedProductWriteRepository WarehouseReceivedProductWriteRepository { get; }
        int Complete();
    }
}
