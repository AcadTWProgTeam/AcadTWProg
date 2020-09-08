using AcadTWProg.Models;
using AcadTWProg.Models.Dtos;
using AcadTWProg.Models.MyModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AcadTWProg.Controllers.Api
{
    public class RoomsController : ApiController
    {
        ApplicationDbContext _context;

        public RoomsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/rooms
        public IHttpActionResult GetRooms()
        {
            return Ok(_context.Rooms.ToList()
                .Select(Mapper.Map<Room, RoomDto>));
        }

        // GET /api/rooms/1
        public IHttpActionResult GetRoom(int id)
        {
            var room = _context.Rooms.SingleOrDefault(c => c.ID == id);
            if (room == null)
                return NotFound();

            return Ok(Mapper.Map<Room, RoomDto>(room));
        }

        // POST /api/rooms
        [HttpPost]
        public IHttpActionResult CreateRoom(RoomDto roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(roomDto.Name + " " + roomDto.Capacity);

            var room = Mapper.Map<RoomDto, Room>(roomDto);
            _context.Rooms.Add(room);
            _context.SaveChanges();

            roomDto.Name = room.Name;
            return Created(new Uri(Request.RequestUri + "/" + room.Name), roomDto);
        }

        // PUT /api/rooms/1
        [HttpPut]
        public IHttpActionResult UpdateRoom(int id, RoomDto roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var roomInDb = _context.Rooms.SingleOrDefault(c => c.ID == id);
            if (roomInDb == null)
                return NotFound();

            Mapper.Map(roomDto, roomInDb);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/rooms/1
        [HttpDelete]
        public IHttpActionResult DeleteRoom(int id)
        {
            var roomInDb = _context.Rooms.SingleOrDefault(c => c.ID == id);
            if (roomInDb == null)
                return NotFound();

            _context.Rooms.Remove(roomInDb);
            _context.SaveChanges();
            return Ok();
        }

        [Route("api/Rooms/GetAllRooms")]
        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }
    }
}
