using PaySummary_DayForce.Utilities.Models;

namespace PaySummary_DayForce.Interfaces
{
    public interface IUtilities
    {
        Task<Rate_Table_Row> GetApplicableRate(List<Rate_Table_Row> rateTable, Timecard_Record timeCardFile);
        Task<decimal> DetermineMaximumRate(Timecard_Record timeCardFile, Rate_Table_Row rateTable);
        Task<decimal> GetEarningCodeMultiplier(Timecard_Record timeCardFile);
    }
}
