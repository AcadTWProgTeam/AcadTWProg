using AcadTWProg.Models;
using AcadTWProg.Models.Dtos;
using AcadTWProg.Models.MyModels;
using AutoMapper;
using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;

namespace AcadTWProg.Controllers.Api
{
    public class SchedulesController : ApiController
    {
        ApplicationDbContext _context;

        public SchedulesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/schedules
        public IHttpActionResult GetSchedules()
        {
            return Ok(_context.Schedules
                .Include(s => s.Department)
                .ToList()
                .Select(Mapper.Map<Schedule, ScheduleDto>));
        }

        // GET /api/schedules/1
        public IHttpActionResult GetSchedule(int id)
        {
            var schedule = _context.Schedules.SingleOrDefault(c => c.ID == id);
            if (schedule == null)
                return NotFound();

            return Ok(Mapper.Map<Schedule, ScheduleDto>(schedule));
        }

        // POST /api/schedules
        [HttpPost]
        public IHttpActionResult CreateSchedule(ScheduleDto scheduleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(scheduleDto.Name);

            var schedule = Mapper.Map<ScheduleDto, Schedule>(scheduleDto);
            _context.Schedules.Add(schedule);
            _context.SaveChanges();

            scheduleDto.Name = schedule.Name;
            return Created(new Uri(Request.RequestUri + "/" + schedule.Name), scheduleDto);
        }

        // PUT /api/schedules/1
        [HttpPut]
        public IHttpActionResult UpdateSchedule(int id, ScheduleDto scheduleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var scheduleInDb = _context.Schedules.SingleOrDefault(c => c.ID == id);
            if (scheduleInDb == null)
                return NotFound();

            Mapper.Map(scheduleDto, scheduleInDb);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/schedules/1
        [HttpDelete]
        public IHttpActionResult DeleteSchedule(int id)
        {
            var scheduleInDb = _context.Schedules.SingleOrDefault(c => c.ID == id);
            if (scheduleInDb == null)
                return NotFound();

            _context.Schedules.Remove(scheduleInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
