using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Subject : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }

        public WeekDay Day {get; set;}

        public int DayId { get; set; }

        public string Title { get; set; }

        public PriorityLevel Priority { get; set; }

        private bool _done;

        public bool Done
        {
            get => _done;
            set
            {
                if (value == true && _done == false)
                {
                    DomainEvents.Add(new SubjectFinishedEvent(this));
                }

                _done = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
