using CleanArchitecture.Application.WeekDays.Commands.CreateWeekDay;
using CleanArchitecture.Application.WeekDays.Commands.DeleteWeekDay;
using CleanArchitecture.Application.WeekDays.Commands.UpdateWeekDay;
using CleanArchitecture.Application.WeekDays.Queries.ExportDaySubjects;
using CleanArchitecture.Application.WeekDays.Queries.GetWeekDays;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class WeekDayController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<WeekDaysVm>> Get()
        {
            return await Mediator.Send(new GetWeekDaysQuery());
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportDaySubjectsQuery { DayId = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateWeekDayCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateWeekDayCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteWeekDayCommand { Id = id });

            return NoContent();
        }
    }
}
