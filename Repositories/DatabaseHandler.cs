using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaySummary_DayForce.Interfaces;
using PaySummary_DayForce.Utilities.ConfigSettings;
using PaySummary_DayForce.Utilities.Database;
using PaySummary_DayForce.Utilities.Models;

namespace PaySummary_DayForce.Repositories
{
    public class DatabaseHandler : IDatabaseHandler
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<DatabaseHandler> _logger;
        private readonly IMapper _mapper;
        public DatabaseHandler(ApplicationDbContext db, ILogger<DatabaseHandler> logger, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<Rate_Table_Row>> RetrieveRates(bool UseDBForRetrieval)
        {
            var rateRecords = new List<Rate_Table_Row>();
            try
            {
                if (UseDBForRetrieval)
                {
                    // Fetch records from SQL DB
                    var databaseRate = await _db.RateTableRows.ToListAsync();

                    rateRecords = _mapper.Map<List<Rate_Table_Row>>(databaseRate);
                }
                else
                {
                    // Fetch records from Config
                    rateRecords = ConfigSettings.ConfigParameter.SeedData.RateTableRows;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured while retreiving rate from DB", ex);
            }

            return rateRecords;
        }

        public async Task<List<Timecard_Record>> RetrieveTimeCardFiles(bool UseDBForRetrieval)
        {
            var timeCardRecords = new List<Timecard_Record>();
            try
            {
                if (UseDBForRetrieval)
                {
                    // Fetch records from SQL DB
                    var databaseRate = await _db.TimecardRecords.ToListAsync();

                    timeCardRecords = _mapper.Map<List<Timecard_Record>>(databaseRate);
                }
                else
                {
                    // Fetch records from Config
                    timeCardRecords = ConfigSettings.ConfigParameter.SeedData.TimecardRecords;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured while retreiving TimeCard File from DB", ex);
            }

            return timeCardRecords;
        }
    }
}
