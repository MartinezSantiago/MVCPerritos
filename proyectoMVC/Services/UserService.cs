using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoMVC.Context;
using proyectoMVC.Entities;
using proyectoMVC.Helper;
using proyectoMVC.Mapper;
using proyectoMVC.Mapper.DTO;
using proyectoMVC.Models;
using System.Security.Claims;
using AppContext = proyectoMVC.Context.AppContext;

namespace proyectoMVC.Service
{
    public class UserService
    {
        private readonly AppContext context;
        private readonly AutoMapper autoMapper;
        private readonly Encriptacion encriptacion;
        private readonly ImageToDirectory imageToDirectory;
        public UserService(AppContext context, AutoMapper autoMapper, Encriptacion encriptacion, ImageToDirectory imageToDirectory)
        {
            this.context = context;          
            this.autoMapper = autoMapper;
            this.encriptacion = encriptacion;
            this.imageToDirectory = imageToDirectory;
        }


        public async Task<UserResponse> Login(UserLoginDTO userLogin)
        {
            var userResponse = new UserResponse();
            userLogin.password = encriptacion.GetSHA256(userLogin.password);
            var user = await context.users.FirstOrDefaultAsync(x=> x.email== userLogin.email && x.IsDeleted==false);
            if(user!=null)
            {
                if(userLogin.password == user.password)
                {
                    userResponse.message = "✅ Ingreso exitoso";
                    userResponse.success = true;
                    userResponse.rol=user.role;

                }else
                {
                    userResponse.message = "❌ El email o la contraseña es incorrecta, verifique los datos ingresados.";
                    userResponse.success = false;
                }
                
            }else {
                userResponse.message = "❌ El usuario no se encuentra registrado";
                userResponse.success = false;
            }
            return userResponse;
        }
        public async Task<UserResponse> Register(UserRegisterDTO userRegisterDTO)
        {
            var userResponse = new UserResponse();
            if (await context.users.Where(x => x.email == userRegisterDTO.email).AnyAsync()) 
                {
                    userResponse.success = false;
                    userResponse.message = "❌ El email " + userRegisterDTO.email+ " ya se encuentra registrado";
                    return userResponse;
                }
            userRegisterDTO.password=encriptacion.GetSHA256(userRegisterDTO.password);
            var user = autoMapper.userRegisterDTOToUser(userRegisterDTO);
            user.role = "usuario";
            await context.users.AddAsync(user);
            await context.SaveChangesAsync();

            userResponse.success = true;
            userResponse.message = "✅ Usuario registrado";
            userResponse.rol = user.role;
            return userResponse;
            
        }

        private async Task<ClaimsIdentity> GetClaims(string Email, string Role)
        {
            var user=  await context.users.Where(x => x.IsDeleted == false && x.email == Email).FirstOrDefaultAsync();

            var claim = new List<Claim>{new Claim(ClaimTypes.NameIdentifier, (user.Id).ToString()),
                        new Claim(ClaimTypes.Email,Email),
                        new Claim(ClaimTypes.Role,Role)

                    };
            var claims = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            return claims;
        }
     public async Task SignInAsync(HttpContext htppContext, string email, string rol)
        {
            await htppContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(await GetClaims(email,rol)), new AuthenticationProperties
            {

                IsPersistent = true,
                AllowRefresh = true

            });
        }
    }
}
