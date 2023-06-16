using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() {
            RuleFor(x=> x.Name).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x=> x.Surname).NotEmpty().WithMessage("Boş bırakılamaz.");
            RuleFor(x=> x.Department).NotEmpty().WithMessage("Boş bırakılamaz.");
        }
    }
}
