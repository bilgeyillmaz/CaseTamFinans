using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Concrete.Context;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseUI.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IUserService _userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            if (userForLoginDto.Password == null)
            {
                ModelState.AddModelError("Hata", "Lütfen bilgilerinizi eksiksiz doldurunuz!");
                return View();
            }
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            HttpContext.Session.SetString("IsAuthenticated", userForLoginDto.Email);
            var user = _userService.GetByMail(userForLoginDto.Email);
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if(user.Status==false)
            {
                return RedirectToAction("LogOut", "Auth");
            }
            if (result.Success)
            {
                return RedirectToAction("Update", "Auth", new { id = user.Id });
            }
            return BadRequest(result.Message);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            if (userForRegisterDto.Password == null || userForRegisterDto.FirstName == null || userForRegisterDto.LastName == null)
            {
                ModelState.AddModelError("Hata", "Lütfen bilgilerinizi eksiksiz doldurunuz!");
                return View();
            }
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return View();
            }
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
              if (result.Success)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Update(User user)
        {
            if (user.Email == null || user.FirstName == null || user.LastName == null)
            {
                ModelState.AddModelError("Hata", "Lütfen bilgilerinizi eksiksiz doldurunuz!");
                return View();
            }
            user.Status = true;
            _userService.Update(user);
            return RedirectToAction("GetAll", "Books");
        }
        [HttpPost]
        public IActionResult Delete(User user)
        {
            user.Status = false;
            _userService.Update(user);
            return RedirectToAction("LogOut", "Auth");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IsLogin()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Ok(false);
            }
            return Ok(true);
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.SetString("IsAuthenticated", string.Empty);
            return RedirectToAction("Login", "Auth");
        }
    }
}
