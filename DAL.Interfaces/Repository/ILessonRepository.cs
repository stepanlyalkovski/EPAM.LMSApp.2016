using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface ILessonRepository
    {
        void Add(int moduleId, DalLesson lesson);
        DalLesson Get(int moduleId);
        void Update(DalLesson lesson);
        void Remove(int lessonId);
    }
}