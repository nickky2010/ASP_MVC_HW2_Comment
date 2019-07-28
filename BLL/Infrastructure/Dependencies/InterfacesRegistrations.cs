using ASP_MVC_HW2_Comment.BLL.Interfaces;
using ASP_MVC_HW2_Comment.Models;
using ASP_MVC_HW2_Comment.Services;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace BLL.Infrastructure.Dependencies
{
    public class InterfacesRegistrations : NinjectModule
    {
        public string ConnectionString { get; private set; }
        public InterfacesRegistrations(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUnitOfWorkService>().To<UnitOfWorkService>().WithConstructorArgument(ConnectionString);
            Bind<IUserService>().To<UserService>();
            Bind<IDataBaseService<CommentDTO>>().To<CommentService>();
        }
    }
}
