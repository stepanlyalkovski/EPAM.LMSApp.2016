using AutoMapper;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Entities.Courses.Content;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;

namespace BLL.Mappers
{
    public static class BllCourseMapper
    {
        public static CourseEntity ToBllCourseEntity(this DalCourse course)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalCourse, CourseEntity>());
            return Mapper.Map<CourseEntity>(course);
        }

        public static DalCourse ToDalCourse(this CourseEntity course)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CourseEntity, DalCourse>());
            return Mapper.Map<DalCourse>(course);
        }

        public static CourseProgressEntity ToCourseProgressEntity(this DalCourseProgress progress)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalCourseProgress, CourseProgressEntity>());
            return Mapper.Map<CourseProgressEntity>(progress);
        }

        public static DalCourseProgress ToDalCourseProgress(this CourseProgressEntity progress)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CourseProgressEntity, DalCourseProgress>());
            return Mapper.Map<DalCourseProgress>(progress);
        }

        public static ModuleEntity ToModuleEntity(this DalModule module)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalModule, ModuleEntity>());
            return Mapper.Map<ModuleEntity>(module);
        }

        public static DalModule ToDalModule(this ModuleEntity module)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ModuleEntity, DalModule>());
            return Mapper.Map<DalModule>(module);
        }

        public static LessonEntity ToLessonEntity(this DalLesson lesson)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalLesson, LessonEntity>());
            return Mapper.Map<LessonEntity>(lesson);
        }

        public static DalLesson ToDalLesson(this LessonEntity lesson)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<LessonEntity, DalLesson>());
            return Mapper.Map<DalLesson>(lesson);
        }

        

        public static LessonPageEntity ToLessonPageEntity(this DalLessonPage page)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalLessonPage, LessonPageEntity>());
            return Mapper.Map<LessonPageEntity>(page);
        }

        public static DalLessonPage ToDalLessonPage(this LessonPageEntity page)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<LessonPageEntity, DalLessonPage>());
            return Mapper.Map<DalLessonPage>(page);
        }

       
    }
}