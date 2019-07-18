using ASP_MVC_HW2_Comment.DAL.EF.Contexts;
using ASP_MVC_HW2_Comment.DAL.Models.Account;
using DAL.Interfaces;

namespace DAL.Identity
{
    public class ClientManager : IClientManager
    {
        public IdentityContext Database { get; set; }
        public ClientManager(IdentityContext db)
        {
            Database = db;
        }

        public void Create(UserProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
