using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using MediatR;
using GlobalEvents.Application.Exceptions;

namespace GlobalEvents.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler: IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
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
                throw new NotFoundException(nameof(DeleteCategoryCommand), request.Id);
            }

            var validator = new DeleteCategoryCommandValidator(_categoryRepo);
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult != null && validationResult.Errors.Count != 0)
            {
                throw new ValidationException(validationResult);
            }

            response.Success = await _categoryRepo.DeleteAsync(categoryToDelete);

            return response;
        }
    }
}
