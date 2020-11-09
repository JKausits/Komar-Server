using AutoMapper;
using Komar.DataAccess;
using Komar.DataAccess.Extensions;
using Komar.Shared.Dtos.Brand;
using Komar.Shared.Entities;
using Komar.Shared.Exceptions;
using Komar.Shared.Interfaces.Business;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komar.Business.Implementations
{
    internal class BrandBusiness : BusinessBase<Brand>, IBrandBusiness
    {
        public BrandBusiness(ApplicationDbContext context, IMapper mapper) : base(context, mapper, "Brand")
        {
        }

        public async Task<BrandDto> CreateBrandAsync(BrandFormDto dto)
        {
            try
            {
                return await AddAsync<BrandDto>(dto);
            }
            catch (DbUpdateException ex)
            {
                HandleDuplicateNameException(ex, dto.Name);
                return null;
            }
        }

        public async Task DeleteBrandAsync(int id)
        {
            await RemoveAsync(id);
        }

        public async Task<IEnumerable<BrandDto>> GetBrandsAsync()
        {
            return await Set.SelectBrand().OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<BrandDto> GetBrandAsync(int id)
        {
            return await FindAsync<BrandDto>(id);
        }

        public async Task<BrandDto> UpdateBrandAsync(int id, BrandFormDto dto)
        {
            try
            {
                return await UpdateAsync<BrandDto>(id, dto);
            }
            catch (DbUpdateException ex)
            {
                HandleDuplicateNameException(ex, dto.Name);
                return null;
            }
        }
    }
}
