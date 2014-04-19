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
            _connection.CreateTable<CrimeStatisticsModel>();
        }

        //public List<UserProfileModel> GetProfileByUserName(string email)
        //{
        //    return _connection.Table<UserProfileModel>()
        //            .Where(x => x.Email == email)
        //            .ToList();
        //}

        //public List<UserProfileModel> GetProfilesByTeamLeader(string parentEmail)
        //{
        //    return _connection.Table<UserProfileModel>()
        //            .Where(x => x.ParentUserName == parentEmail)
        //            .ToList();
        //}

        //public void Insert(UserProfileModel profile)
        //{
        //    _connection.InsertOrReplace(profile);
        //    //_connection.Insert(profile);
        //}

        //public void Insert(List<UserProfileModel> userProfiles, string parentEmail)
        //{
        //    foreach (var userProfile in userProfiles)
        //    {
        //        userProfile.ParentUserName = parentEmail;
        //        Insert(userProfile);
        //    }
        //}

        //public void Update(UserProfileModel profile)
        //{
        //    _connection.Update(profile);
        //}

        //public void TruncateTable()
        //{
        //    _connection.Execute("DELETE FROM UserProfileModel");
        //}

        //public void Delete(UserProfileModel profile)
        //{
        //    _connection.Delete(profile);
        //}

        //public int Count
        //{
        //    get
        //    {
        //        return _connection.Table<UserProfileModel>().Count();
        //    }
        //}
    }

    //	public interface IUserProfileModelDataService
    //	{
    //		int Count { get; }
    //		List<UserProfileModel> GetProfileByUserName(string userName);
    //	}
    //
    //	public class UserProfileModelDataService : IUserProfileModelDataService, DataService<UserProfileModel>
    //	{
    //		public UserProfileModelDataService(ISQLiteConnectionFactory factory) : base(factory)
    //		{
    //			_connection.CreateTable<UserProfileModel>();
    //		}
    //
    //		public int Count
    //		{
    //			get { return _connection.Table<UserProfileModel>().Count(); }
    //		}
    //
    //		public List<UserProfileModel> GetProfileByUserName(string userName)
    //		{
    //			return _connection.Table<UserProfileModel>()
    //					.Where(x => x.UserName == userName)
    //					.ToList();
    //		}
    //	}
}