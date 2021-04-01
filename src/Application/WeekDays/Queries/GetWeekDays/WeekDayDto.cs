using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeekDays.Queries.GetWeekDays
{
    public class WeekDayDto : IMapFrom<WeekDay>
    {
        public WeekDayDto()
        {

        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Colour { get; set; }

        public IList<SubjectDto> Subjects { get; set; }
    }
}
