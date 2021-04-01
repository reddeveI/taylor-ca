using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeekDays.Queries.ExportDaySubjects
{
    public class ExportDaySubjectsQuery : IRequest<ExportDaySubjectsVm>
    {
        public int DayId { get; set; }
    }

    public class ExportDaySubjectsQueryHandler : IRequestHandler<ExportDaySubjectsQuery, ExportDaySubjectsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportDaySubjectsQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportDaySubjectsVm> Handle(ExportDaySubjectsQuery request, CancellationToken cancellationToken)
        {
            var vm = new ExportDaySubjectsVm();

            var records = await _context.Subjects
                    .Where(t => t.DayId == request.DayId)
                    .ProjectTo<DaySubjectFileRecord>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            vm.Content = _fileBuilder.BuildDaySubjectsFile(records);
            vm.ContentType = "text/csv";
            vm.FileName = "DaySubjects.csv";

            return await Task.FromResult(vm);
        }
    }
}
