using AutoMapper;
using Komar.DataAccess;
using Komar.DataAccess.Extensions;
using Komar.Shared.Dtos;
using Komar.Shared.Dtos.Material;
using Komar.Shared.Entities;
using Komar.Shared.Interfaces.Business;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Komar.Business.Implementations
{
    internal class MaterialBusiness : BusinessBase<Material>, IMaterialBusiness
    {
        public MaterialBusiness(ApplicationDbContext context, IMapper mapper) : base(context, mapper, "Material")
        {
        }

        public async Task<MaterialDetailDto> CreateMaterialAsync(MaterialFormDto dto)
        {
            return await AddAsync<MaterialDetailDto>(dto);
        }

        public async Task DeleteMaterialAsync(int id)
        {
            await RemoveAsync(id);
        }

        public async Task<MaterialDetailDto> GetMaterialAsync(int id)
        {
            var material = await Set.SelectMaterialDetail().FirstOrDefaultAsync(x => x.Id == id);
            CheckNotFound(material, id);
            return material;
        }

        public async Task<PaginationResultDto<MaterialListDto>> GetMaterialsAsync(int page, int pageSize, int? categoryId, int? brandId, string term)
        {
            var query = Set
                .FilterByBrand(brandId)
                .FilterByCategory(categoryId)
                .FilterByTerm(term);

            var count = await query.CountAsync();
            var items = await query
                .SelectMaterialList()
                .Paginate(page, pageSize)
                .ToListAsync();

            return new PaginationResultDto<MaterialListDto>(count, items);
        }

        public async Task<MaterialDetailDto> UpdateMaterialAsync(int id, MaterialFormDto dto)
        {
            await UpdateAsync<MaterialDetailDto>(id, dto);
            return await GetMaterialAsync(id);
        }
    }
}
