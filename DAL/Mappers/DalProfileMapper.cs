using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;
using ORM.Courses;

namespace DAL.Mappers
{
    public static class DalProfileMapper
    {
        public static DalProfile ToDalProfile(this ORM.Profile tag)
        {
            return DalMapper.Mapper.Map<DalProfile>(tag);
        }

        public static ORM.Profile ToOrmProfile(this DalProfile tag)
        {
            return DalMapper.Mapper.Map<ORM.Profile>(tag);
        }
    }
}