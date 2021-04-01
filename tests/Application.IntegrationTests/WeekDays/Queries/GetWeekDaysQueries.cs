using CleanArchitecture.Application.WeekDays.Queries.GetWeekDays;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.IntegrationTests.WeekDays.Queries
{
    using static Testing;

    public class GetWeekDaysQueries : TestBase
    {
        [Test]
        public async Task ShouldReturnPriorityLevels()
        {
            var query = new GetWeekDaysQuery();

            var result = await SendAsync(query);

            result.PriorityLevels.Should().NotBeEmpty();
        }

        [Test]
        public async Task ShouldReturnAllDaysAndSubjects()
        {
            await AddAsync(new WeekDay
            {
                Title = "Monday",
                Colour = Colour.Blue,
                Subjects =
                    {
                        new Subject { Title = "History", Done = true },
                        new Subject { Title = "Math", Done = false },
                    }
            });

            var query = new GetWeekDaysQuery();

            var result = await SendAsync(query);

            result.Days.Should().HaveCount(1);
            result.Days.First().Subjects.Should().HaveCount(2);
        }
    }
}
