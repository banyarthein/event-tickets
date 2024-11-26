using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand: IRequest<DeleteCategoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
