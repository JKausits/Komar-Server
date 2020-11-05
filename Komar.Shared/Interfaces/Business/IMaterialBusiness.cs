using Komar.Shared.Dtos;
using Komar.Shared.Dtos.Material;
using System.Threading.Tasks;

namespace Komar.Shared.Interfaces.Business
{
    public interface IMaterialBusiness
    {
        Task<PaginationResultDto<MaterialListDto>> GetMaterialsAsync(int page,
                                                                     int pageSize,
                                                                     int? categoryId,
                                                                     int? brandId,
                                                                     string term);
        Task<MaterialDetailDto> GetMaterialAsync(int id);
        Task<MaterialDetailDto> CreateMaterialAsync(MaterialFormDto dto);
        Task<MaterialDetailDto> UpdateMaterialAsync(int id, MaterialFormDto dto);
        Task DeleteMaterialAsync(int id);
    }
}
