using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentApp.Services.Contracts;

namespace StudentApp.API.DataContracts.Requests.User.PUT
{
    public class UserChangePasswordValidator : AbstractValidator<UserPasswordChange>
    {
        public UserChangePasswordValidator(IUserService userService)
        {
            RuleFor(u => u.LoginName)
                .NotEmpty()
                .WithMessage("Nie podano loginu")
                .MinimumLength(5)
                .WithMessage("Login musi mieć więcej niż 5 znaków")
                .MaximumLength(25)
                .WithMessage("Login musi mieć mniej niż 25 znaków");

            RuleFor(u => u.OldPassword)
                .NotEmpty()
                .WithMessage("Nie podano aktualnego hasła");

            RuleFor(u => u.NewPassword)
                .NotEmpty()
                .WithMessage("Nie podano nowego hasła")
                .MinimumLength(5)
                .WithMessage("Nowe hasło musi mieć więcej niż 5 znaków")
                .MaximumLength(30)
                .WithMessage("Nowe hasło musi mieć mniej niż 30 znaków");
        }
    }
}
