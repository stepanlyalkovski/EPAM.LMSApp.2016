using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses.Content;

namespace BLL.Interfaces.Entities.Courses
{
    public class LessonPageFullEntity
    {
        public LessonPageEntity PageInfo { get; set; }
        public ImageEntity Image { get; set; }
        public CodeSampleEntity CodeSample { get; set; }
    }
}