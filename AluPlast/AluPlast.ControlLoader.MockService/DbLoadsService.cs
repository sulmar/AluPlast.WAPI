using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AluPlast.Models;
using AluPlast.Models.SearchCriterias;

namespace AluPlast.ControlLoader.MockService
{
    public class DbLoadsService : ILoadsService
    {
        private static readonly List<Load> _zaladunki = new List<Load>
        {
            new Load()
            {
                Id = 1,
                LoadDate = new DateTime(2017, 03, 30),
                Vehicle = new Vehicle
                {
                    DriverName = "Kowalski",
                    RegistrationNumber = "PZ 235689"
                },
                Spedition = new Customer
                {
                    GidNumer = 56,
                    Akronim = "Pacztex"
                }},

            new Load()
            {
                Id = 2,
                LoadDate = new DateTime(2017, 03, 30),
                Vehicle = new Vehicle
                {
                    DriverName = "Szymkowiak",
                    RegistrationNumber = "PO 4567896"
                },
                Spedition = new Customer
                {
                    GidNumer = 78,
                    Akronim = "Szybpol"
                }},
            new Load()
            {
                Id = 3,
                LoadDate = new DateTime(2017, 03, 30),
                Vehicle = new Vehicle
                {
                    DriverName = "Pospieszalski",
                    RegistrationNumber = "WW 954763"
                },
                Spedition = new Customer
                {
                    GidNumer = 96,
                    Akronim = "Tirex"
                }},
        };

        public IList<Load> Get(DateTime date)
        {
            return _zaladunki;
        }

        public async Task<List<Load>> GetAsync(DateTime date)
        {
            return await Task.Factory.StartNew(() => _zaladunki);
        }

        public async Task Confirm(Load load)
        {
            load.LoadStatus = LoadStatus.Done;
            //var firstOrDefault = _zaladunki.FirstOrDefault(x => x.Id == load.Id);
            //if (firstOrDefault != null)
            //    firstOrDefault.LoadStatus = LoadStatus.Done;
        }

        public void Canceled(int loadId, Uzytkownik @operator)
        {
            var firstOrDefault = _zaladunki.FirstOrDefault(x => x.Id == loadId);
            if (firstOrDefault != null)
                firstOrDefault.LoadStatus = LoadStatus.Canceled;
        }

        public Task UpdateAsync(Load load)
        {
            return null;
        }

        public IList<Load> Get(LoadSearchCriteria criteria)
        {

            var loads = _zaladunki
                .Where(l => l.LoadDate >= criteria.BeginDate)
                .Where(l => l.LoadDate <= criteria.EndDate)
                .Where(l => !criteria.Status.HasValue || l.LoadStatus == criteria.Status.Value)
                .ToList();

            return loads;
        }

        public Load Get(int id)
        {
            return _zaladunki.SingleOrDefault(z => z.Id == id);
        }

        public Task AddAsync(Load load)
        {
            return Task.Run(() => Add(load));
        }

        private void Add(Load load)
        {
            var loadId = _zaladunki.Max(z => z.Id);
            load.Id = ++loadId;

            _zaladunki.Add(load);
        }

    }
 }
