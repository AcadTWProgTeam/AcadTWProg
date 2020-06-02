﻿using AcadTWProg.Models.Dtos;
using AcadTWProg.Models.MyModels;
using AutoMapper;

namespace AcadTWProg.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Room, RoomDto>();
            Mapper.CreateMap<RoomDto, Room>();

            Mapper.CreateMap<RoomDto, Room>().ForMember(r => r.ID, opt => opt.Ignore());
        }
    }
}