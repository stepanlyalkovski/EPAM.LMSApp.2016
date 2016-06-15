﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM;
using ORM.Courses;

namespace DAL.Conrete
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DbContext _context;

        public CourseRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(int storageId, DalCourse course)
        {
            var storage = _context.Set<UserStorage>().Find(storageId);
            var courses = storage.Courses ?? new List<Course>();
            Course ormCourse = course.ToOrmCourse();
            ormCourse.Tags = DistinctTags(ormCourse.Tags);
            courses.Add(ormCourse);
            storage.Courses = courses;
        }

        public DalCourse Get(int id)
        {
            return _context.Set<Course>().Find(id).ToDalCourse();
        }

        public DalCourse Get(string title)
        {
            return _context.Set<Course>().FirstOrDefault(c => c.Title == title).ToDalCourse();
        }

        public IEnumerable<DalCourse> GetStorageCourses(int storageId)
        {
            return _context.Set<UserStorage>().Find(storageId).Courses.ToDalCourses();
        }

        public void Remove(int storageId, DalCourse course)
        {
            var dbCourse = _context.Set<UserStorage>().Find(storageId).Courses.FirstOrDefault(c => c.Id == course.Id);
            if (dbCourse != null)
                _context.Set<Course>().Remove(dbCourse);
        }

        public void Update(int storageId, DalCourse course)
        {
            var ormCourse = _context.Set<Course>().Find(course.Id);
            ormCourse.Title = course.Title;
            ormCourse.Description = course.Description;
            ormCourse.Published = course.Published;
            ormCourse.Tags = course.TagList.Select(t => new Tag(t)).ToList();
        }

        //public IEnumerable<DalCourse> GetAll()
        //{
        //    return _context.Set<Course>().Include(c => c.Tags).ToDalCourses();
        //}

        private IList<Tag> DistinctTags(IList<Tag> tags)
        {
            var distinctTags = new List<Tag>();

            foreach (var tag in tags)
            {
                var dbTag = _context.Set<Tag>().FirstOrDefault(t => t.TagField == tag.TagField);
                distinctTags.Add(dbTag ?? tag);
            }

            return distinctTags;
        }
    }
}