using AcadTWProg.Models.Dtos;
using AcadTWProg.Models.MyModels;
using AutoMapper;

namespace AcadTWProg.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Department, DepartmentDto>();
            Mapper.CreateMap<DepartmentDto, Department>();
            Mapper.CreateMap<DepartmentDto, Department>().ForMember(d => d.ID, opt => opt.Ignore());

            Mapper.CreateMap<Room, RoomDto>();
            Mapper.CreateMap<RoomDto, Room>();
            Mapper.CreateMap<RoomDto, Room>().ForMember(r => r.ID, opt => opt.Ignore());

            Mapper.CreateMap<Teacher, TeacherDto>();
            Mapper.CreateMap<TeacherDto, Teacher>();
            Mapper.CreateMap<TeacherDto, Teacher>().ForMember(t => t.ID, opt => opt.Ignore());

            Mapper.CreateMap<Course, CourseDto>();
            Mapper.CreateMap<CourseDto, Course>();
            Mapper.CreateMap<CourseDto, Course>().ForMember(c => c.ID, opt => opt.Ignore());
        }
    }
}