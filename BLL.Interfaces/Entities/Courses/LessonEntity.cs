﻿namespace BLL.Interfaces.Entities.Courses
{
    public class LessonEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ModuleId { get; set; }
        public int PageCount { get; set; }
    }
}