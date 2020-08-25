using AcadTWProg.Models;
using AcadTWProg.Models.Dtos;
using AcadTWProg.Models.MyModels;
using AutoMapper;
using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using System.Collections.Generic;

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

        [Route("api/Schedules/GetSchedules/{id}")]
        public IHttpActionResult GetSchedules(int id)
        {
            return Ok(_context.Schedules
                .Include(s => s.Department)
                .Where(s => s.DepartmentId == id)
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

        // POST /api/schedules?id=1&scheduleAsString=zzz
        [HttpPost]
        public IHttpActionResult UpdateSchedule(int id, string scheduleAsString)
        {
            List<ScheduleData> scheduleDataList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ScheduleData>>(scheduleAsString);

            Dictionary<string, int> colspanByCode = new Dictionary<string, int>();
            foreach (var scheduleData in scheduleDataList)
            {
                if (!colspanByCode.ContainsKey(scheduleData.Code))
                    colspanByCode[scheduleData.Code] = 0;
                colspanByCode[scheduleData.Code] += scheduleData.ColSpan;
            }

            CoursesController coursesController = new CoursesController();
            List<Course> courses = coursesController.GetAllCourses();

            foreach (var kvp in colspanByCode)
            {
                string code = kvp.Key;
                int colspan = kvp.Value;
                float hours = 1f * colspan / 2f;

                Course course = courses.FirstOrDefault(c => c.Code == code);
                if (course == null || course.Hours != hours)
                    return BadRequest();
            }

            var scheduleInDb = _context.Schedules.SingleOrDefault(s => s.ID == id);
            if (scheduleInDb == null)
                return NotFound();

            var scheduleDatasToRemove = _context.ScheduleDatas.ToList().FindAll(s => s.ScheduleId == id);
            foreach (var scheduleData in scheduleDatasToRemove)
            {
                _context.ScheduleDatas.Remove(scheduleData);
            }

            foreach (var scheduleData in scheduleDataList)
            {
                _context.ScheduleDatas.Add(scheduleData);
            }

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
