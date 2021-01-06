using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentApp.API.Controllers.V2;
using StudentApp.API.DataContracts;
using StudentApp.API.DataContracts.Requests.Subject.POST;
using StudentApp.Services.Contracts;

namespace StudentApp.API.Tests.Controllers.ControllerTests.V1
{
    [TestClass]
    class SubjectControllerTests : TestBase
    {
        private SubjectController _controller;

        public SubjectControllerTests() : base()
        {
            var businessService = _serviceProvider.GetRequiredService<ISubjectService>();
            var mapper = _serviceProvider.GetRequiredService<IMapper>();

            _controller = new SubjectController(businessService, mapper);
        }

        [TestMethod]
        public async Task CreateSubject_Nominal_OK()
        {
            var subject = await _controller.CreateSubject(new SubjectPostRequest
            {
                Date = DateTime.Now,
                Subject = new SubjectPost
                {
                    SubjectKey = Guid.NewGuid(),
                    Name = "Math",
                    Description = "One of main subjects",
                    HasProjectToPass = true,
                    Semester = 1
                }
            });
            
            Assert.IsNotNull(subject);

        }

        [TestMethod]
        public async Task GetSubjectById_Nominal_OK()
        {
            
        }

        [TestMethod]
        public async Task CreateAndGetSubject_OK()
        {
            var subject = await _controller.CreateSubject(new SubjectPostRequest
            {
                Date = DateTime.Now,
                Subject = new SubjectPost
                {
                    SubjectKey = Guid.NewGuid(),
                    Name = "Math",
                    Description = "One of main subjects",
                    HasProjectToPass = true,
                    Semester = 1
                }
            });

        }
    }
}
