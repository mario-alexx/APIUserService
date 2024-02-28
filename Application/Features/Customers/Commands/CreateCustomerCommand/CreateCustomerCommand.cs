using Application.Wrappers;
using MediatR;
using System;

namespace Application.Features.Customers.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommand : IRequest<Response<int>>
    {
        public string Nombe { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
