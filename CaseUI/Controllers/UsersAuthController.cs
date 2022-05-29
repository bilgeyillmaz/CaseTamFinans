using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CaseUI.Controllers
{
    public class UsersAuthController : Controller
    {
        IUserService _userService;
        IAuthService _authService;
        public UsersAuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var httpClient = new HttpClient();
            var jsonUser = JsonConvert.SerializeObject(userForLoginDto);
            StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var responceMessage = await httpClient.PostAsync("https://localhost:44334/api/Users/login", content);
            if (responceMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAll", "Books");
            }
            return View(userForLoginDto);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var httpClient = new HttpClient();
            var jsonUser = JsonConvert.SerializeObject(userForRegisterDto);
            StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var responceMessage = await httpClient.PostAsync("https://localhost:44334/api/Users/register", content);
            if (responceMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            return View(userForRegisterDto);
        }
    }
}


