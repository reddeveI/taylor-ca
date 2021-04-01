using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeekDays.Queries.GetWeekDays
{
    public class GetWeekDaysQuery : IRequest<WeekDaysVm>
    {
    }

    public class GetWeekDaysQueryHandler : IRequestHandler<GetWeekDaysQuery, WeekDaysVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWeekDaysQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WeekDaysVm> Handle(GetWeekDaysQuery request, CancellationToken cancellationToken)
        {
            return new WeekDaysVm
            {
                PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                    .Cast<PriorityLevel>()
                    .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                    .ToList(),

                Days = await _context.WeekDays
                    .AsNoTracking()
                    .ProjectTo<WeekDayDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
