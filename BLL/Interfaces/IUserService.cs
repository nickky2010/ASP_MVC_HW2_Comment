using ASP_MVC_HW2_Comment.BLL.Infrastructure.Models;
using ASP_MVC_HW2_Comment.Models.Account;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP_MVC_HW2_Comment.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO user);
        Task<ClaimsIdentity> AuthenticateAsync(UserDTO user);
        Task SetInitialDataAsync(UserDTO user);
        Task<string> FindIdUserByNameAsync(string name);
    }
}
