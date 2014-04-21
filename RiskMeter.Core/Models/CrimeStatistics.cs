namespace RiskMeter.Core.Models
{
    public class CrimeStatistics
    {
        public string City { get; set; }
        public string State { get; set; }
        public int Year { get; set; }

        public int MurderCount { get; set; }
        public int RapeCount { get; set; }
        public int RobberyCount { get; set; }
        public int AssaultCount { get; set; }
        public int BurglaryCount { get; set; }
        public int TheftCount { get; set; }
        public int AutoTheftCount { get; set; }
        public int ArsonCount { get; set; }
    }
}