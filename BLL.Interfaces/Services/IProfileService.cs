using System.Collections.Generic;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Courses;

namespace BLL.Interfaces.Services
{
    public interface IProfileService
    {
        void Update(ProfileEntity profile);
        ProfileEntity Get(int userId);
    }
}