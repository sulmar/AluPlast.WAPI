using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Models.Validators
{
    public class PaczkaElemValidator : AbstractValidator<PaczkaElem>
    {
        public PaczkaElemValidator()
        {
            RuleFor(p => p.Ilosc)
                .InclusiveBetween(1, 5);
        }
    }
}
