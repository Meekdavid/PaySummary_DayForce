using PaySummary_DayForce.Utilities.Models;

namespace PaySummary_DayForce.Interfaces
{
    public interface IPayrollCalculator
    {
        Task<List<Pay_Summary_Record>> Summarize_Pay_Info(List<Timecard_Record> timecard, List<Rate_Table_Row> rateTable);
    }
}
