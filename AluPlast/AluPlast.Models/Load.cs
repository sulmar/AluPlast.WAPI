using AluPlast.Models.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AluPlast.Models
{
    [Validator(typeof(LoadValidator))]
    public class Load : Base
    {
        public int Id { get; set; }

        public DateTime LoadDate { get; set; }

        public Vehicle Vehicle { get; set; }

        public Uzytkownik Kontroler { get; set; }

        public Customer Spedition { get; set; }

        private IList<JednostkaLogistyczna> _Items = new ObservableCollection<JednostkaLogistyczna>();

        public IList<JednostkaLogistyczna> Items
        {
            get
            {
                return _Items;
            }

            set
            {
                OnItemsChanging();

                _Items = value;

                OnItemsChanged();

                OnPropertyChanged();
                OnPropertyChanged(nameof(Progress));
                OnPropertyChanged(nameof(CheckedItemsCount));
                OnPropertyChanged(nameof(NotCanceledCount));


            }
        }

        private void OnItemsChanging()
        {
            foreach (var item in this.Items)
            {
                item.PropertyChanged -= Item_PropertyChanged;
            }
        }
        private void OnItemsChanged()
        {
            foreach (var item in this.Items)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }

        public IList<Photo> Photos { get; set; }

        public LoadStatus LoadStatus { get; set; }

        public int CheckedItemsCount => Items.Count(p => p.CheckedStatus == CheckedStatus.Checked);

        public int NotCanceledCount => Items.Count(p => p.CheckedStatus != CheckedStatus.Cancelled);

        public double Progress =>  NotCanceledCount == 0 ? 0 : (double) decimal.Divide(CheckedItemsCount, NotCanceledCount);

        public bool CanAccept => Items.All(p => p.CheckedStatus != CheckedStatus.Unchecked);

        public Load()
        {
           
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(JednostkaLogistyczna.CheckedStatus))
            {
                OnPropertyChanged(nameof(CanAccept));
            }
        }
    }
}
