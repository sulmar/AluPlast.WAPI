using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Model
{
    public abstract class Base : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private IValidator Validator => new AttributedValidatorFactory().GetValidator(GetType());


        #region INotifyDataErrorInfo
        public bool HasErrors => Validator?.Validate(this).IsValid ?? true;

        public Base()
        {
            this.PropertyChanged += Base_PropertyChanged;

        }

        private void Base_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            GetErrors(e.PropertyName);
        }

        public IEnumerable GetErrors(string propertyName)
        {
            var properties = new System.Collections.Generic.List<string> { propertyName };

            if (Validator == null) return string.Empty;

            var results = Validator.Validate
                (new ValidationContext(this, new PropertyChain(), new MemberNameValidatorSelector(properties)));


            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));


            return results.Errors;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

     

        public void OnPropertyChanged([CallerMemberName] string propname="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        #endregion


    }
}
