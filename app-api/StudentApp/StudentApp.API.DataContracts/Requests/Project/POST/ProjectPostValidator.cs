using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentApp.Services.Contracts;

namespace StudentApp.API.DataContracts.Requests.Project.POST
{
    public class ProjectPostValidator : AbstractValidator<ProjectPost>
    {
        public ProjectPostValidator(IProjectService projectService, ISubjectService subjectService)
        {
            bool ValidateType(Guid projectTypeKey)
            {
                var types = projectService.GetTypesAsync().Result;

                return types.FirstOrDefault(type => type.DefinitionKey == projectTypeKey) != null;
            }

            //bool validateStatus(Guid statusKey)
            //{
            //    var statuses = projectService.GetAllStatusesAsync().Result;

            //    return statuses.FirstOrDefault(status => status.StatusKey == statusKey) != null;
            //}

            bool ValidateCategory(Guid categoryKey, Guid projectStatusKey)
            {
                var categories = projectService.GetAllCategoriesOrderedByIndexAsync(projectStatusKey).Result;

                return categories.SingleOrDefault(c => c.CategoryKey == categoryKey) != null;
            }

            bool ValidateProjectSubject(Guid subjectKey)
            {
                return subjectService.GetSingleAsync(subjectKey).Result != null;
            }


            RuleFor(proj => proj.TypeDefinitionKey)
                .NotEmpty()
                .Must(ValidateType).WithMessage("Nie znaleziono podanego typu definicji,");

            //RuleFor(proj => proj.ProjectStatusKey)
            //    .NotEmpty()
            //    .Must(validateStatus).WithMessage("Nie znaleziono podanego statusu,");

            RuleFor(proj => proj)
                .NotEmpty()
                .Must(proj => ValidateCategory(proj.CategoryKey, proj.TypeDefinitionKey)).WithMessage("Nie znaleziono podanej kategorii.");

            RuleFor(proj => proj.SubjectKey)
                .NotEmpty()
                .Must(ValidateProjectSubject).WithMessage("Nie znaleziono podanego przedmiotu");

            RuleFor(proj => proj.Name)
                .NotEmpty();
        }
    }
}
