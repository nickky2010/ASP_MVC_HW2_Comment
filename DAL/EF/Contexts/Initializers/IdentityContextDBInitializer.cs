using ASP_MVC_HW2_Comment.DAL.Models.Account;
using System.Data.Entity;

namespace ASP_MVC_HW2_Comment.DAL.EF.Contexts.Initializers
{
    public class IdentityContextDBInitializer : CreateDatabaseIfNotExists<IdentityContext>
    {
        protected override void Seed(IdentityContext db)
        {
            db.Roles.Add(new Role { Name = "admin" });
            db.Roles.Add(new Role { Name = "user" });
            base.Seed(db);
        }
    }
}