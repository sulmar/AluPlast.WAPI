using System;
using System.Text.RegularExpressions;
using AluPlast.Models.Method;

namespace AluPlast.Models
{
    public class Lokalizacja
    {
        private const int MaxAddressLen = 8;
        private string _addressStream;

        public string Delimeter { get; set; } = "-";

        public int MgAId { get; set; }
        public string ObszarKod { get; set; }
        public string Segment1 { get; set; }
        public string Segment2 { get; set; }
        public string Adres
        {
            get { return $"{ObszarKod}{Delimeter}{Segment1}{Delimeter}{Segment2}"; }
            set { }
        }

        public Lokalizacja(string obszarKod, string segment1, string segment2, int mgAId = 0)
        {
            if (!IsProperKod(obszarKod) || !IsProperSegment(segment1) || !IsProperSegment(segment2))
            {
                var qwe = obszarKod + segment1 + segment2;
                if (!string.IsNullOrEmpty(qwe)) throw new ArgumentOutOfRangeException();
            }
            MgAId = mgAId;
            ObszarKod = obszarKod;
            Segment1 = segment1;
            Segment2 = segment2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lokalizacjaString">String lokalizacji skladajacy sie z czesci:2-znakowego obszaru, 3-znakowego adresu1 i 3-znakowego adresu2. Można podać stringa z delimeterem ("-"," ","_","/")</param>
        /// <param name="mgAId"></param>
        public Lokalizacja(string lokalizacjaString, int mgAId = 0)
        {
            if (lokalizacjaString.Equals("--"))
            {
                ObszarKod = string.Empty;
                Segment1 = string.Empty;
                Segment2 = string.Empty;
                return;
            }
            var lokalizacjaArray = lokalizacjaString.Split('-', ' ', '/', '\\', ',');

            if (lokalizacjaArray.Length != 3) throw new ArgumentOutOfRangeException();

            if (!IsProperKod(lokalizacjaArray[0]) || !IsProperSegment(lokalizacjaArray[1]) || !IsProperSegment(lokalizacjaArray[2]))
            {
                throw new ArgumentOutOfRangeException("Wpisano błędną lokalizację 'Do'.");
            }
            MgAId = mgAId;
            ObszarKod = lokalizacjaArray[0];
            Segment1 = lokalizacjaArray[1];
            Segment2 = lokalizacjaArray[2];
        }

        public void AppendAddress(string key)
        {
            if (_addressStream.Length == MaxAddressLen) return;
            _addressStream += key;
            AdresStreamToAdres();
        }

        public void BackspaceAddress()
        {
            char myChar;
            if (_addressStream.Length < 1) return;
            if(!char.TryParse("_", out myChar)) return;
            _addressStream = _addressStream.ReplaceAt(_addressStream.Length - 1, myChar); // Parse("_"));
            AdresStreamToAdres();
            _addressStream = _addressStream.RemoveLastChar();
        }

        private void AdresStreamToAdres()
        {
            var characters = _addressStream.ToCharArray();
            for (var i = 0; i < characters.Length; i++)
            {
                if (IsInObszarKodAdresRange(i)) ObszarKod = ObszarKod.ReplaceAt(i, characters[i]);
                if (IsInSegment1AdresRange(i)) Segment1 = Segment1.ReplaceAt(i - 2, characters[i]);
                if (IsInSegment2AdresRange(i)) Segment2 = Segment2.ReplaceAt(i - 5, characters[i]);
            }
        }

        private static bool IsInObszarKodAdresRange(int i)
        {
            return i < 2;
        }

        private static bool IsInSegment1AdresRange(int i)
        {
            return i >= 2 & i < 5;
        }
        private static bool IsInSegment2AdresRange(int i)
        {
            return i >= 5 & i < 8;
        }

        public Lokalizacja()
        {
            ObszarKod = "__";
            Segment1 = "___";
            Segment2 = "___";
            _addressStream = string.Empty;
        }



        public bool IsProperKod(string obszarKod)
        {
            return obszarKod == "-" || Regex.IsMatch(obszarKod, "^[0-9][0-9]$");
        }

        public bool IsProperSegment(string segment)
        {
            return segment == "-" || Regex.IsMatch(segment, "^[0-9][0-9][0-9]$");
        }

        public override string ToString()
        {
            return Adres;
        }
    }
}