using ASP_MVC_HW2_Comment.DAL.Models.Account;
using System;

namespace DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(UserProfile item);
    }
}
