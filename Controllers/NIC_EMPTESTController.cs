using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NIC_Demo_Project.Features.NIC_EMP_DemoFeatures.Commands;
using NIC_Demo_Project.Features.NIC_EMP_DemoFeatures.Queries;

namespace NIC_Demo_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NIC_EMPTESTController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator));

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromHeader] GetAllNicEmp command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetNicEmpbyId command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateNicEmpCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateNicEmpCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut]
        [Route("StatusChange")]
        public async Task<IActionResult> StatusChange([FromBody] ChangeStatusNicEmpCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
