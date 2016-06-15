﻿using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface IImageRepository : IRepository<DalImage>
    {
        DalImage GetPageImage(int pageId);
    }
}