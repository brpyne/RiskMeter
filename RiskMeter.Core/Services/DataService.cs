using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using System;
using RiskMeter.Core.Models;

namespace RiskMeter.Core.Services
{
    public class DataService
    {
        private readonly ISQLiteConnection _connection;

        public DataService(ISQLiteConnectionFactory factory)
        {
            _connection = factory.Create("RiskMeter.sql");
            _connection.CreateTable<CrimeStatistic>();
        }
    }

/*
 * public class DataService : IDataService
    {
        private readonly ISQLiteConnection _connection;

        public DataService(ISQLiteConnectionFactory factory)
        {
            _connection = factory.Create("one.sql");
            _connection.CreateTable<Kitten>();
        }

        public List<Kitten> KittensMatching(string nameFilter)
        {
            return _connection.Table<Kitten>()
                              .OrderBy(x => x.Price)
                              .Where(x => x.Name.Contains(nameFilter))
                              .ToList();
        }

        public void Insert(Kitten kitten)
        {
            _connection.Insert(kitten);
        }

        public void Update(Kitten kitten)
        {
            _connection.Update(kitten);
        }

        public void Delete(Kitten kitten)
        {
            _connection.Delete(kitten);
        }

        public int Count
        {
            get
            {
                return _connection.Table<Kitten>().Count();
            }
        }
    }
 */
}