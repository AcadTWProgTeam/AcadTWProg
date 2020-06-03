using AcadTWProg.Models;
using AcadTWProg.Models.Dtos;
using AcadTWProg.Models.MyModels;
using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;

namespace AcadTWProg.Controllers.Api
{
    public class TeachersController : ApiController
    {
        ApplicationDbContext _context;

        public TeachersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/teachers
        public IHttpActionResult GetTeachers()
        {
            return Ok(_context.Teachers.ToList()
                .Select(Mapper.Map<Teacher, TeacherDto>));
        }

        // GET /api/teachers/1
        public IHttpActionResult GetTeacher(int id)
        {
            var teacher = _context.Teachers.SingleOrDefault(c => c.ID == id);
            if (teacher == null)
                return NotFound();

            return Ok(Mapper.Map<Teacher, TeacherDto>(teacher));
        }

        // POST /api/teachers
        [HttpPost]
        public IHttpActionResult CreateTeacher(TeacherDto teacherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(teacherDto.Name);

            var teacher = Mapper.Map<TeacherDto, Teacher>(teacherDto);
            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            teacherDto.Name = teacher.Name;
            return Created(new Uri(Request.RequestUri + "/" + teacher.Name), teacherDto);
        }

        // PUT /api/teachers/1
        [HttpPut]
        public IHttpActionResult UpdateTeacher(int id, TeacherDto teacherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var teacherInDb = _context.Teachers.SingleOrDefault(c => c.ID == id);
            if (teacherInDb == null)
                return NotFound();

            Mapper.Map(teacherDto, teacherInDb);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/teachers/1
        [HttpDelete]
        public IHttpActionResult DeleteTeacher(int id)
        {
            var teacherInDb = _context.Teachers.SingleOrDefault(c => c.ID == id);
            if (teacherInDb == null)
                return NotFound();

            _context.Teachers.Remove(teacherInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
