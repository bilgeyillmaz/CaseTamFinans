using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(p => p.BookName).NotEmpty();
            RuleFor(p => p.WriterFullName).MinimumLength(2).NotEmpty();
            RuleFor(p => p.NumberOfPages).GreaterThan(7).NotEmpty();
            RuleFor(p => p.PublishingHouse).NotEmpty();
            RuleFor(p => p.CategoryName).NotEmpty();
        }
    }
}
