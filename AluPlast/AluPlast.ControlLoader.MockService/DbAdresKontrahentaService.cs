using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Interfaces;
using AluPlast.Models;

namespace AluPlast.ControlLoader.MockService
{
    public class DbAdresKontrahentaService : IAdresKontrahentaService
    {
        public ObservableCollection<AdresKontrahenta> Get()
        {
            var adresy = new ObservableCollection<AdresKontrahenta>();


            var adres = new AdresKontrahenta();
            adres.Numer = 11;
            adres.TypAdresu = TypAdresu.Główny;
            adres.Akronim = "Adams";
            adresy.Add(adres);

            var adres2 = new AdresKontrahenta();
            adres2.Numer = 21;
            adres2.TypAdresu = TypAdresu.Wysyłkowy;
            adres2.Akronim = "Ekookna-Kornice";
            adresy.Add(adres2);

            var adres3 = new AdresKontrahenta();
            adres3.Numer = 31;
            adres3.TypAdresu = TypAdresu.Główny;
            adres3.Akronim = "Oknoplast";
            adresy.Add(adres3);

            return adresy;
        }



        public Task<ObservableCollection<AdresKontrahenta>> GetAsync()
        {
            return Task.Run(() => Get());
        }


        public async Task AddAsync(AdresKontrahenta adres)
        {
            
             await Task.Run(() => adres.Numer = 41);
                   
        }
    }
}
