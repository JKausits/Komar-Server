using Komar.Shared.Dtos.Brand;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Komar.Shared.Interfaces.Business
{
    public interface IBrandBusiness
    {
        Task<IEnumerable<BrandDto>> GetBrandsAsync();
        Task<BrandDto> GetBrandAsync(int id);
        Task<BrandDto> CreateBrandAsync(BrandFormDto dto);
        Task<BrandDto> UpdateBrandAsync(int id, BrandFormDto dto);
        Task DeleteBrandAsync(int id);
    }
}
