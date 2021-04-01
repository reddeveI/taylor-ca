using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeekDays.Queries.ExportDaySubjects
{
    public class DaySubjectFileRecord : IMapFrom<Subject>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
