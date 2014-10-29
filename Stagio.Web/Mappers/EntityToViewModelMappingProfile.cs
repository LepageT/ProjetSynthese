using System.Security.Cryptography;
using AutoMapper;
using Ninject.Infrastructure.Language;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Stage;

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
                .ForMember(dest => dest.OldPassword, opt => opt.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Student, ViewModels.Student.Create>()
                .ForMember(dest => dest.PasswordConfirmation, opt => opt.Ignore())
                .IgnoreAllNonExisting();


            Mapper.CreateMap<Student, ViewModels.Student.ListStudent>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Stage, ViewModels.Stage.ListNewStages>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Stage, ViewModels.ContactEnterprise.ListStage>()
               .IgnoreAllNonExisting();

            Mapper.CreateMap<Invitation, ViewModels.Coordinator.Create>()
                .ForMember(dest => dest.FirstName, opt => opt.Ignore())
                .ForMember(dest => dest.LastName, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.ConfirmedPassword, opt => opt.Ignore())
                .ForMember(dest => dest.InvitationId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Stage, Details>()
              .IgnoreAllNonExisting();
            
            Mapper.CreateMap<Stage, ViewModels.Student.StageList>()
                .IgnoreAllNonExisting();
            Mapper.CreateMap<Apply, ViewModels.Apply.StudentApply>()
            .IgnoreAllNonExisting();

            Mapper.CreateMap<Apply, ViewModels.Apply.StudentApply>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Apply, ViewModels.Student.Apply>()
               .IgnoreAllNonExisting();


            Mapper.CreateMap<ContactEnterprise, ViewModels.ContactEnterprise.Reactive>()
                .ForMember(dest => dest.PasswordConfirmation, opt => opt.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Stage, ViewModels.Stage.ViewInfo>();


        }
    }
}