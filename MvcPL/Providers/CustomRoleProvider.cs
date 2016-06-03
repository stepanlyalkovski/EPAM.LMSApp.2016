using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using WebDependencyResolver = System.Web.Mvc.DependencyResolver;
namespace MvcPL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public IUserService UserRepository
           => (IUserService)WebDependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleRepository
            => (IRoleService)WebDependencyResolver.Current.GetService(typeof(IRoleService));

        public override bool IsUserInRole(string email, string roleName)
        {

            UserEntity user = UserRepository.GetAllUserEntities().FirstOrDefault(u => u.Email == email);

            if (user == null) return false;

            RoleEntity userRole = RoleRepository.GetRoleEntity(user.RoleId);

            if (userRole != null && userRole.Name == roleName)
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string email)
        {

            
                var roles = new string[] { };
            var user = UserRepository.GetUserEntity(email);//context.Users.FirstOrDefault(u => u.Email == email);

                if (user == null) return roles;

                var userRole = RoleRepository.GetRoleEntity(user.RoleId);

                if (userRole != null)
                {
                    roles = new string[] { userRole.Name };
                }
                return roles;
            
        }

        public override void CreateRole(string roleName)
        {
            //TODO CreateRole in RoleProvider
            throw new NotImplementedException();
            //var newRole = new RoleEntity() { Name = roleName };
            //using (var context = new UserContext())
            //{
            //    context.Roles.Add(newRole);
            //    context.SaveChanges();
            //}
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}