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
    public class ScheduleDatasController : ApiController
    {
        ApplicationDbContext _context;

        public ScheduleDatasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //api/ScheduleDatas/GetRoomInfos?room=zzz
        public IHttpActionResult GetRoomInfos(string room)
        {
            var all = _context.ScheduleDatas.ToList();
            var roomInfos = _context.ScheduleDatas.ToList().FindAll(s => s.Room == room).ToList();
            return Ok(roomInfos);
        }

        //api/ScheduleDatas/GetTeacherInfos?teacher=zzz
        public IHttpActionResult GetTeacherInfos(string teacher)
        {
            var all = _context.ScheduleDatas.ToList();
            var teacherInfos = _context.ScheduleDatas.ToList().FindAll(s => s.TeacherName == teacher).ToList();
            return Ok(teacherInfos);
        }
    }
}
