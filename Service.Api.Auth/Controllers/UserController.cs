using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Api.Auth.Core.Aplication;
using Service.Api.Auth.Core.DTO;
using System.Threading.Tasks;

namespace Service.Api.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(Register.UserRegisterCommand parames)
        {
            return await _mediator.Send(parames);
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(Login.UserLoginCommand parames)
        {
            return await _mediator.Send(parames);
        }


        [HttpGet("userCurrent")]
        public async Task<ActionResult<UserDTO>> GetUserCurrent()
        {
            return await _mediator.Send(new UserCurrent.UserCurrentCommand());
        }

    }
}
