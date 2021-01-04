using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Validators;
using StudentApp.Services.Contracts;

namespace StudentApp.API.DataContracts.Requests.Subject.POST
{
    public class SubjectPostValidatior : AbstractValidator<SubjectPost>
    {

        public SubjectPostValidatior (ISubjectService service)
        {
            bool validateType(Guid typeKey)
            {
                var types = service.GetTypes().Result;

                return types.FirstOrDefault(type => type.DefinitionKey == typeKey) != null;
            }


            RuleFor(subject => subject.TypeDefinitionKey)
                .NotEmpty()
                .Must(validateType).WithMessage("Nie znaleziono podanego typu definicji.");
        }
    }
}