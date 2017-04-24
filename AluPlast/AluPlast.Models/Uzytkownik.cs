using System;
using System.Collections.Generic;

namespace AluPlast.Models
{
    public class Uzytkownik : Base, IComparable<Uzytkownik>
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string FullName => $"{LastName} {FirstName}";
        public List<Uprawnienie> Uprawnienia { get; set; }
        public Terminal Terminal { get; set; }
        
        public int CompareTo(Uzytkownik user)
        {
            return user.LastName.CompareTo(LastName);
        }
        public override bool Equals(object obj)
        {
            var uz = obj as Uzytkownik;
            return uz?.Id == Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        //public override string ToString() => NickName;
    }
}
