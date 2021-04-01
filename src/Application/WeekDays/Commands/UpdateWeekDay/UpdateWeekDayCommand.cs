using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeekDays.Commands.UpdateWeekDay
{
    public class UpdateWeekDayCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }

    public class UpdateWeekDayCommandHandler : IRequestHandler<UpdateWeekDayCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateWeekDayCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateWeekDayCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.WeekDays.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(WeekDay), request.Id);
            }

            entity.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
