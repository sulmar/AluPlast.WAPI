using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AluPlast.Models
{

    public abstract class GenericBase<TKey>
    {
        public virtual TKey Id { get; set; }
    }

    public abstract class Base : GenericBase<int>, INotifyPropertyChanged, INotifyCollectionChanged, INotifyDataErrorInfo
    {
        private IValidator Validator => new AttributedValidatorFactory().GetValidator(GetType());


        public Base()
        {
            this.PropertyChanged += Base_PropertyChanged;
        }

        private void Base_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            GetErrors(e.PropertyName);
        }

        #region INotifyDataErrorInfo
        public bool HasErrors => Validator?.Validate(this).IsValid ?? true;


        public IEnumerable GetErrors(string propertyName)
        {
            var properties = new System.Collections.Generic.List<string> { propertyName };

            if (Validator == null) return string.Empty;

            var results = Validator.Validate
                (new ValidationContext(this, new PropertyChain(), new MemberNameValidatorSelector(properties)));

            return results.Errors;        
        }

        #endregion


        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void OnPropertyChanged([CallerMemberName] string propname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        public void OnCollectionChanged(object item)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

     
    }
}
