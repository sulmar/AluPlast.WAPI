using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Interfaces;
using AluPlast.Models;

namespace AluPlast.ControlLoader.MockService
{
    public class DbItemsService : IItemsService
    {
        //private ObservableCollection<PaletyRodzaj> _rodzajePaletList = new ObservableCollection<PaletyRodzaj>();
        private readonly List<JednostkaLogistyczna> _items;

        public DbItemsService()
        {
            _items = new List<JednostkaLogistyczna>
            {
                new JednostkaLogistyczna
                {
                    Id = 338692,
                    EtykietaPalety = new EtykietaPalety
                    {
                        EtykietaType = EtykietaType.SZY,
                        Number = 777777
                    },
                    SelectedPaletyRodzaj = new PaletyRodzaj
                    {
                        Id = 1,
                        Nazwa = "PALDrewnianaDuża",
                    },
                    TwrKod = "140001",
                    Customer = new Customer
                    {
                        Akronim = "Adams",
                        GidNumer = 11,
                        Adres = new AdresKontrahenta
                        {
                            Akronim = "Adams",
                            TypAdresu = TypAdresu.Główny,
                            Numer = 11
                        }
                    },
                    PalId = 123456,
                    CheckedStatus = CheckedStatus.Unchecked,
                    RodzajePalet = GetRodzajePalet()
                },

                new JednostkaLogistyczna
                {
                    Id = 338693,
                    EtykietaPalety = new EtykietaPalety
                    {
                        EtykietaType = EtykietaType.SZP,
                        Number = 8888888
                    },
                    SelectedPaletyRodzaj = new PaletyRodzaj
                    {
                        Id = 2,
                        Nazwa = "PALDrewnianaMała",
                    },
                    TwrKod = "140020",
                    Customer = new Customer
                    {
                        Akronim = "Ekookna-Kornice",
                        GidNumer = 21,
                        Adres = new AdresKontrahenta
                        {
                            Akronim = "Ekookna-Kornice",
                            TypAdresu = TypAdresu.Wysyłkowy,
                            Numer = 21
                        }
                    },
                    PalId = 456789,
                    CheckedStatus = CheckedStatus.Checked,
                    RodzajePalet = GetRodzajePalet()
                },
                new JednostkaLogistyczna
                {
                    Id = 338694,
                    EtykietaPalety = new EtykietaPalety
                    {
                        EtykietaType = EtykietaType.PAL,
                        Number = 999999
                    },
                    SelectedPaletyRodzaj = new PaletyRodzaj
                    {
                        Id = 3,
                        Nazwa = "PALMetalowaDuża",
                    },
                    TwrKod = "150003",
                    Customer = new Customer
                    {
                        Akronim = "Okoplast",
                        GidNumer = 31,
                        Adres = new AdresKontrahenta
                        {
                            Akronim = "Okoplast",
                            TypAdresu = TypAdresu.Główny,
                            Numer = 31
                        }
                    },
                    PalId = 123458,
                    CheckedStatus = CheckedStatus.Unchecked,
                    RodzajePalet = GetRodzajePalet()
                }
            };
        }

        private ObservableCollection<PaletyRodzaj> GetRodzajePalet()
        {
            var rodzajP = new DbRodzajePaletService();
            //_rodzajePaletList = rodzajP.RodzajePalet;
            return rodzajP.RodzajePalet;
        }

        public Task<IList<JednostkaLogistyczna>> GetAsync(int loadId)
        {
            return Task.Run(() => Get(loadId));
        }

        public IList<JednostkaLogistyczna> Get(int loadId)
        {
           return _items;
        }

        public async Task<string> GetTwrKodAsync(int palId)
        {
            switch(palId)
            {
                case 123456:
                {
                    return "140001";
                }
                case 456789:
                {
                    return "140020";
                }
                case 123458:
                {
                    return "150003";
                }
                default:
                {
                    return "100000";
                }
            }
        }

        public async Task Update(JednostkaLogistyczna item)
        {
            
        }

        public async Task AddAsync(int loadId, JednostkaLogistyczna item)
        {
            _items.Add(item);
            //item.Id = 338700;
            //item.Customer.Adres.Numer = 41;

        }

        public async Task Remove(int itemId, string kontroler)
        {
            var item = _items.FirstOrDefault(x => x.Id == itemId);
            _items.Remove(item);
        }

        public Task<IList<JednostkaLogistyczna>> GetAsync()
        {
            return Task<IList<JednostkaLogistyczna>>.Factory.StartNew(()=>_items);
        }

        Task<JednostkaLogistyczna> IService<JednostkaLogistyczna, int>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(JednostkaLogistyczna item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(JednostkaLogistyczna item)
        {
            throw new NotImplementedException();
        }
    }
}
