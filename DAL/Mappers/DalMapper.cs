using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoMapper;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;
using ORM;
using ORM.Courses;
using ORM.Courses.Content;

namespace DAL.Mappers
{
    public static class DalMapper
    {
        public static IMapper Mapper { get; set; }

        static DalMapper()
        {
            // TODO DateMapping
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, DalUser>();
                cfg.CreateMap<DalUser, User>();

                cfg.CreateMap<Course, DalCourse>()
                    .ForMember("TagList", c => c.MapFrom(cl => cl.Tags.Select(t => t.TagField)));
                cfg.CreateMap<DalCourse, Course>().ForMember("Tags", c => c.MapFrom(cr =>
                                                                     cr.TagList.Select(tag => new Tag(tag)).ToList()));

                cfg.CreateMap<Role, DalRole>();
                cfg.CreateMap<DalRole, Role>();

                cfg.CreateMap<ORM.Profile, DalProfile>();
                cfg.CreateMap<DalProfile, ORM.Profile>();

                cfg.CreateMap<Module, DalModule>();
                cfg.CreateMap<DalModule, Module>();

                cfg.CreateMap<Lesson, DalLesson>();
                cfg.CreateMap<DalLesson, Lesson>();

                cfg.CreateMap<LessonPage, DalLessonPage>();
                cfg.CreateMap<DalLessonPage, LessonPage>();

                cfg.CreateMap<HtmlArticle, DalHtmlArticle>();
                cfg.CreateMap<DalHtmlArticle, HtmlArticle>();

                cfg.CreateMap<Enrolment, DalEnrolment>();
                cfg.CreateMap<DalEnrolment, Enrolment>();

                cfg.CreateMap<CourseProgress, DalCourseProgress>();
                cfg.CreateMap<DalCourseProgress, CourseProgress>();

                cfg.CreateMap<UserStorage, DalUserStorage>();
                cfg.CreateMap<DalUserStorage, UserStorage>();

                cfg.CreateMap<Tag, DalTag>();
                cfg.CreateMap<DalTag, Tag>();               

                cfg.CreateMap<CodeSample, DalCodeSample>();
                cfg.CreateMap<DalCodeSample, CodeSample>();

                cfg.CreateMap<Image, DalImage>();
                cfg.CreateMap<DalImage, Image>();

                cfg.CreateMap<Quiz, DalQuiz>();
                cfg.CreateMap<DalQuiz, Quiz>();

            });

            Mapper = config.CreateMapper();
        }
    }
}