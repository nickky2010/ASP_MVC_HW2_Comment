using ASP_MVC_HW2_Comment.BLL.Infrastructure.Models;
using ASP_MVC_HW2_Comment.DAL.Models.Account;
using ASP_MVC_HW2_Comment.BLL.Interfaces;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASP_MVC_HW2_Comment.DAL.EF.Contexts;
using ASP_MVC_HW2_Comment.Models.Account;

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

        public async Task<OperationDetails> CreateAsync(UserDTO userDTO)
        {
            User user = await IdentityUnitOfWork.UserManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                user = new User
                {
                    UserName = userDTO.Login,
                    Email = userDTO.Email                    
                };
                var result = await IdentityUnitOfWork.UserManager.CreateAsync(user, userDTO.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                User newUser = await IdentityUnitOfWork.UserManager.FindByEmailAsync(userDTO.Email);
                UserProfile clientProfile = new UserProfile
                {
                    Id = newUser.Id,
                    Firstname = userDTO.Firstname,
                    Lastname = userDTO.Lastname,
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

        public async Task<ClaimsIdentity> AuthenticateAsync(UserDTO userDTO)
        {
            ClaimsIdentity claim = null;
            User user = await IdentityUnitOfWork.UserManager.FindAsync(userDTO.Login, userDTO.Password);
            // авторизуем
            if (user != null)
                claim = await IdentityUnitOfWork.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        //// начальная инициализация бд
        public async Task SetInitialDataAsync(UserDTO userDTO)
        {
            await CreateAsync(userDTO);
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}