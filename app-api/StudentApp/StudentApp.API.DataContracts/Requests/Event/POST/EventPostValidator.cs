using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentApp.Services.Contracts;

namespace StudentApp.API.DataContracts.Requests.Event.POST
{
    public class EventPostValidator : AbstractValidator<EventPost>
    {
        public EventPostValidator(IProjectService projectService)
        {
            bool validateProject(Guid projectKey)
            {
                return projectService.GetSingleAsync(projectKey).Result != null;
            }

            RuleFor(ev => ev.ProjectKey)
                .NotEmpty()
                .Must(validateProject).WithMessage("Nie wybrano projektu");
        }
    }
}
