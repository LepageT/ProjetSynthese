using AutoMapper;
using Stagio.Domain.Entities;

namespace Stagio.Web.Mappers
{
    class ViewModelToEntityMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToEntityMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ViewModels.Student.Edit, Student>()
                .ForMember(dest => dest.FirstName, opt => opt.Ignore())
                .ForMember(dest => dest.LastName, opt => opt.Ignore())
                .ForMember(dest => dest.Matricule, opt => opt.Ignore());

         


        }
    }
}