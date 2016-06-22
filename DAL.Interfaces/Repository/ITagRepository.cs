using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;

namespace DAL.Interfaces.Repository
{
    public interface ITagRepository
    {
        IEnumerable<DalTag> Search(string name);
    }
}