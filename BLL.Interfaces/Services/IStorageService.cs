using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Entities.Courses.Content;

namespace BLL.Interfaces.Services
{
    public interface IStorageService
    {
        void AddImage(ImageEntity image);
        IEnumerable<ImageEntity> GetImages(int storageId); 
        void RemoveImage(ImageEntity image);

        void AddCodeSample(CodeSampleEntity code);
        IEnumerable<CodeSampleEntity> GetCodeSamples(int storageId);
        void RemoveCodeSample(CodeSampleEntity code);

        void AddQuiz(QuizEntity quiz);
        IEnumerable<QuizEntity> GetQuizess(int storageId);
        void RemoveQuiz(QuizEntity quiz);

        void AddHtmlArticle(HtmlArticleEntity article);
        IEnumerable<HtmlArticleEntity> GetArticles(int storageId);
        void RemoveHtmlArticle(HtmlArticleEntity article);

    }
}