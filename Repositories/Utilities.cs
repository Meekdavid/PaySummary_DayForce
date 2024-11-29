using PaySummary_DayForce.Interfaces;
using PaySummary_DayForce.Utilities.ConfigSettings;
using PaySummary_DayForce.Utilities.Models;

namespace PaySummary_DayForce.Repositories
{
    public class Utilities : IUtilities
    {
        public async Task<decimal> DetermineMaximumRate(Timecard_Record timeCardRecord, Rate_Table_Row applicableRate)
        {
            return Math.Max(timeCardRecord.Rate, applicableRate?.Hourly_Rate ?? timeCardRecord.Rate);
        }

        public async Task<Rate_Table_Row> GetApplicableRate(List<Rate_Table_Row> rateTable, Timecard_Record timeCardFile)
        {
            return rateTable.FirstOrDefault(r =>
                            r.Job == timeCardFile.Job_Worked &&
                            r.Dept == timeCardFile.Dept_Worked &&
                            timeCardFile.Date_Worked >= r.Effective_Start &&
                            timeCardFile.Date_Worked <= r.Effective_End);
        }

        public async Task<decimal> GetEarningCodeMultiplier(Timecard_Record timeCardRecord)
        {
            return timeCardRecord.Earnings_Code switch
            {
                "Regular" => ConfigSettings.ConfigParameter.RegularMultiplier,
                "Overtime" => ConfigSettings.ConfigParameter.OvertimeMultiplier,
                "Double time" => ConfigSettings.ConfigParameter.DoubleTimeMultiplier,
                _ => 1.0m
            };
        }
    }
}
