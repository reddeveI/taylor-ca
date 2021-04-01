using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeekDays.Commands.DeleteWeekDay
{
    public class DeleteWeekDayCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteWeekDayCommandHandler : IRequestHandler<DeleteWeekDayCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteWeekDayCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteWeekDayCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.WeekDays
                .Where(d => d.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(WeekDay), request.Id);
            }

            _context.WeekDays.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
