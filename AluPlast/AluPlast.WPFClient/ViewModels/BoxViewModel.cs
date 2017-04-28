using AluPlast.Model;
using AluPlast.WPFClient.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AluPlast.WPFClient.ViewModels
{
    public class BoxViewModel
    {
        public Customer Customer { get; set; }


        private ICommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new RelayCommand(p => Load());

                }

                return _LoadCommand;
            }
            
        }
       

        public void Load()
        {

        }

        public bool CanLoad()
        {
            return true;
        }

        public void Run()
        {

        }

        public bool CanRun => true;

        public BoxViewModel()
        {
            Customer = new Customer();

        }
    }
}
