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
            bool ValidateProject(Guid projectKey)
            {
                return projectService.GetSingleAsync(projectKey).Result != null;
            }

            RuleFor(ev => ev.ProjectKey)
                .NotEmpty()
                .Must(ValidateProject).WithMessage("Nie wybrano projektu");

            RuleFor(ev => ev.Title)
                .NotEmpty()
                .WithMessage("Nie podano nazwy wydarzenia")
                .MaximumLength(100)
                .WithMessage("Nazwa zbyt długa (max 100 znaków)");

            RuleFor(ev => ev.Content)
                .MaximumLength(500)
                .WithMessage("Opis zbyt długi (max 500 znaków)");
        }
    }
}
