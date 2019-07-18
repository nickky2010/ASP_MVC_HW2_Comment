using ASP_MVC_HW2_Comment.DAL.EF.Contexts;
using DAL.Interfaces;

namespace BLL.Interfaces
{
    public interface IUnitOfWorkService
    {
        IUnitOfWork<PokemonContext> GetIUnitOfWorkPokemonContext { get; }
        IIdentityUnitOfWork<IdentityContext> GetIUnitOfWorkIdentityContext { get; }
    }
}
