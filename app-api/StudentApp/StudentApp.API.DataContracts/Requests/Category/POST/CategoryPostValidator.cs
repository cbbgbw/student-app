using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentApp.Services.Contracts;

namespace StudentApp.API.DataContracts.Requests.Category.POST
{
    public class CategoryPostValidator : AbstractValidator<Services.Model.Category>
    {
        public CategoryPostValidator(IProjectService projectService)
        {
            bool ValidateName(string categoryName, Guid userKey)
            {
                if (userKey == Guid.Empty || categoryName == "")
                    return false;

                var types = projectService.GetTypesAsync().Result;

                Services.Model.Category[] categories = new Services.Model.Category[100];
                int arrayCounter = 0;

                foreach (var type in types)
                {
                    var items = projectService.GetOrderedCategoriesByTypeAsync(type.DefinitionKey, userKey).Result;

                    items.CopyTo(categories, arrayCounter);
                    arrayCounter += items.Count();
                }



                foreach (var category in categories)
                {
                    if (category?.CategoryName == categoryName)
                        return false;

                    if (category?.CategoryName == null)
                        return true;
                }

                return true;
            }

            RuleFor(cat => cat)
                .NotEmpty()
                .Must(cat => ValidateName(cat.CategoryName, cat.UserKey))
                .WithMessage("Kategoria o podanej nazwie już istnieje");
        }
    }
}
