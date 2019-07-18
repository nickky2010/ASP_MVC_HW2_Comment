using ASP_MVC_HW2_Comment.BLL.Infrastructure.Models;
using ASP_MVC_HW2_Comment.DAL.Models.Account;
using ASP_MVC_HW2_Comment.BLL.Interfaces;
using ASP_MVC_HW2_Comment.Models.ViewModel;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASP_MVC_HW2_Comment.DAL.EF.Contexts;

namespace ASP_MVC_HW2_Comment.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork<PokemonContext> UnitOfWork { get; set; }
        IIdentityUnitOfWork<IdentityContext> IdentityUnitOfWork { get; set; }

        public UserService(IUnitOfWorkService uow)
        {
            UnitOfWork = uow.GetIUnitOfWorkPokemonContext;
            IdentityUnitOfWork = uow.GetIUnitOfWorkIdentityContext;
        }

        public async Task<OperationDetails> CreateAsync(RegisterViewModel registerViewModel)
        {
            User user = await IdentityUnitOfWork.UserManager.FindByEmailAsync(registerViewModel.Email);
            if (user == null)
            {
                user = new User
                {
                    UserName = registerViewModel.Login,
                    Email = registerViewModel.Email                    
                };
                var result = await IdentityUnitOfWork.UserManager.CreateAsync(user, registerViewModel.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                User newUser = await IdentityUnitOfWork.UserManager.FindByEmailAsync(registerViewModel.Email);
                UserProfile clientProfile = new UserProfile
                {
                    Id = newUser.Id,
                    Firstname = registerViewModel.Firstname,
                    Lastname = registerViewModel.Lastname,
                    UserName = newUser.UserName,
                    UserId = newUser.Id
                };
                IdentityUnitOfWork.ClientManager.Create(clientProfile);
                await IdentityUnitOfWork.SaveIdentityAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<string> FindIdUserByNameAsync(string name)
        {
            UserProfile userProfile = await UnitOfWork.UserProfiles.FindAsync(u=>u.UserName==name);
            return userProfile.Id;
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(LoginViewModel loginViewModel)
        {
            ClaimsIdentity claim = null;
            User user = await IdentityUnitOfWork.UserManager.FindAsync(loginViewModel.Login, loginViewModel.Password);
            // авторизуем
            if (user != null)
                claim = await IdentityUnitOfWork.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        //// начальная инициализация бд
        public async Task SetInitialDataAsync(RegisterViewModel registerViewModel)
        {
            await CreateAsync(registerViewModel);
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}