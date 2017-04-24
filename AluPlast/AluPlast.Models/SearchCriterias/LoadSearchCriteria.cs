using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Models.SearchCriterias
{

    public class PeriodSearchCriteria : Base
    {
        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }
    }


    public class LoadSearchCriteria : PeriodSearchCriteria
    {
        public LoadStatus? Status { get; set; }
    }
}
