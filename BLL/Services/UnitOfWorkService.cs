using ASP_MVC_HW2_Comment.DAL.EF.Contexts;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories.EF;
using System;

namespace BLL.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        public string ConnectionString { get; private set; }
        private Lazy<IUnitOfWork<PokemonContext>> pokemonContext;
        private Lazy<IIdentityUnitOfWork<IdentityContext>> identityContext;


        public UnitOfWorkService(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public IUnitOfWork<PokemonContext> GetIUnitOfWorkPokemonContext
        {
            get
            {
                if (pokemonContext == null)
                {
                    pokemonContext = new Lazy<IUnitOfWork<PokemonContext>>(() => new EFUnitOfWork<PokemonContext>(new PokemonContext(ConnectionString)));
                }
                return pokemonContext.Value;
            }
        }

        public IIdentityUnitOfWork<IdentityContext> GetIUnitOfWorkIdentityContext
        {
            get
            {
                if (identityContext == null)
                {
                    identityContext = new Lazy<IIdentityUnitOfWork<IdentityContext>>(() => new EFIdentityUnitOfWork<IdentityContext>(ConnectionString));
                }
                return identityContext.Value;
            }
        }

    }
}
