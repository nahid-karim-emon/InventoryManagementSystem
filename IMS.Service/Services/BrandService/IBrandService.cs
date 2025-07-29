using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Services.BrandService
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> getAllBrand();
        Task<Brand> getBrandById(int id);
        Task<Brand> getBrandByName(string name);
        Task AddBrand(Brand brand);
    }
}
