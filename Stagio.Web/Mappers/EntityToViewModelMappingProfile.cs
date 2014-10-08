using AutoMapper;
using Ninject.Infrastructure.Language;
using Stagio.Domain.Entities;

namespace Stagio.Web.Mappers
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "EntityToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Student, ViewModels.Student.Edit>()
                .ForMember(dest => dest.PasswordConfirmation, opt => opt.Ignore())
                .ForMember(dest => dest.OldPassword, opt => opt.Ignore());

            Mapper.CreateMap<Student, ViewModels.Student.Create>();



        }
    }
}