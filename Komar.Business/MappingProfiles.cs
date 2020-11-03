using AutoMapper;
using Komar.Shared.Dtos.Category;
using Komar.Shared.Entities;

namespace Komar.Business
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CategoryProfile();
        }

        private void CategoryProfile()
        {
            CreateMap<CategoryFormDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
