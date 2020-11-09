using AutoMapper;
using Komar.Shared.Dtos.Brand;
using Komar.Shared.Dtos.Category;
using Komar.Shared.Dtos.EmployeeType;
using Komar.Shared.Dtos.Material;
using Komar.Shared.Entities;

namespace Komar.Business
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CategoryProfile();
            BrandProfile();
            MaterialProfile();
            EmployeeTypeProfile();
        }

        private void CategoryProfile()
        {
            CreateMap<CategoryFormDto, Category>();
            CreateMap<Category, CategoryDto>();
        }

        private void BrandProfile()
        {
            CreateMap<BrandFormDto, Brand>();
            CreateMap<Brand, BrandDto>();
        }

        private void MaterialProfile()
        {
            CreateMap<MaterialFormDto, Material>();
            CreateMap<Material, MaterialDetailDto>();
        }

        private void EmployeeTypeProfile()
        {
            CreateMap<EmployeeTypeFormDto, EmployeeType>();
            CreateMap<EmployeeType, EmployeeTypeDto>();
        }
    }
}
