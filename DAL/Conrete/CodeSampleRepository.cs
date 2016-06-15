using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM.Courses;
using ORM.Courses.Content;

namespace DAL.Conrete
{
    public class CodeSampleRepository : ICodeSampleRepository
    {
        private readonly DbContext _context;

        public CodeSampleRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(DalCodeSample codeSample)
        {
            _context.Set<CodeSample>().Add(codeSample.ToOrmCodeSample());
        }

        public void Remove(DalCodeSample code)
        {
            var ormCode = _context.Set<CodeSample>().Find(code.Id);
            _context.Set<CodeSample>().Remove(ormCode);
        }

        public void Update(DalCodeSample entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DalCodeSample> GetAll()
        {
            return _context.Set<CodeSample>().Select(c => c.ToDalCodeSample()).ToList();
        }

        public DalCodeSample GetPageCodeSample(int pageId)
        {
            return _context.Set<LessonPage>().Find(pageId).CodeSample.ToDalCodeSample();
        }

        public DalCodeSample Get(int codeId)
        {
            return _context.Set<CodeSample>().Find(codeId).ToDalCodeSample();
        }
    }
}