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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Core
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly ApplicationReadDbContext _readContext;
        private readonly ApplicationWriteDbContext _writeContext;

        public UnitOfWorks(ApplicationReadDbContext readContext, ApplicationWriteDbContext writeContext)
        {
            _readContext = readContext;
            _writeContext = writeContext;

            ProductCategoryWriteRepository = new ProductCategoryWriteRepository(writeContext);
            ProductCategoryReadRepository = new ProductCategoryReadRepository(readContext);
            BrandWriteRepository = new BrandWriteRepository(writeContext);
            BrandReadRepository = new BrandReadRepository(readContext);
            SupplierWriteRepository = new SupplierWriteRepository(writeContext);
            SupplierReadRepository = new SupplierReadRepository(readContext);
            CustomerReadRepository = new CustomerReadRepository(readContext);
            CustomerWriteRepository = new CustomerWriteRepository(writeContext);
            WareHouseReadRepository = new WareHouseReadRepository(readContext);
            WareHouseWriteRepository = new WareHouseWriteRepository(writeContext);
            ProductReadRepository = new ProductReadRepository(readContext);
            ProductWriteRepository = new ProductWriteRepository(writeContext);
            PurchageOrderReadRepository = new PurchageOrderReadRepository(readContext);
            PurchageOrderWriteRepository = new PurchageOrderWriteRepository(writeContext);
            PurchageOrderItemReadRepository = new PurchageOrderItemReadRepository(readContext);
            PurchageOrderItemWriteRepository = new PurchageOrderItemWriteRepository(writeContext);
            WareHouseStockReadRepository = new WareHouseStockReadRepository(readContext);
            WareHouseStockWriteRepository = new WareHouseStockWriteRepository(writeContext);
            SellerOrderReadRepository = new SellerOrderReadRepository(readContext);
            SellerOrderWriteRepository = new SellerOrderWriteRepository(writeContext);
            SellerOrderItemReadRepository = new SellerOrderItemReadRepository(readContext);
            SellerOrderItemWriteRepository = new SellerOrderItemWriteRepository(writeContext);
            WarehouseReceivedProductReadRepository = new WarehouseReceivedProductReadRepository(readContext);
            WarehouseReceivedProductWriteRepository = new WarehouseReceivedProductWriteRepository(writeContext);
        }

        public IProductCategoryWriteRepository ProductCategoryWriteRepository { get; private set; }
        public IProductCategoryReadRepository ProductCategoryReadRepository { get; private set; }
        public IBrandWriteRepository BrandWriteRepository { get; private set; }
        public IBrandReadRepository BrandReadRepository { get; private set; }
        public ISupplierReadRepository SupplierReadRepository { get; private set; }
        public ISupplierWriteRepository SupplierWriteRepository { get; private set; }

        public ICustomerReadRepository CustomerReadRepository { get; private set; }
        public ICustomerWriteRepository CustomerWriteRepository { get; private set; }
        public IWareHouseReadRepository WareHouseReadRepository { get; private set; }
        public IWareHouseWriteRepository WareHouseWriteRepository { get; private set; }
        public IProductReadRepository ProductReadRepository { get; private set; }
        public IProductWriteRepository ProductWriteRepository { get; private set; }
        public IPurchageOrderReadRepository PurchageOrderReadRepository { get; private set; }
        public IPurchageOrderWriteRepository PurchageOrderWriteRepository { get; private set; }

        public IWareHouseStockReadRepository WareHouseStockReadRepository { get; private set; }
        public IWareHouseStockWriteRepository WareHouseStockWriteRepository { get; private set; }
        public IPurchageOrderItemReadRepository PurchageOrderItemReadRepository { get; private set; }
        public IPurchageOrderItemWriteRepository PurchageOrderItemWriteRepository { get; private set; }

        public ISellerOrderReadRepository SellerOrderReadRepository { get; private set; }
        public ISellerOrderWriteRepository SellerOrderWriteRepository { get; private set; }

        public ISellerOrderItemReadRepository SellerOrderItemReadRepository { get; private set; }
        public ISellerOrderItemWriteRepository SellerOrderItemWriteRepository{ get; private set; }

        public IWarehouseReceivedProductReadRepository WarehouseReceivedProductReadRepository { get; private set; }
        public IWarehouseReceivedProductWriteRepository WarehouseReceivedProductWriteRepository { get; private set; }

        public int Complete()
        {
            return _writeContext.SaveChanges();
        }

        public void Dispose()
        {
            _writeContext.Dispose();
        }
    }
}
