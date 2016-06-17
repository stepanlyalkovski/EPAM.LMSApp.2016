using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO.Courses.Content
{
    public class DalImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Data { get; set; }
        public int StorageId { get; set; }
        //public virtual IList<DalLessonPage> Pages { get; set; }
    }
}
