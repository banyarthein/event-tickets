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

            RuleFor(p => p)
                .MustAsync(CategoryNameUniqueForUpdate)
                .WithMessage("Category name already in used in other record.");

        }

        private async Task<bool> CategoryNameUniqueForUpdate(UpdateCategoryCommand e, CancellationToken token)
        {
            return (!(await _categoryRepo.IsCategoryNameUniqueForUpdateAsync(e.Id, e.Name)));
        }
    }
}
