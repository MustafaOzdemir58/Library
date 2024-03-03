using FluentValidation;
using Library.Entities.MongoDB.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Validators
{
    public sealed class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Book name cannot be null");
            RuleFor(x => x.Name).MinimumLength(1).MaximumLength(100).WithMessage("Book Name must be bigger than zero and lower than 100");
            RuleFor(x => x.PageCount).NotEmpty().WithMessage("Page count cannot be null");
            RuleFor(x => x.PageCount).GreaterThan(0).WithMessage("Page count have to be bigger than 0");
            RuleFor(x => x.PublishedYear).NotEmpty().WithMessage("Published year cannot be null");
            RuleFor(x => x.PublishedYear).GreaterThan(0).WithMessage("Published year must be bigger than 0");
        }
    }
}
