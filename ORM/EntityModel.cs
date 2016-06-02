using System.Data.Entity;

namespace ORM
{
    public class EntityModel : DbContext 
    {
        static EntityModel()
        {
            Database.SetInitializer(new DbInitializer());
        }

        //TODO string connectionString
        public EntityModel() : base("EntityModel")
        {
            
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}