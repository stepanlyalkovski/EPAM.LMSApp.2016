using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Entities.Courses.Content;
using MvcPL.Models;
using MvcPL.Models.ArticleModels;
using MvcPL.Models.CourseModels;
using MvcPL.Models.LessonModels;
using MvcPL.Models.ModuleModels;
using MvcPL.Models.QuizModels;

namespace MvcPL.Infrastructure.Mappers
{
    public static class CourseMappers
    {
        private static void InitMapper<TSource, TDestination>()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TSource, TDestination>());
        }

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
                                        .ForMember("Tags", c => c.MapFrom(cr => cr.TagList))
                                        .ForMember("ModulesNumber", c => c.MapFrom(cr => cr.ModulesNumber)));
            return Mapper.Map<CourseBaseViewModel>(course);
        }

        public static CourseEntity ToCourseEntity(this CourseBaseViewModel course)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CourseBaseViewModel, CourseEntity>()
                                        .ForMember("TagList", c => c.MapFrom(cr => cr.Tags)));
            return Mapper.Map<CourseEntity>(course);
        }

        public static CourseEditViewModel ToCourseEditViewModel(this CourseEntity course)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CourseEntity, CourseEditViewModel>()
                                        .ForMember("Tags", c => c.MapFrom(cr => string.Join(",", cr.TagList)))
                                        .ForMember("ModulesNumber", c => c.MapFrom(cr => cr.ModulesNumber)));
            return Mapper.Map<CourseEditViewModel>(course);
        }

        public static CourseEntity ToCourseEntity(this CourseEditViewModel course)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CourseEditViewModel, CourseEntity>()
                               .ForMember("TagList", c => c.MapFrom(cr => cr.Tags.Split(','))));
            return Mapper.Map<CourseEntity>(course);
        }


        public static ModuleBaseViewModel ToModuleBaseViewModel(this ModuleEntity module)
        {
           InitMapper<ModuleEntity, ModuleBaseViewModel>();
            return Mapper.Map<ModuleBaseViewModel>(module);
        }

        public static ModuleEntity ToModuleEntity(this ModuleBaseViewModel module)
        {
            InitMapper<ModuleBaseViewModel, ModuleEntity>();
            return Mapper.Map<ModuleEntity>(module);
        }


        public static LessonBaseViewModel ToLessonBaseViewModel(this LessonEntity lesson)
        {
            InitMapper<LessonEntity, LessonBaseViewModel>();
            return Mapper.Map<LessonBaseViewModel>(lesson);
        }

        public static LessonEntity ToLessonEntity(this LessonBaseViewModel lesson)
        {
            InitMapper<LessonBaseViewModel, LessonEntity>();
            return Mapper.Map<LessonEntity>(lesson);
        }

        public static LessonBaseEditModel ToLessonBaseEditModel(this LessonEntity lesson)
        {
            InitMapper<LessonEntity,LessonBaseEditModel>();
            return Mapper.Map<LessonBaseEditModel>(lesson);
        }

        public static LessonEntity ToLessonEntity(this LessonBaseEditModel lesson)
        {
            InitMapper<LessonBaseEditModel, LessonEntity>();
            return Mapper.Map<LessonEntity>(lesson);
        }

        public static LessonContentEditViewModel ToLessonContentViewModel(this LessonEntity lesson)
        {
            InitMapper<LessonEntity, LessonContentEditViewModel>();
            return Mapper.Map<LessonContentEditViewModel>(lesson);
        }

        public static LessonEntity ToLessonEntity(this LessonContentEditViewModel lesson)
        {
            InitMapper<LessonContentEditViewModel, LessonEntity>();
            return Mapper.Map<LessonEntity>(lesson);
        }

        public static LessonPageEditModel ToLessonPageEditModel(this LessonPageEntity page)
        {
            InitMapper<LessonPageEntity, LessonPageEditModel>();
            return Mapper.Map<LessonPageEditModel>(page);
        }

        public static LessonPageEntity ToLessonPageEntity(this LessonPageEditModel page)
        {
            InitMapper<LessonPageEditModel, LessonPageEntity>();
            return Mapper.Map<LessonPageEntity>(page);
        }




        public static QuizBaseViewModel ToQuizBaseViewModel(this QuizEntity quiz)
        {
            InitMapper<QuizEntity,QuizBaseViewModel>();
            return Mapper.Map<QuizBaseViewModel>(quiz);
        }

        public static QuizEntity ToQuizEntity(this QuizBaseViewModel quiz)
        {
            InitMapper<QuizBaseViewModel,QuizEntity>();
            return Mapper.Map<QuizEntity>(quiz);
        }


        public static ArticleBaseViewModel ToArticleBaseViewModel(this HtmlArticleEntity article)
        {
            InitMapper<HtmlArticleEntity,ArticleBaseViewModel>();
            return Mapper.Map<ArticleBaseViewModel>(article);
        }

        public static HtmlArticleEntity ToHtmlArticleEntity(this ArticleBaseViewModel article)
        {
            InitMapper<ArticleBaseViewModel, HtmlArticleEntity>();
            return Mapper.Map<HtmlArticleEntity>(article);
        }

        public static ImageViewModel ToImageViewModel(this ImageEntity image)
        {
            InitMapper<ImageEntity, ImageViewModel>();
            return Mapper.Map<ImageViewModel>(image);
        }

        public static ImageEntity ToImageEntity(this ImageViewModel image)
        {
            InitMapper<ImageViewModel, ImageEntity>();
            return Mapper.Map<ImageEntity>(image);
        }
    }
}