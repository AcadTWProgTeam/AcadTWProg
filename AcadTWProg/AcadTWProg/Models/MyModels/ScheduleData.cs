namespace AcadTWProg.Models.MyModels
{
    public class ScheduleData
    {
        public int ID { get; set; }

        public int Day { get; set; }

        public int Time { get; set; }

        public int ColSpan { get; set; }

        public string Code { get; set; }

        public string TeacherName { get; set; }

        public string Room { get; set; }

        public Schedule Schedule { get; set; }

        public int ScheduleId { get; set; }
    }
}