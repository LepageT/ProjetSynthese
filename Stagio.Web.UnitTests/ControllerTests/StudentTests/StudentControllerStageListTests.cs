using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerStageListTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void stageList_should_return_list_with_stages()
        {
            var stages = _fixture.CreateMany<Stage>(3);
            foreach (var stage in stages)
            {
                stage.AcceptedByCoordinator = true;
            }
            stageRepository.GetAll().Returns(stages.AsQueryable());

            var result = studentController.StageList() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.Student.StageList>;

            model.ShouldBeEquivalentTo(stages, options => options.ExcludingMissingProperties());
        }
    }
}
