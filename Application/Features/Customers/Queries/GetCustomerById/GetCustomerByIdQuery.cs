using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Response<CustomerDto>>
    {
        public int Id { get; set; }

        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerDto>>
        {
            private readonly IRepositoryAsync<Customer> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetCustomerByIdQueryHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var cliente = await _repositoryAsync.GetByIdAsync(request.Id);

                if (cliente == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
                }
                else
                {
                    var dto = _mapper.Map<CustomerDto>(cliente);
                    return new Response<CustomerDto>(dto);
                }

            }
        }
    }
}
