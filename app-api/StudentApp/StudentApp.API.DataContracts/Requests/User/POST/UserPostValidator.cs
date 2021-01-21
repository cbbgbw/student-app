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
                .MaximumLength(25)
                //.MustAsync((x, _) => ValidateLoginName(x)).WithMessage
                .Must(ValidateLoginName).WithMessage("Użytkownik o podanym loginie już istnieje");

            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(30);

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
