using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Events
{
    class SubjectFinishedEvent : DomainEvent
    {
        public SubjectFinishedEvent(Subject subject)
        {
            Subject = subject;
        }

        public Subject Subject { get; }
    }
}
