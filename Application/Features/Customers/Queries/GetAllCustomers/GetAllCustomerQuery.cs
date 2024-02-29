using Application.DTOs;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
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
            private readonly IDistributedCache _distributedCache;

            public GetAllCustomersQueryHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper, IDistributedCache distributedCache)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
                _distributedCache = distributedCache;
            }

            public async Task<PagedResponse<List<CustomerDto>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                string cacheKey = $"listadoCustomers_{request.PageSize}_{request.PageNumber}_{request.Nombre}_{request.Apellido}";
                string serializedListadoCustomer;
                var listadoCustomer = new List<Customer>();
                var redisListadoCustomer = await _distributedCache.GetAsync(cacheKey);

                if(redisListadoCustomer != null)
                {
                    serializedListadoCustomer = Encoding.UTF8.GetString(redisListadoCustomer);
                    listadoCustomer = JsonConvert.DeserializeObject<List<Customer>>(serializedListadoCustomer);
                }
                else
                {
                    listadoCustomer = await _repositoryAsync.ListAsync(new PagedCustomersSpecification(request.PageSize, request.PageNumber, request.Nombre, request.Apellido));
                    serializedListadoCustomer = JsonConvert.SerializeObject(listadoCustomer);
                    redisListadoCustomer = Encoding.UTF8.GetBytes(serializedListadoCustomer);

                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        
                        // Caduca como objeto en cache si no se solicita en periodo de tiempo definido
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                    await _distributedCache.SetAsync(cacheKey, redisListadoCustomer, options);
                }

                // Trae un listado de clientes en base a la specification
                var clientesDto = _mapper.Map<List<CustomerDto>>(listadoCustomer);

                return new PagedResponse<List<CustomerDto>>(clientesDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
