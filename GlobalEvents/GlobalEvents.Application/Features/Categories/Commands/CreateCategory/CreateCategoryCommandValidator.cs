using FluentValidation;
using GlobalEvents.Application.Interface.Persistence;

namespace GlobalEvents.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private ICategoryRepo _categoryRepo;

        public CreateCategoryCommandValidator(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;

            int nameMaxLength = 50;

            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is requried.")
                .NotNull()
                .MaximumLength(nameMaxLength).WithMessage("{PropertyName} must not exceed " + nameMaxLength.ToString() + " characters.");
        }
    }
}
