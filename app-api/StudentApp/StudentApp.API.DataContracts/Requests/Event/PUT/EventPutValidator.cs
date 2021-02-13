using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentApp.Services.Contracts;

namespace StudentApp.API.DataContracts.Requests.Event.PUT
{
    public class EventPutValidator : AbstractValidator<EventPut>
    {
        public EventPutValidator()
        {
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
