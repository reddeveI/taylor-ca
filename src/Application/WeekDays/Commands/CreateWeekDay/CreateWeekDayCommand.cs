using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeekDays.Commands.CreateWeekDay
{
    public class CreateWeekDayCommand : IRequest<int>
    {
        public string Title { get; set; }
    }

    public class CreateWeekDayCommandHandler : IRequestHandler<CreateWeekDayCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateWeekDayCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateWeekDayCommand request, CancellationToken cancellationToken)
        {
            var entity = new WeekDay();

            entity.Title = request.Title;

            _context.WeekDays.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
