using PaySummary_DayForce.Utilities.Models;

namespace PaySummary_DayForce.Utilities.ConfigSettings.ConfigModels
{
    public class ConfigParameters
    {
        public bool UseDBForRetrieval { get; set; }
        public decimal RegularMultiplier { get; set; }
        public decimal OvertimeMultiplier { get; set; }
        public decimal DoubleTimeMultiplier { get; set; }
        public Seeddata SeedData { get; set; }
    }
    

    public class Seeddata
    {
        public List<Rate_Table_Row> RateTableRows { get; set; }
        public List<Timecard_Record> TimecardRecords { get; set; }
    }

    //public class Rate_Table_Row
    //{
    //    public int Id { get; set; }
    //    public string Job { get; set; }
    //    public string Dept { get; set; }
    //    public DateTime EffectiveStart { get; set; }
    //    public DateTime EffectiveEnd { get; set; }
    //    public float HourlyRate { get; set; }
    //}

    //public class Timecard_Record
    //{
    //    public int Id { get; set; }
    //    public string EmployeeName { get; set; }
    //    public string EmployeeNumber { get; set; }
    //    public DateTime DateWorked { get; set; }
    //    public string EarningsCode { get; set; }
    //    public string JobWorked { get; set; }
    //    public string DeptWorked { get; set; }
    //    public int Hours { get; set; }
    //    public float Rate { get; set; }
    //    public int Bonus { get; set; }
    //}

}
