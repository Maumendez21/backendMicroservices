using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Service.Api.Auth.Core.DTO;
using Service.Api.Auth.Core.Entities;
using Service.Api.Auth.Core.JWTLogic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Api.Auth.Core.Aplication
{
    public class UserCurrent
    {
        public class UserCurrentCommand: IRequest<UserDTO>
        {

        }

        public class UserCurrentHandler : IRequestHandler<UserCurrentCommand, UserDTO>
        {

            public UserCurrentHandler(UserManager<User> userManager, IUSerSession uSerSession, IJWTGenerator jWTGenerator, IMapper mapper)
            {
                _UserManager = userManager;
                _USerSession = uSerSession;
                _JWTGenerator = jWTGenerator;
                _Mapper = mapper;
            }

            public UserManager<User> _UserManager { get; }
            public IUSerSession _USerSession { get; }
            public IJWTGenerator _JWTGenerator { get; }
            public IMapper _Mapper { get; }

            public async Task<UserDTO> Handle(UserCurrentCommand request, CancellationToken cancellationToken)
            {
                RespDTO respUser = new RespDTO();
                UserDTO userSendTry = new UserDTO();
                User user = new User();
                try
                {
                    user = await _UserManager.FindByNameAsync(_USerSession.GetUserCurrent());

                }
                catch (System.Exception)
                {
                    respUser.OK = false;
                    respUser.Message = "El usuario no a iniciado sesión";
                    userSendTry.response = respUser;

                    return userSendTry;

                }
                


                if (user != null)
                {
                    var userDto = _Mapper.Map<User, UserDTO>(user);
                    userDto.Token = _JWTGenerator.GenerateToken(user);
                    respUser.OK = true;
                    respUser.Message = "El usuario está en sesión";
                    userDto.response = respUser;

                    return userDto;
                }
                else
                {
                    respUser.OK = false;
                    respUser.Message = "El usuario no a iniciado sesión";
                    userSendTry.response = respUser;

                    return userSendTry;
                }

            }
        }
    }
}
