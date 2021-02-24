using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using StudentApp.Services.Contracts;

namespace StudentApp.API.DataContracts.Requests.User.POST
{
    public class UserPostValidator : AbstractValidator<UserPost>
    {
        public UserPostValidator(IUserService userService)
        {
            bool ValidateLoginName(string loginName)
            {
                //return userService.GetSingleByLoginAsync(loginName).Result == null;
                var users = userService.GetAllAsync().Result;

                return users.SingleOrDefault(u => u.LoginName == loginName) == null;
            }

            RuleFor(u => u.LoginName)
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Login musi mieć więcej niż 5 znaków")
                .MaximumLength(25)
                .WithMessage("Login musi mieć mniej niż 25 znaków")
                //.MustAsync((x, _) => ValidateLoginName(x)).WithMessage
                .Must(ValidateLoginName).WithMessage("Użytkownik o podanym loginie już istnieje");

            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Hasło musi mieć więcej niż 5 znaków")
                .MaximumLength(30)
                .WithMessage("Hasło musi mieć mniej niż 30 znaków");

            RuleFor(u => u.EmailAddress)
                .EmailAddress()
                .NotEmpty();

            RuleFor(u => u.FirstName)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100);

            RuleFor(u => u.LastName)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100);
        }
    }
}
