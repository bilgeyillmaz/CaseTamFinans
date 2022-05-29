using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseUI.Controllers
{

    public class BooksController : Controller
    {
        IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll(Book book)
        {
            var loggedInUser = HttpContext.Session.GetString("IsAuthenticated");
            if (string.IsNullOrEmpty(loggedInUser))
            {
                TempData["AuthenticationFailedMessage"] = "Sisteme giriş yapmanız gerekmektedir.";
                return RedirectToAction("Login", "Auth");
            }
            var result = _bookService.GetAll();
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            BookValidator bookValidator = new BookValidator();
            ValidationResult result = bookValidator.Validate(book);
            if (result.IsValid)
            {
                book.Status = true;
                _bookService.Add(book);
                return RedirectToAction("GetAll", "Books");
            }
            else
            {
                foreach (var b in result.Errors)
                {
                    ModelState.AddModelError(b.PropertyName, b.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var book = _bookService.GetById(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Update(Book book)
        {
            book.Status = true;
            _bookService.Update(book);
            return RedirectToAction("GetAll", "Books");
        }
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetById(id);
            _bookService.Delete(book);
            return RedirectToAction("GetAll", "Books");
        }
    }
}
