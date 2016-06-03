using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Services;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using DependencyResolver;
using Ninject;

namespace ConsoleTestApp
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }
        static void Main(string[] args)
        {
            var unitOfWork = resolver.Get<IUnitOfWork>();
            IUserService service = resolver.Get<IUserService>();
            foreach (var entity in service.GetAllUserEntities())
            {
                Console.WriteLine(entity.Id + " " + entity.Email + " " + entity.DateAdded);
                Console.WriteLine("\tRole: " + entity.RoleId);
            }
            //foreach (var user in unitOfWork.Users.GetAll())
            //{
            //    Console.WriteLine(user.Id + " " + user.Email + " " + " " + user.Password + " " + user.CreationDate);
            //    Console.WriteLine("\tRole: " + user.Role.Id + " " + user.Role.Name);
            //}

            //unitOfWork.Users.Add(new DalUser
            //{
            //    CreationDate = DateTime.Now,
            //    Email = "MyEmail@gmail.com",
            //    Password = "password",
            //    Role = unitOfWork.Roles.GetRoleByName("Student")

            //});

            //unitOfWork.Complete();

            //Console.WriteLine("---Updated---");
            //foreach (var user in unitOfWork.Users.GetAll())
            //{
            //    Console.WriteLine(user.Id + " " + user.Email + " " + " " + user.Password + " " + user.CreationDate);
            //    Console.WriteLine("\tRole: " + user.Role.Id + " " + user.Role.Name);
            //}
        }
    }
}
