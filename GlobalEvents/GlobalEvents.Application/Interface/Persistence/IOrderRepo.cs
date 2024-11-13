using GlobalEvents.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Interface.Persistence
{
    public interface IOrderRepo : IAsyncRepo<Order>
    {
    }
}
