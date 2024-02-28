using Application.Features.Customers.Commands.CreateCustomerCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


    }
}
