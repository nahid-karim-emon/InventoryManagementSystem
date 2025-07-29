using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.SellerOrderService
{
    public class SellerOrderService(IUnitOfWorks unitOfWorks) : ISellerOrderService
    {
        public async Task<int> AddSellerOrder(SellerOrder sellerOrder)
        {
            await unitOfWorks.SellerOrderWriteRepository.AddAsync(sellerOrder);
            unitOfWorks.Complete();
            return sellerOrder.id;
        }

        public async Task<IEnumerable<SellerOrder>> getAllSellerOrder()
        {
            return await unitOfWorks.SellerOrderReadRepository.GetAllAsync();
        }

        public async Task<SellerOrder> getSellerOrderById(int id)
        {
            return await unitOfWorks.SellerOrderReadRepository.GetByIdAsync(id);
        }
    }
}
