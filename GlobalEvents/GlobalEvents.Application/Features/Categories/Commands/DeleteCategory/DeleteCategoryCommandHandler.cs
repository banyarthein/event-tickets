using AutoMapper;
using GlobalEvents.Application.Exceptions;
using GlobalEvents.Application.Interface.Persistence;
using MediatR;

namespace GlobalEvents.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
    {
        IMapper _mapper;
        ICategoryRepo _categoryRepo;

        public DeleteCategoryCommandHandler(IMapper mapper, ICategoryRepo categoryRepo)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            DeleteCategoryCommandResponse response = new DeleteCategoryCommandResponse();

            var categoryToDelete = await _categoryRepo.GetByIdAsync(request.Id);
            if (categoryToDelete == null)
            {
                response.Success = false;
                throw new NotFoundException(nameof(DeleteCategoryCommand), request.Id);
            }

            var validator = new DeleteCategoryCommandValidator(_categoryRepo);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult != null && validationResult.Errors.Count != 0)
            {
                response.Success = false;
                throw new ValidationException(validationResult);
            }

            response.Success = await _categoryRepo.DeleteAsync(categoryToDelete);

            return response;
        }
    }
}
