using AutoMapper;
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
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Student, ViewModels.Student.Create>()
                .ForMember(dest => dest.PasswordConfirmation, opt => opt.Ignore())
                .IgnoreAllNonExisting();


            Mapper.CreateMap<Student, ViewModels.Student.ListStudent>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Stage, ViewModels.Stage.ListNewStages>()
                .IgnoreAllNonExisting();


            Mapper.CreateMap<Stage, ViewModels.Stage.Edit>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Stage, ViewModels.ContactEnterprise.ListStage>()
               .IgnoreAllNonExisting();

            Mapper.CreateMap<Stage, ViewModels.Student.AppliedStages>()
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

            Mapper.CreateMap<Interview, ViewModels.Interviews.List>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Interview, ViewModels.Interviews.Edit>()
                .IgnoreAllNonExisting();
            Mapper.CreateMap<Interview, ViewModels.Interviews.Create>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ApplicationUser, ViewModels.Account.Details>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ContactEnterprise, ViewModels.ContactEnterprise.Reactive>()
                .ForMember(dest => dest.PasswordConfirmation, opt => opt.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Stage, ViewModels.Stage.ViewInfo>()
                 .IgnoreAllNonExisting();

            Mapper.CreateMap<Apply, ViewModels.Student.AppliedStages>()
                .IgnoreAllNonExisting();


            Mapper.CreateMap<StageAgreement, ViewModels.StageAgreement.EditStageAgreement>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Student, ViewModels.ContactEnterprise.AcceptApply>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Apply, ViewModels.Student.AppliedStages>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<InvitationContactEnterprise, ViewModels.ContactEnterprise.Reactive>()
               .ForMember(dest => dest.InvitationId, opt => opt.MapFrom(src => src.Id))
               .IgnoreAllNonExisting();

            Mapper.CreateMap<Student, ViewModels.Coordinator.StudentList>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Apply, ViewModels.Coordinator.StudentApplyList>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Apply, ViewModels.Coordinator.DetailsApplyStudent>()
           .IgnoreAllNonExisting();

            Mapper.CreateMap<Notification, ViewModels.Notification.Notification>()
                .ForMember(dest => dest.NotificationId, opt => opt.MapFrom(src => src.Id))
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Notification, ViewModels.Notification.Detail>()
                .ForMember(dest => dest.NotificationId, opt => opt.MapFrom(src => src.Id))
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Stage, ViewModels.ContactEnterprise.Draft>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ContactEnterprise, ViewModels.ContactEnterprise.Edit>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ContactEnterprise, ViewModels.ContactEnterprise.Edit>()
                .ForMember(dest => dest.PasswordConfirmation, opt => opt.Ignore())
                .ForMember(dest => dest.OldPassword, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .IgnoreAllNonExisting();

            Mapper.CreateMap<StageAgreement, ViewModels.StageAgreement.StageAgreementDetail>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<ContactEnterprise, ViewModels.Stage.Create>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.EnterpriseName))
                .IgnoreAllNonExisting();
            Mapper.CreateMap<Misc, ViewModels.Coordinator.ApplyDatesLimit>()
                .IgnoreAllNonExisting();

   
        }
    }
}