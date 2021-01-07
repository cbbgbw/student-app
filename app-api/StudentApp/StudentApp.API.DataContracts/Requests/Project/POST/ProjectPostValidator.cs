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
        public ProjectPostValidator(IProjectService service)
        {
            bool validateType(Guid projectTypeKey)
            {
                var types = service.GetTypesAsync().Result;

                return types.FirstOrDefault(type => type.DefinitionKey == projectTypeKey) != null;
            }

            bool validateStatus(Guid statusKey)
            {
                var statuses = service.GetAllStatusesAsync().Result;

                return statuses.FirstOrDefault(status => status.StatusKey == statusKey) != null;
            }

            //bool validateCategory(Guid currentTypeKey)
            //{
            //    //var types = service.GetTypesAsync().Result;
            //    //Guid currentTypeKey = types.FirstOrDefault(t => t.DefinitionKey == projectTypeKey).DefinitionKey;

            //    var categories = service.GetAllCategoriesOrderedByIndexAsync(currentTypeKey).Result;

            //    return categories.FirstOrDefault(category => category.CategoryKey == categoryKey) != null;
            //    return categories.FirstOrDefault(category => category.CategoryKey == categoryKey) != null;
            //}

            bool validateSubject(Guid subjectKey)
            {
                var subjects = service.GetAllSubjectsAsync().Result;

                return subjects.FirstOrDefault(subject => subject.SubjectKey == subjectKey) != null;
            }

            RuleFor(proj => proj.TypeDefinitionKey)
                .NotEmpty()
                .Must(validateType).WithMessage("Nie znaleziono podanego typu definicji,");

            RuleFor(proj => proj.ProjectStatusKey)
                .NotEmpty()
                .Must(validateStatus).WithMessage("Nie znaleziono podanego statusu,");

            //RuleFor(proj => proj.CategoryKey)
            //    .NotEmpty()
            //    .Must(validateCategory).WithMessage("Nie znaleziono podanej kategorii.");

            RuleFor(proj => proj.SubjectKey)
                .NotEmpty()
                .Must(validateSubject).WithMessage("Nie znaleziono podanego przedmiotu.");

            RuleFor(proj => proj.Name)
                .NotEmpty();
        }
    }
}
