using FluentValidation;
using GlobalEvents.Application.Features.Events.Commands.CreateEvent;
using GlobalEvents.Application.Interface.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator: AbstractValidator<DeleteCategoryCommand>
    {
        ICategoryRepo _categoryRepo;

        public DeleteCategoryCommandValidator(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;

            RuleFor(p => p)
                .MustAsync(IsCategoryInUse)
                .WithMessage("{PropertyName} is in use and cannot be deleted.");
        }


        private async Task<bool> IsCategoryInUse(DeleteCategoryCommand e, CancellationToken token)
        {
            return (!(await _categoryRepo.IsCategoryInUseAsync(e.Id)));
        }
    }
}
