using Stagio.DataLayer.EntityFramework;
using Stagio.Domain.Entities;

namespace Stagio.TestUtilities.Database
{
    public class DataBaseTestHelper
    {
        private EfEntityRepository<ApplicationUser> _userRepository;
        private EfEntityRepository<Student> _studentRepository;
        private EfEntityRepository<Coordinator> _coordonnatorRepository;
        private EfEntityRepository<Invitation> _invitationRepository;
        private EfEntityRepository<ContactEnterprise> _contactEnterpriseRepository;
        private EfEntityRepository<Stage> _stageRepository;
        private EfEntityRepository<Apply> _applyRepository;
        private EfEntityRepository<InvitationContactEnterprise> _invitationContactEnterpriseRepository;
        private EfEntityRepository<Notification> _notificationRepository;
        private EfEntityRepository<StageAgreement> _stageAgreementRepository; 
        private EfEntityRepository<Interview> _interviewRepository;
        private EfEntityRepository<Misc> _miscRepository;

        public DataBaseTestHelper()
        {
            _studentRepository = new EfEntityRepository<Student>();
            _userRepository = new EfEntityRepository<ApplicationUser>();
            _coordonnatorRepository = new EfEntityRepository<Coordinator>();
            _invitationRepository = new EfEntityRepository<Invitation>();
            _contactEnterpriseRepository = new EfEntityRepository<ContactEnterprise>();
            _stageRepository = new EfEntityRepository<Stage>();
            _applyRepository = new EfEntityRepository<Apply>();
            _invitationContactEnterpriseRepository = new EfEntityRepository<InvitationContactEnterprise>();
            _notificationRepository = new EfEntityRepository<Notification>();
            _stageAgreementRepository = new EfEntityRepository<StageAgreement>();
            _interviewRepository = new EfEntityRepository<Interview>();
            _miscRepository = new EfEntityRepository<Misc>();
        }

        public void SeedTables()
        {
            addStudents();
            addCoordonnator();
            addInvitation();
            addEnterprises();
            addStages();
            addApplies();
            addInvitationContactEnterprise();
            addNotificationStudent();
            addNotificationContactEnterprise();
            addNotificationCoordinator();
            addDraft();
            addStageAgreement();
            addInterview();
            addMisc();
        }

        public void SeedPresentationTables()
        {
            addStudents();
            addCoordonnator();
            addEnterprises();
            addMisc();
        }

        private void addMisc()
        {
            _miscRepository.Add(TestData.misc);
        }
        private void addApplies()
        {
            _applyRepository.Add(TestData.apply1);
            _applyRepository.Add(TestData.apply2);
            _applyRepository.Add(TestData.apply3);
            _applyRepository.Add(TestData.apply4);
        }

        private void addStages()
        {
            var stage1 = TestData.stage1;
            var stage2 = TestData.stage2;
            var stage3 = TestData.stage3;
            var stage4 = TestData.stage4;
            _stageRepository.Add(stage1);
            _stageRepository.Add(stage2);
            _stageRepository.Add(stage3);
            _stageRepository.Add(stage4);

        }


        private void addStudents()
        {
            _studentRepository.Add(TestData.student1);
            _studentRepository.Add(TestData.student2);
            _studentRepository.Add(TestData.student3);

        }

        private void addCoordonnator()
        {
            var coordinator1 = TestData.coordinator1;
            var coordinator2 = TestData.coordinator2;
            _coordonnatorRepository.Add(coordinator1);
            _coordonnatorRepository.Add(coordinator2);
        }

        private void addInvitation()
        {
            _invitationRepository.Add(TestData.invitation1);
        }

        private void addEnterprises()
        {
            _contactEnterpriseRepository.Add(TestData.contactEnterprise1);
            _contactEnterpriseRepository.Add(TestData.contactEnterprise2);
            _contactEnterpriseRepository.Add(TestData.contactEnterprise3);
        }

        private void addInvitationContactEnterprise()
        {
            _invitationContactEnterpriseRepository.Add(TestData.invitationContactEnterprise1);
        }


        private void addNotificationStudent()
        {
            _notificationRepository.Add(TestData.notificationStudent1);
            _notificationRepository.Add(TestData.notificationStudent2);

        }

        private void addNotificationContactEnterprise()
        {
            _notificationRepository.Add(TestData.notificationContactEnterprise1);
            _notificationRepository.Add(TestData.notificationContactEnterprise2);
        }

        private void addNotificationCoordinator()
        {
            _notificationRepository.Add(TestData.notificationCoordinator1);
            _notificationRepository.Add(TestData.notificationCoordinator2);
        }

        private void addDraft()
        {
            _stageRepository.Add(TestData.draft1);
        }

        private void addStageAgreement()
        {
            _stageAgreementRepository.Add(TestData.stageAgreementNotSigned);
            _stageAgreementRepository.Add(TestData.stageAgreementSigned);
        }

        private void addInterview()
        {
            _interviewRepository.Add(TestData.interview1);
            _interviewRepository.Add(TestData.interview2);

        }
    }
}
