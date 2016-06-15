using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.Interfaces.Entities.Courses;
using MvcPL.Models.Course;

namespace MvcPL.Infrastructure.Mappers
{
    public static class CourseMappers
    {
        public static CourseCreateViewModel ToCourseCreateViewModel(this CourseEntity course)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CourseEntity, CourseCreateViewModel>()
                                        .ForMember("Tags", c => c.MapFrom(cr => string.Join(",", cr.TagList))));
            return Mapper.Map<CourseCreateViewModel>(course);
        }

        public static CourseEntity ToCourseEntity(this CourseCreateViewModel course)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CourseCreateViewModel, CourseEntity>()
                                        .ForMember("TagList", c => c.MapFrom(cr => cr.Tags.Split(','))));
            return Mapper.Map<CourseEntity>(course);
        }

        public static CourseBaseViewModel ToCourseBaseViewModel(this CourseEntity course)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CourseEntity, CourseBaseViewModel>()
                                        .ForMember("Tags", c => c.MapFrom(cr => string.Join(",", cr.TagList)))
                                        .ForMember("ModulesNumber", c => c.MapFrom(cr => cr.ModulesNumber)));
            return Mapper.Map<CourseBaseViewModel>(course);
        }

        public static CourseEntity ToCourseEntity(this CourseBaseViewModel course)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CourseBaseViewModel, CourseEntity>()
                                        .ForMember("TagList", c => c.MapFrom(cr => cr.Tags.Split(','))));
            return Mapper.Map<CourseEntity>(course);
        }
    }
}