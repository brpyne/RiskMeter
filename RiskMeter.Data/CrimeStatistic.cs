//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiskMeter.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CrimeStatistic
    {
        public int CrimeStatisticId { get; set; }
        public int CityId { get; set; }
        public int Year { get; set; }
        public int MurderCount { get; set; }
        public int RapeCount { get; set; }
        public int RobberyCount { get; set; }
        public int AssaultCount { get; set; }
        public int BurglaryCount { get; set; }
        public int TheftCount { get; set; }
        public int AutoTheftCount { get; set; }
        public int ArsonCount { get; set; }
        public int Population { get; set; }
    
        public virtual City City { get; set; }
    }
}