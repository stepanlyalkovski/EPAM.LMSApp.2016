﻿using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface IQuizRepository : IRepository<DalQuiz>
    {
        DalQuiz GetModuleQuiz(int moduleId);
        IEnumerable<DalQuiz> GetStorageQuizzes(int storageId);
    }
}