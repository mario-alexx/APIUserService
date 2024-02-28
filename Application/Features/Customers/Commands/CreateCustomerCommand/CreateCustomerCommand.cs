using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
    {
        private readonly  IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Customer>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Id);
        }
    }
}
