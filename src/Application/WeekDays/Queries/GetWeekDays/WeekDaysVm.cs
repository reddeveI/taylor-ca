using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeekDays.Queries.GetWeekDays
{
    public class WeekDaysVm
    {
        public IList<PriorityLevelDto> PriorityLevels { get; set; }

        public IList<WeekDayDto> Days { get; set; }
    }
}
