using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Models.Validators
{
    public class PaczkaNagValidator : AbstractValidator<PaczkaNag>
    {
        public PaczkaNagValidator()
        {
            RuleFor(p => p.Numer)
                .GreaterThan(5);


        }
    }
}
