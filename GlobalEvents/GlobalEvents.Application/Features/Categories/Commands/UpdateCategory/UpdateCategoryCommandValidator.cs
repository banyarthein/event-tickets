using FluentValidation;
using GlobalEvents.Application.Interface.Persistence;

namespace GlobalEvents.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        ICategoryRepo _categoryRepo;

        public UpdateCategoryCommandValidator(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;

            RuleFor(p => p.Name)
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .NotEmpty().WithMessage("{PropertyName} is requried.");

        }
    }
}
