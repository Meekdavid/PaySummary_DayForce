using Microsoft.AspNetCore.Mvc;
using PaySummary_DayForce.Interfaces;

namespace PaySummary_DayForce.Controllers
{
    public class PaySummaryController : ControllerBase
    {
        private readonly IPayrollCalculator _payrollCalculator;
        private readonly IDatabaseHandler _data;
        private readonly ILogger<PaySummaryController> _logger;
        public PaySummaryController(IPayrollCalculator payrollCalculator, IDatabaseHandler data, ILogger<PaySummaryController> logger)
        {
            _payrollCalculator = payrollCalculator;
            _data = data;
            _logger = logger;
        }

        [HttpGet("GetPaySummary")]
        public async Task<IActionResult> SummarizePayInfo()
        {
            try
            {
                // Retrieve the rate table
                var rateTable = await _data.RetrieveRates(false);

                // Retrieve the time card file
                var timeCardFile = await _data.RetrieveTimeCardFiles(false);

                // Calculate the summary of the pay info
                var summary = await _payrollCalculator.Summarize_Pay_Info(timeCardFile, rateTable);

                // Return the result as a response
                return Ok(summary);
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured while retreiving rate from DB", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
