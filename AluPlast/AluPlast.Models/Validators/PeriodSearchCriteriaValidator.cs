using AluPlast.Models.SearchCriterias;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Models.Validators
{
    public class PeriodSearchCriteriaValidator : AbstractValidator<PeriodSearchCriteria>
    {
        public PeriodSearchCriteriaValidator()
        {
            RuleFor(p => p.BeginDate)
                .LessThanOrEqualTo(p => p.EndDate)
                .WithMessage("Data rozpoczęcia nie może być późniejsza niż zakończenia");
        }
    }
}
