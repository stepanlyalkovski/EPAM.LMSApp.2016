using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Helpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    class DbInitializer : CreateDatabaseIfNotExists<EntityModel>
    {
        protected override void Seed(EntityModel context)
        {
            IList<Role> defaultRoles = new List<Role>
            {
                new Role {Name = "Admin"},
                new Role {Name = "Student" },
                new Role {Name = "Manager"}
            };

            context.Roles.AddRange(defaultRoles);
            context.SaveChanges();

            User admin = new User
            {
                Email = "admin@gmail.com",
                Password = Crypto.HashPassword("admin"),
                RoleId = defaultRoles.FirstOrDefault(r => r.Name == "Admin").Id,
                CreationDate = DateTime.Now
            };

            User student = new User
            {
                Email = "student@gmail.com",
                Password = Crypto.HashPassword("student"),
                RoleId = defaultRoles.FirstOrDefault(r => r.Name == "Student").Id,
                CreationDate = DateTime.Now
            };

            User manager = new User
            {
                Email = "manager@gmail.com",
                Password = Crypto.HashPassword("manager"),
                RoleId = defaultRoles.FirstOrDefault(r => r.Name == "Manager").Id,
                CreationDate = DateTime.Now
            };

            context.Users.AddRange(new List<User> {student, manager, admin});

            context.SaveChanges();
        }
    }
}
