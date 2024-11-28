using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Domain.Entities;
using MediatR;

namespace GlobalEvents.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _categoryRepo;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepo categoryRepo)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCategoryCommandResponse();

            var validator = new CreateCategoryCommandValidator(_categoryRepo);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                var category = new Category() { Name = request.Name };
                category = await _categoryRepo.AddAsync(category);
                response.Category = _mapper.Map<CreateCategoryModel>(category);
            }

            return response;
        }
    }
}
