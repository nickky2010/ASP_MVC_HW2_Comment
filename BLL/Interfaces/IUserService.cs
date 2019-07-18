using ASP_MVC_HW2_Comment.BLL.Infrastructure.Models;
using ASP_MVC_HW2_Comment.Models.ViewModel;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP_MVC_HW2_Comment.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(RegisterViewModel user);
        Task<ClaimsIdentity> AuthenticateAsync(LoginViewModel user);
        Task SetInitialDataAsync(RegisterViewModel user);
        Task<string> FindIdUserByNameAsync(string name);
    }
}
