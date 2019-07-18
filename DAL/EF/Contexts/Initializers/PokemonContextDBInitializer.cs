using System.Data.Entity;

namespace ASP_MVC_HW2_Comment.DAL.EF.Contexts.Initializers
{
    public class PokemonContextDBInitializer : CreateDatabaseIfNotExists<PokemonContext>
    {
        protected override void Seed(PokemonContext db)
        {
            base.Seed(db);
        }
    }
}