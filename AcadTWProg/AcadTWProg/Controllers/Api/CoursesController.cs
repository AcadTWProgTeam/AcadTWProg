using AcadTWProg.Models;
using AcadTWProg.Models.Dtos;
using AcadTWProg.Models.MyModels;
using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using System.Collections.Generic;

namespace AcadTWProg.Controllers.Api
{
    public class CoursesController : ApiController
    {
        ApplicationDbContext _context;

        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/courses
        public IHttpActionResult GetCourses()
        {
            return Ok(_context.Courses
                .Include(c => c.Department)
                .ToList()
                .Select(Mapper.Map<Course, CourseDto>));
        }

        [Route("api/Courses/GetAllCourses")]
        public List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public IHttpActionResult GetCourses(int departmentId, int semester)
        {
            return Ok(_context.Courses
                .Include(c => c.Department)
                .Where(c => c.DepartmentId == departmentId && c.Semester == semester)
                .ToList()
                .Select(Mapper.Map<Course, CourseDto>));
        }

        // GET /api/courses/1
        public IHttpActionResult GetCourse(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.ID == id);
            if (course == null)
                return NotFound();

            return Ok(Mapper.Map<Course, CourseDto>(course));
        }

        // POST /api/courses
        [HttpPost]
        public IHttpActionResult CreateCourse(CourseDto courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(courseDto.Name);

            var course = Mapper.Map<CourseDto, Course>(courseDto);
            _context.Courses.Add(course);
            _context.SaveChanges();

            courseDto.Name = course.Name;
            return Created(new Uri(Request.RequestUri + "/" + course.Name), courseDto);
        }

        // PUT /api/courses/1
        [HttpPut]
        public IHttpActionResult UpdateCourse(int id, CourseDto courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var courseInDb = _context.Courses.SingleOrDefault(c => c.ID == id);
            if (courseInDb == null)
                return NotFound();

            Mapper.Map(courseDto, courseInDb);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/courses/1
        [HttpDelete]
        public IHttpActionResult DeleteCourse(int id)
        {
            var courseInDb = _context.Courses.SingleOrDefault(c => c.ID == id);
            if (courseInDb == null)
                return NotFound();

            _context.Courses.Remove(courseInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
