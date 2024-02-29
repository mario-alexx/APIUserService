using Application.DTOs;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomerQuery : IRequest<PagedResponse<List<CustomerDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomerQuery, PagedResponse<List<CustomerDto>>>
        {
            private readonly IRepositoryAsync<Customer> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllCustomersQueryHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<PagedResponse<List<CustomerDto>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                // Trae un listado de clientes en base a la specification
                var clientes = await _repositoryAsync.ListAsync(new PagedCustomersSpecification(request.PageSize, request.PageNumber, request.Nombre, request.Apellido));
                var clientesDto = _mapper.Map<List<CustomerDto>>(clientes);

                return new PagedResponse<List<CustomerDto>>(clientesDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
