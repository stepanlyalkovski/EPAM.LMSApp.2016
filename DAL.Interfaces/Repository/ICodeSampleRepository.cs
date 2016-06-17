using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface ICodeSampleRepository : IRepository<DalCodeSample>
    {
        DalCodeSample GetPageCodeSample(int pageId);
        IEnumerable<DalCodeSample> GetStorageCodeSamples(int storageId);
    }
}