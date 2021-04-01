using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeekDays.Queries.GetWeekDays
{
    public class SubjectDto : IMapFrom<Subject>
    {
        public int Id { get; set; }

        public int DayId { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }

        public int Priority { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subject, SubjectDto>()
                .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
        }
    }
}
