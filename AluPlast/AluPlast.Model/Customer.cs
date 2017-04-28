using AluPlast.Model.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Model
{
    [Validator(typeof(CustomerValidator))]
    public class Customer : Base
    {
        #region FirstName

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                _FirstName = value;

                OnPropertyChanged();
            }
        }

        #endregion

        #region Number

        private int _Number;
        public int Number
        {
            get
            {
                return _Number;
            }

            set
            {
                _Number = value;

                OnPropertyChanged();
            }
        }

        #endregion
    }
}
