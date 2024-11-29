namespace PaySummary_DayForce.Utilities.Models
{
    public class Rate_Table_Row
    {
        public string Job { get; set; }
        public string Dept { get; set; }
        public DateTime Effective_Start { get; set; }
        public DateTime Effective_End { get; set; }
        public decimal Hourly_Rate { get; set; }
    }
}
