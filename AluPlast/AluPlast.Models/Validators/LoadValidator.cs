using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Models.Validators
{
    public class LoadValidator : AbstractValidator<Load>
    {
        public LoadValidator()
        {
            RuleFor(p => p.Id > 0);

            RuleFor(p => p.LoadDate > DateTime.Today);
        }
    }
}
