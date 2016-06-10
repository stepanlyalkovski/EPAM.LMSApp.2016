using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses.Content;
using ORM;
using ORM.Courses.Content;

namespace DAL.Mappers
{
    public static class UserStorageMapper
    {
        public static DalUserStorage ToDalUserStorage(this UserStorage storage)
        {
            return DalMapper.Mapper.Map<DalUserStorage>(storage);
        }

        public static UserStorage ToOrmUserStorage(this DalUserStorage storage)
        {
            return DalMapper.Mapper.Map<UserStorage>(storage);
        }
    }
}