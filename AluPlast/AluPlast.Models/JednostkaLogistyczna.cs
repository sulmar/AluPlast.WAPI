using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AluPlast.Models
{
    public class JednostkaLogistyczna : Base, IComparable<JednostkaLogistyczna>
    {
        private CheckedStatus _checkedStatus;
        private int _palId;
        private PaletyRodzaj _selectedPaletyRodzaj;

        public int Id { get; set; }

        public EtykietaPalety EtykietaPalety { get; set; }
        public Customer Customer { get; set; }

        public int PalId
        {
            get { return _palId; }
            set
            {
                _palId = value;
                OnPropertyChanged();
            }
        }

        public PaletyRodzaj SelectedPaletyRodzaj
        {
            get { return _selectedPaletyRodzaj; }
            set
            {
                if (object.Equals(_selectedPaletyRodzaj, value)) return;
                _selectedPaletyRodzaj = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PaletyRodzaj> RodzajePalet { get; set; }
        //public IList<RodzajPalety> RodzajePalet => Enum.GetValues(typeof(RodzajPalety)).Cast<RodzajPalety>().ToList();

        public CheckedStatus CheckedStatus
        {
            get
            {
                return _checkedStatus;
            }

            set
            {
                _checkedStatus = value;
                OnPropertyChanged();
            }
        }
        public string FullName => EtykietaPalety?.ToString();
        public string TwrKod { get; set; }
        public string EtykietaTwrKodColumn => (EtykietaPalety?.EtykietaType ?? 0) == EtykietaType.PAL ? TwrKod : FullName;

        public int CompareTo(JednostkaLogistyczna other)
        {
            return Id == other.Id? 0 : 1;
        }
    }
}
