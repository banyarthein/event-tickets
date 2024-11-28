using AutoMapper;
using GlobalEvents.Application.Exceptions;
using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Domain.Entities;
using MediatR;

namespace GlobalEvents.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        IMapper _mapper;
        ICategoryRepo _categoryRepo;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepo categoryRepo)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateCategoryCommandResponse();
            var validator = new UpdateCategoryCommandValidator(_categoryRepo);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult != null && validationResult.Errors.Count > 0)
            {
                response.Success = false;
                throw new ValidationException(validationResult);
            }

            var categoryToUpdate = await _categoryRepo.GetByIdAsync(request.Id);
            if (categoryToUpdate == null)
            {
                response.Success = false;
                throw new NotFoundException(nameof(UpdateCategoryCommand), request.Id);
            }

            _mapper.Map(request, categoryToUpdate, typeof(UpdateCategoryCommand), typeof(Category));

            var categoryUpdated = await _categoryRepo.UpdateAsync(categoryToUpdate);

            response.Category = _mapper.Map<UpdateCategoryModel>(categoryUpdated);

            response.Success = true;

            return response;
        }

    }

}
