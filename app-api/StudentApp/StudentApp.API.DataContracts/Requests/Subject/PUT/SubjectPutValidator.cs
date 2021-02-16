using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentApp.Services.Contracts;

namespace StudentApp.API.DataContracts.Requests.Subject.PUT
{
    public class SubjectPutValidator : AbstractValidator<SubjectPut>
    {

        public SubjectPutValidator(ISubjectService service)
        {
            bool ValidateType(Guid typeKey)
            {
                var types = service.GetTypesAsync().Result;

                return types.FirstOrDefault(type => type.DefinitionKey == typeKey) != null;
            }

            RuleFor(subject => subject.TypeDefinitionKey)
                .NotEmpty()
                .Must(ValidateType).WithMessage("Nie znaleziono podanego typu definicji.");

            RuleFor(subject => subject.Name)
                .NotEmpty()
                .WithMessage("Nie podano nazwy przedmiotu");
        }
    }
}
