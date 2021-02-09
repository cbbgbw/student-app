using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentApp.Services.Contracts;

namespace StudentApp.API.DataContracts.Requests.Project.PUT
{
    public class ProjectPutValidator : AbstractValidator<ProjectPut>
    {
        public ProjectPutValidator(IProjectService projectService, Guid userKey)
        {
            bool ValidateType(Guid projectTypeKey)
            {
                var types = projectService.GetTypesAsync().Result;

                return types.FirstOrDefault(type => type.DefinitionKey == projectTypeKey) != null;
            }

            bool ValidateStatus(Guid statusKey)
            {
                var statuses = projectService.GetAllStatusesAsync().Result;

                return statuses.FirstOrDefault(status => status.StatusKey == statusKey) != null;
            }

            bool ValidateCategory(Guid categoryKey, Guid projectTypeKey)
            {
                var categories = projectService.GetOrderedCategoriesByTypeAsync(projectTypeKey, userKey).Result;

                return categories.SingleOrDefault(c => c.CategoryKey == categoryKey) != null;
            }

            bool ValidateDeadlineTime(DateTime deadlineTime) => deadlineTime >= DateTime.Now ? true : false;

            RuleFor(proj => proj.TypeDefinitionKey)
                .NotEmpty()
                .Must(ValidateType)
                .WithMessage("Nie znaleziono podanego typu definicji");

            RuleFor(proj => proj.ProjectStatusKey)
                .NotEmpty()
                .WithMessage("Nie podano statusu projektu")
                .Must(ValidateStatus)
                .WithMessage("Nie znaleziono podanego statusu");

            RuleFor(proj => proj)
                .NotEmpty()
                .WithMessage("Nie podano typu projektu")
                .Must(proj => ValidateCategory(proj.CategoryKey, proj.TypeDefinitionKey))
                .WithMessage("Nie znaleziono podanej kategorii lub kategoria nieprawidłowa dla podanego typu");

            RuleFor(proj => proj.Name)
                .NotEmpty()
                .WithMessage("Nie podano nazwy projektu");

            RuleFor(proj => proj.DeadlineTime)
                .NotEmpty()
                .WithMessage("Data zaliczenia nie może być pusta")
                .Must(ValidateDeadlineTime)
                .WithMessage("Podana data zaliczenia musi być większa bądź równa dzisiejszej");
        }
    }
}
