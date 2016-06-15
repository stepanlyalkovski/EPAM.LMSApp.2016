using AutoMapper;
using BLL.Interfaces.Entities.Courses;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;

namespace BLL.Mappers
{
    public static class BllEnrolmentMapper
    {
        public static EnrolmentEntity ToEnrolmentEntity(this DalEnrolment enrolment)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalEnrolment, EnrolmentEntity>());
            return Mapper.Map<EnrolmentEntity>(enrolment);
        }

        public static DalEnrolment ToDalEnrolment(this EnrolmentEntity enrolment)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EnrolmentEntity, DalEnrolment>());
            return Mapper.Map<DalEnrolment>(enrolment);
        }

    }
}