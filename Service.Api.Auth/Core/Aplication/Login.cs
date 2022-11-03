using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Service.Api.Auth.Core.DTO;
using Service.Api.Auth.Core.Entities;
using Service.Api.Auth.Core.JWTLogic;
using Service.Api.Auth.Core.Persistance;
using System.Collections.Generic;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Api.Auth.Core.Aplication
{
    public class Login
    {
        public class UserLoginCommand : IRequest<UserDTO>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class UserLoginValidation : AbstractValidator<UserLoginCommand>
        {
            public UserLoginValidation()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }


        public class UserLoginHandler : IRequestHandler<UserLoginCommand, UserDTO>
        {

            public UserLoginHandler(AuthContext securityContext, UserManager<User> userManager, IMapper mapper, IJWTGenerator jWTGenerator, SignInManager<User> signInManager)
            {
                _SecurityContext = securityContext;
                _UserManager = userManager;
                _Mapper = mapper;
                _JWTGenerator = jWTGenerator;
                _SignInManager = signInManager;
            }

            public AuthContext _SecurityContext { get; }
            public UserManager<User> _UserManager { get; }
            public IMapper _Mapper { get; }
            public IJWTGenerator _JWTGenerator { get; }
            public SignInManager<User> _SignInManager { get; }

            public async Task<UserDTO> Handle(UserLoginCommand request, CancellationToken cancellationToken)
            {
                RespDTO respUser = new RespDTO();
                UserDTO userSend = new UserDTO();

                var user = await _UserManager.FindByEmailAsync(request.Email);

                Regex regexemail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match matchEmail = regexemail.Match(request.Email);

                if (!matchEmail.Success)
                {
                    respUser.OK = false;
                    respUser.Message = "El formato del email es incorrecto";
                    userSend.response = respUser;

                    return userSend;
                }


                if (user is null)
                {
                    respUser.OK = false;
                    respUser.Message = "Este email no esta registrado";
                    userSend.response = respUser;

                    return userSend;
                }


                var result = await _SignInManager.CheckPasswordSignInAsync(user, request.Password, false);


                if (result.Succeeded)
                {
                    var userResponse = _Mapper.Map<User, UserDTO>(user);
                    userResponse.Token = _JWTGenerator.GenerateToken(user);
                    respUser.OK = true;
                    respUser.Message = user.UserName + " Inicio sesión";
                    userResponse.response = respUser;
                    return userResponse;

                }
                else
                {
                    //List<string> errors = new List<string>();
                    //foreach (var item in result.)
                    //{
                    //    errors.Add(item.Description);
                    //}
                    respUser.OK = false;
                    respUser.Message = "No se pudo iniciar sesión.";
                    //respUser.listErrors = errors;
                    userSend.response = respUser;
                    return userSend;
                }




            }
        }
    }
}
