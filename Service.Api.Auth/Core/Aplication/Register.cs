using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Api.Auth.Core.DTO;
using Service.Api.Auth.Core.Entities;
using Service.Api.Auth.Core.JWTLogic;
using Service.Api.Auth.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Api.Auth.Core.Aplication
{
    public class Register
    {
        public class UserRegisterCommand : IRequest<UserDTO>
        {
            public string Name { get; set; }
            public string Lastname { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Adress { get; set; }
        }

        public class UserRegisterValidation : AbstractValidator<UserRegisterCommand>
        {
            public UserRegisterValidation()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Lastname).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.Email).EmailAddress();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, UserDTO>
        {

            private readonly AuthContext _context;
            private readonly UserManager<User> _userManager;
            private readonly IJWTGenerator _jWTGenerator;
            private readonly IMapper _mapper;

            public UserRegisterHandler(AuthContext context,
                UserManager<User> userManager,
                IJWTGenerator jWTGenerator,
                IMapper mapper)
            {
                _context = context;
                _userManager = userManager;
                _jWTGenerator = jWTGenerator;
                _mapper = mapper;
            }

            public async Task<UserDTO> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
            {

                RespDTO respUser = new RespDTO();
                UserDTO userSend = new UserDTO();


                var exists = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();
                if (exists)
                {

                    respUser.OK = false;
                    respUser.Message = "Este email ya esta registrado";
                    userSend.response = respUser;

                    return userSend;
                }


                Regex regexemail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match matchEmail = regexemail.Match(request.Email);

                if (!matchEmail.Success)
                {
                    respUser.OK = false;
                    respUser.Message = "El formato del email es incorrecto";
                    userSend.response = respUser;

                    return userSend;
                }

                exists = await _context.Users.Where(x => x.UserName == request.Username).AnyAsync();

                if (exists)
                {
                    respUser.OK = false;
                    respUser.Message = "Este username ya esta en uso";
                    userSend.response = respUser;

                    return userSend;
                }

                var user = new User
                {
                    Name = request.Name,
                    Lastname = request.Lastname,
                    Email = request.Email,
                    UserName = request.Username,
                    Adress = request.Adress
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    var userResponse = _mapper.Map<User, UserDTO>(user);
                    userResponse.Token = _jWTGenerator.GenerateToken(user);
                    respUser.OK = true;
                    respUser.Message = "Usuario registrado";
                    userResponse.response = respUser;
                    return userResponse;
                }
                else
                {
                    List<string> errors = new List<string>();
                    foreach (var item in result.Errors)
                    {
                        errors.Add(item.Description);
                    }
                    respUser.OK = false;
                    respUser.Message = "No se pudo registrar el usuario.";
                    respUser.listErrors = errors;
                    userSend.response = respUser;
                    return userSend;
                }

            }
        }
    }
}
