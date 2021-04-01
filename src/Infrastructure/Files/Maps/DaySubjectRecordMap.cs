using CleanArchitecture.Application.WeekDays.Queries.ExportDaySubjects;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
    public class DaySubjectRecordMap : ClassMap<DaySubjectFileRecord>
    {
        public DaySubjectRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
