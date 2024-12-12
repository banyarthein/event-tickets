using AutoMapper;
using GlobalEvents.Application.Interface.Infrastructure;
using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Application.Model.Mail;
using GlobalEvents.Domain.Entities;
using MediatR;

namespace GlobalEvents.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse >
    {
        IMapper _mapper;
        IOrderRepo _orderRepo;
        IEmailService _emailService;

        public CreateOrderCommandHandler(IMapper mapper, IOrderRepo orderRepo, IEmailService emailService)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
            _emailService = emailService;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateOrderCommandResponse();

            var validator = new CreateOrderCommandValidator();
            var results = await validator.ValidateAsync(request);

            if (results.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = results.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }


            var order = _mapper.Map<Order>(request.CreateOrderModel);
            order = await _orderRepo.AddAsync(order);
            response.CreateOrderModel = _mapper.Map<CreateOrderModel>(order);
            response.Success = true;

            await SendEmail(order);
            

            return response;
        }


        private async Task<bool> SendEmail(Order item)
        {
            var email = new Email
            {
                To = "banyar.lanwork@gmail.com",
                Cc = "banyarthein.mm@gmail.com",
                Subject = $"New Order ({item.Id}) for the Event ({item.EventId}) was Created",
                Body = $"A new Order {item.Id} has been created." +
                        $"Purchased {item.TicketsCount} ticket(s) for the Event {item.EventId} at {item.CreatedDate}"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //Do nothing for now
                return false;
            }
            //Send email
            return true;
        }
    }
}
