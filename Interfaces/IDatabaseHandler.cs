using PaySummary_DayForce.Utilities.Models;

namespace PaySummary_DayForce.Interfaces
{
    public interface IDatabaseHandler
    {
        Task<List<Rate_Table_Row>> RetrieveRates(bool UseDBForRetrieval);
        Task<List<Timecard_Record>> RetrieveTimeCardFiles(bool UseDBForRetrieval);
    }
}
