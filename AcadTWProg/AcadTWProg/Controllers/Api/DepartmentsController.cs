using AcadTWProg.Models;
using AcadTWProg.Models.Dtos;
using AcadTWProg.Models.MyModels;
using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;

namespace AcadTWProg.Controllers.Api
{
    public class DepartmentsController : ApiController
    {
        ApplicationDbContext _context;

        public DepartmentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/departments
        public IHttpActionResult GetDepartments()
        {
            return Ok(_context.Departments.ToList()
                .Select(Mapper.Map<Department, DepartmentDto>));
        }

        // GET /api/departments/1
        public IHttpActionResult GetDepartment(int id)
        {
            var department = _context.Departments.SingleOrDefault(c => c.ID == id);
            if (department == null)
                return NotFound();

            return Ok(Mapper.Map<Department, DepartmentDto>(department));
        }

        // POST /api/departments
        [HttpPost]
        public IHttpActionResult CreateDepartment(DepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(departmentDto.Name);

            var department = Mapper.Map<DepartmentDto, Department>(departmentDto);
            _context.Departments.Add(department);
            _context.SaveChanges();

            departmentDto.Name = department.Name;
            return Created(new Uri(Request.RequestUri + "/" + department.Name), departmentDto);
        }

        // PUT /api/departments/1
        [HttpPut]
        public IHttpActionResult UpdateDepartment(int id, DepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var departmentInDb = _context.Departments.SingleOrDefault(c => c.ID == id);
            if (departmentInDb == null)
                return NotFound();

            Mapper.Map(departmentDto, departmentInDb);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/departments/1
        [HttpDelete]
        public IHttpActionResult DeleteDepartment(int id)
        {
            var departmentInDb = _context.Departments.SingleOrDefault(c => c.ID == id);
            if (departmentInDb == null)
                return NotFound();

            _context.Departments.Remove(departmentInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
