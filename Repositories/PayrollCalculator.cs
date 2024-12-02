using PaySummary_DayForce.Interfaces;
using PaySummary_DayForce.Utilities.ConfigSettings;
using PaySummary_DayForce.Utilities.Models;

namespace PaySummary_DayForce.Repositories
{
    public class PayrollCalculator : IPayrollCalculator
    {
        private readonly ILogger<PayrollCalculator> _logger;
        private readonly IUtilities _Utilities;
        public PayrollCalculator(ILogger<PayrollCalculator> logger, IUtilities utilities)
        {
            _logger = logger;
            _Utilities = utilities;
        }
        public async Task<List<Pay_Summary_Record>> Summarize_Pay_Info(List<Timecard_Record> timecard, List<Rate_Table_Row> rateTable)
        {
            var result = new List<Pay_Summary_Record>();

            try
            {
                // Group the time card file records by employee, earning code, job worked and department
                foreach (var group in timecard.GroupBy(t => new { t.Employee_Number, t.Earnings_Code, t.Job_Worked, t.Dept_Worked }))
                {
                    var employeeRecords = group.ToList();// Employee records with distinctive earning code and employee number

                    decimal totalHours = 0;
                    decimal totalPay = 0;
                    decimal effectiveRate = 0;
                    string job = string.Empty;
                    string dept = string.Empty;

                    foreach (var record in employeeRecords)
                    {
                        // Find applicable rate from the rate table
                        var applicableRate = await _Utilities.GetApplicableRate(rateTable, record);

                        // Determine the higher rate
                        effectiveRate = await _Utilities.DetermineMaximumRate(record, applicableRate);

                        // Determine Multiplier based on earnings code
                        decimal multiplier = await _Utilities.GetEarningCodeMultiplier(record);

                        // Calculate pay for this record
                        decimal pay = (record.Hours * effectiveRate * multiplier) + record.Bonus;
                        totalHours += record.Hours;
                        totalPay += pay;
                    }

                    // Add summary record for the employee
                    result.Add(new Pay_Summary_Record
                    {
                        Employee_Name = group.Key.Employee_Name,
                        Employee_Number = group.Key.Employee_Number,
                        Earnings_Code = group.Key.Earnings_Code,
                        Total_Hours = totalHours,
                        Total_Pay_Amount = totalPay,
                        Rate_of_Pay = effectiveRate,
                        Job = group.Key.Job_Worked,
                        Dept = group.Key.Dept_Worked
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured while calculating payroll summary", ex);
            }

            return result;
        }

        //public async Task<List<Pay_Summary_Record>> Summarize_Pay_Info(List<Timecard_Record> timecard, List<Rate_Table_Row> rateTable)
        //{
        //    var result = new List<Pay_Summary_Record>();

        //    try
        //    {
        //        // Group by Employee Name and Number
        //        foreach (var group in timecard.GroupBy(t => new { t.Employee_Name, t.Employee_Number }))
        //        {
        //            var employeeRecords = group.ToList();

        //            decimal totalHours = 0;
        //            decimal totalPay = 0;
        //            decimal highestRate = 0;
        //            string job = string.Empty;
        //            string dept = string.Empty;

        //            foreach (var record in employeeRecords)
        //            {
        //                // Find applicable rate from the rate table
        //                var applicableRate = rateTable.FirstOrDefault(r =>
        //                    r.Job == record.Job_Worked &&
        //                    r.Dept == record.Dept_Worked &&
        //                    record.Date_Worked >= r.Effective_Start &&
        //                    record.Date_Worked <= r.Effective_End);

        //                // Determine the higher rate
        //                decimal finalRate = Math.Max(record.Rate, applicableRate?.Hourly_Rate ?? record.Rate);
        //                highestRate = Math.Max(highestRate, finalRate);
        //                job = record.Job_Worked;
        //                dept = record.Dept_Worked;

        //                // Calculate multiplier based on earnings code
        //                decimal multiplier = record.Earnings_Code switch
        //                {
        //                    "Regular" => ConfigSettings.ConfigParameter.RegularMultiplier,
        //                    "Overtime" => ConfigSettings.ConfigParameter.OvertimeMultiplier,
        //                    "Double time" => ConfigSettings.ConfigParameter.DoubleTimeMultiplier,
        //                    _ => 1.0m
        //                };

        //                // Calculate pay for this record
        //                decimal pay = (record.Hours * finalRate * multiplier) + record.Bonus;
        //                totalHours += record.Hours;
        //                totalPay += pay;
        //            }

        //            // Add summary record for the employee
        //            result.Add(new Pay_Summary_Record
        //            {
        //                Employee_Name = group.Key.Employee_Name,
        //                Employee_Number = group.Key.Employee_Number,
        //                Total_Hours = totalHours,
        //                Total_Pay_Amount = totalPay,
        //                Rate_of_Pay = highestRate,
        //                Job = job,
        //                Dept = dept
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("An exception occurred while retrieving rate from DB", ex);
        //    }

        //    return result;
        //}

    }
}
