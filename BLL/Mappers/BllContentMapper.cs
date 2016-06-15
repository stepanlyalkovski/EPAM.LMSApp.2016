using AutoMapper;
using BLL.Interfaces.Entities.Courses.Content;
using DAL.Interfaces.DTO.Courses.Content;

namespace BLL.Mappers
{
    public static class BllContentMapper
    {
        public static HtmlArticleEntity ToHtmlArticleEntity(this DalHtmlArticle article)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalHtmlArticle, HtmlArticleEntity>());
            return Mapper.Map<HtmlArticleEntity>(article);
        }

        public static DalHtmlArticle ToDalHtmlArticle(this HtmlArticleEntity article)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<HtmlArticleEntity, DalHtmlArticle>());
            return Mapper.Map<DalHtmlArticle>(article);
        }

        public static QuizEntity ToQuizEntity(this DalQuiz quiz)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalQuiz, QuizEntity>());
            return Mapper.Map<QuizEntity>(quiz);
        }

        public static DalQuiz ToDalQuiz(this QuizEntity quiz)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<QuizEntity, DalQuiz>());
            return Mapper.Map<DalQuiz>(quiz);
        }

        public static ImageEntity ToImageEntity(this DalImage image)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalImage, ImageEntity>());
            return Mapper.Map<ImageEntity>(image);
        }

        public static DalImage ToDalImage(this ImageEntity image)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ImageEntity, DalImage>());
            return Mapper.Map<DalImage>(image);
        }

        public static CodeSampleEntity ToCodeSampleEntity(this DalCodeSample codeSample)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalCodeSample, CodeSampleEntity>());
            return Mapper.Map<CodeSampleEntity>(codeSample);
        }

        public static DalCodeSample ToDalCodeSample(this CodeSampleEntity codeSample)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CodeSampleEntity, DalCodeSample>());
            return Mapper.Map<DalCodeSample>(codeSample);
        }
    }
}