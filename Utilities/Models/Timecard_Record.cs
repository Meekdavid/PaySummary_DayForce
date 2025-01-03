﻿namespace PaySummary_DayForce.Utilities.Models
{
    public class Timecard_Record
    {
        public string Employee_Name { get; set; }
        public string Employee_Number { get; set; }
        public DateTime Date_Worked { get; set; }
        public string Earnings_Code { get; set; }
        public string Job_Worked { get; set; }
        public string Dept_Worked { get; set; }
        public decimal Hours { get; set; }
        public decimal Rate { get; set; }
        public decimal Bonus { get; set; }
    }
}
