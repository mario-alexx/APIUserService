using Application.Features.Customers.Commands.CreateCustomerCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfiles : Profile
    {
        public GeneralProfiles()
        {
            #region Commands
            CreateMap<CreateCustomerCommand, Customer>();
            #endregion
        }
    }
}
