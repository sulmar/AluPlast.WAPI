using System.Collections.ObjectModel;
using System.Linq;

namespace AluPlast.Models
{
    public class Operator
    {
        public string Akronim { get; set; }
        public string Haslo { get; set; }
        public bool IsCorrect(Operator operWybrany, ObservableCollection<Operator> operatorzy)
        {
            return operatorzy.Any(oper => oper.Akronim == operWybrany.Akronim & oper.Haslo == operWybrany.Haslo);
        }
    }
}
