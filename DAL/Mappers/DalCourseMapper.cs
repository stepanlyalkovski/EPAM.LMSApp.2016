using System.Collections.Generic;
using AutoMapper;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;
using ORM;
using ORM.Courses;
using ORM.Courses.Content;

namespace DAL.Mappers
{   
    public static class DalCourseMapper
    {
        public static DalCourse ToDalCourse(this Course course)
        {
            return DalMapper.Mapper.Map<DalCourse>(course);
        }       

        public static Course ToOrmCourse(this DalCourse course)
        {
            return DalMapper.Mapper.Map<Course>(course);
        }

        public static IEnumerable<DalCourse> ToDalCourses(this IEnumerable<Course> courses)
        {
            return DalMapper.Mapper.Map<IEnumerable<DalCourse>>(courses);
        }
    }


    public static class DalTagMapper
    {
        public static DalTag ToDalTag(this Tag tag)
        {
            return DalMapper.Mapper.Map<DalTag>(tag);
        }

        public static Tag ToOrmTag(this DalTag tag)
        {
            return DalMapper.Mapper.Map<Tag>(tag);
        }
    }

    public static class DalEnrolmentMapper
    {
        public static DalEnrolment ToDalEnrolment(this Enrolment enrolment)
        {
            return DalMapper.Mapper.Map<DalEnrolment>(enrolment);
        }

        public static Enrolment ToOrmEnrolment(this DalEnrolment enrolment)
        {
            return DalMapper.Mapper.Map<Enrolment>(enrolment);
        }
    }


    public static class DalCourseProgressMapper
    {
        public static DalCourseProgress ToDalCourseProgress(this CourseProgress progress)
        {
            return DalMapper.Mapper.Map<DalCourseProgress>(progress);
        }

        public static CourseProgress ToOrmCourseProgress(this DalCourseProgress progress)
        {
            return DalMapper.Mapper.Map<CourseProgress>(progress);
        }
    }


    public static class DalModuleMapper
    {
        public static DalModule ToDalModule(this Module module)
        {
            return DalMapper.Mapper.Map<DalModule>(module);
        }

        public static Module ToOrmModule(this DalModule module)
        {
            return DalMapper.Mapper.Map<Module>(module);
        }
    }


    public static class DalLessonMapper
    {
        public static DalLesson ToDalLesson(this Lesson lesson)
        {
            return DalMapper.Mapper.Map<DalLesson>(lesson);
        }

        public static Lesson ToOrmLesson(this DalLesson lesson)
        {
            return DalMapper.Mapper.Map<Lesson>(lesson);
        }
    }


    public static class DalQuizMapper
    {
        public static DalQuiz ToDalQuiz(this Quiz quiz)
        {
            return DalMapper.Mapper.Map<DalQuiz>(quiz);
        }

        public static Quiz ToOrmQuiz(this DalQuiz quiz)
        {
            return DalMapper.Mapper.Map<Quiz>(quiz);
        }
    }


    public static class DalHtmlArticleMapper
    {
        public static DalHtmlArticle ToDalHtmlArticle(this HtmlArticle article)
        {
            return DalMapper.Mapper.Map<DalHtmlArticle>(article);
        }

        public static HtmlArticle ToOrmHtmlArticle(this DalHtmlArticle article)
        {
            return DalMapper.Mapper.Map<HtmlArticle>(article);
        }
    }

    public static class DalLessonPageMapper
    {
        public static DalLessonPage ToDalLessonPage(this LessonPage page)
        {
            return DalMapper.Mapper.Map<DalLessonPage>(page);
        }

        public static LessonPage ToOrmLessonPage(this DalLessonPage page)
        {
            return DalMapper.Mapper.Map<LessonPage>(page);
        }
    }


    public static class DalImageMapper
    {
        public static DalImage ToDalImage(this Image image)
        {
            return DalMapper.Mapper.Map<DalImage>(image);
        }

        public static Image ToOrmImage(this DalImage image)
        {
            return DalMapper.Mapper.Map<Image>(image);
        }
    }


    public static class DalCodeMapper
    {
        public static DalCodeSample ToDalCodeSample(this CodeSample code)
        {
            return DalMapper.Mapper.Map<DalCodeSample>(code);
        }

        public static CodeSample ToOrmCodeSample(this DalCodeSample code)
        {
            return DalMapper.Mapper.Map<CodeSample>(code);
        }
    }



}