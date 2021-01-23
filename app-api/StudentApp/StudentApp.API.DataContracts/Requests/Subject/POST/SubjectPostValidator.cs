using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Validators;
using StudentApp.Services.Contracts;

namespace StudentApp.API.DataContracts.Requests.Subject.POST
{
    public class SubjectPostValidator : AbstractValidator<SubjectPost>
    {

        public SubjectPostValidator (ISubjectService service)
        {
            bool ValidateType(Guid typeKey)
            {
                var types = service.GetTypes().Result;

                return types.FirstOrDefault(type => type.DefinitionKey == typeKey) != null;
            }


            RuleFor(subject => subject.TypeDefinitionKey)
                .NotEmpty()
                .Must(ValidateType).WithMessage("Nie znaleziono podanego typu definicji.");
        }
    }
}