using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectoMVC.Context;
using proyectoMVC.Mapper.DTO;
using proyectoMVC.Models;
using proyectoMVC.Service;

namespace proyectoMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService userService;

        private readonly IWebHostEnvironment webHostEnvironment;
        public UsersController(UserService userService, IWebHostEnvironment webHostEnvironment)
        {
            this.userService = userService;
            this.webHostEnvironment = webHostEnvironment;

        }
        //login flaquito--------------------------
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("[controller]/Login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {


            if (ModelState.IsValid)
            {


                var userResponse = await userService.Login(userLoginDTO);
                if (userResponse.success)
                {
                   await userService.SignInAsync(HttpContext,userLoginDTO.email,userResponse.rol);
                  
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ViewBag.Message = userResponse.message;
                    ViewBag.Success = userResponse.success;
                }

            }
            return View(userLoginDTO);

        }

        [HttpGet]
        //REGISTER -.---------------------------------
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            if (ModelState.IsValid)
            {
                var userResponse = await userService.Register(userRegisterDTO);
                if (userResponse.success)
                {
                    await userService.SignInAsync(HttpContext, userRegisterDTO.email, userResponse.rol);

                    return RedirectToAction("Home", "Home");

                }
                else
                {
                    ViewBag.Message = userResponse.message;
                    ViewBag.Success = userResponse.success;
                }

            }
            return View(userRegisterDTO);

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Login");

        }
     
    }
}
