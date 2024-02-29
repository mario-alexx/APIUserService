using Application.DTOs;
using Application.Features.Customers.Commands.CreateCustomerCommand;
using Application.Features.Customers.Commands.UpdateCustomerCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfiles : Profile
    {
        public GeneralProfiles()
        {
            #region DTOs
            CreateMap<Customer, CustomerDto>();
            #endregion


            #region Commands
            CreateMap<CreateCustomerCommand, Customer>();
            #endregion
        }
    }
}
