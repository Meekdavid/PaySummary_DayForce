using AutoMapper;
using PaySummary_DayForce.Utilities.ConfigSettings.ConfigModels;
using PaySummary_DayForce.Utilities.Database;
using PaySummary_DayForce.Utilities.Models;

namespace PaySummary_DayForce.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<List<Rate_Table_Row>, List<RateTableRowTable>>().ReverseMap();
            //CreateMap<List<List<Timecard_Record>>, List<TimecardRecordTable>>().ReverseMap();
            CreateMap<Rate_Table_Row, RateTableRowTable>().ReverseMap();
            CreateMap<Timecard_Record, TimecardRecordTable>().ReverseMap();

        }
    }
}
