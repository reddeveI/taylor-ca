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
    }
}
