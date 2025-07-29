using IMS.Core.Entities;
using IMS.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.PurchageOrderService
{
    public class PurchageOrderService(IUnitOfWorks _unitOfWorks) : IPurchageOrderService
    {
        public async Task<int> AddPurchageOrder(PurchageOrder purchageOrder)
        {
            await _unitOfWorks.PurchageOrderWriteRepository.AddAsync(purchageOrder);
            _unitOfWorks.Complete();
            return purchageOrder.id;
        }

        public async Task<IEnumerable<PurchageOrder>> getAllPurchageOrder()
        {
            return await _unitOfWorks.PurchageOrderReadRepository.GetAllAsync();
        }

        public async Task<PurchageOrder> getPurchageOrderById(int id)
        {
            return await _unitOfWorks.PurchageOrderReadRepository.GetByIdAsync(id);
        }

        public async Task UpdatePurchageStatus(int id)
        {
            var res = await _unitOfWorks.PurchageOrderReadRepository.GetByIdAsync(id);
            if(res == null)
            {
                return;
            }
            res.status = "Approved";
            _unitOfWorks.PurchageOrderWriteRepository.Update(res);
            _unitOfWorks.Complete();
        }
    }
}
