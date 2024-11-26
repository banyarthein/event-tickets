using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler: IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        IMapper _mapper;
        ICategoryRepo _categoryRepo;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepo categoryRepo)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }   
    
}
