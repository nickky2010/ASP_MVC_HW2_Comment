using ASP_MVC_HW2_Comment.DAL.EF.Contexts.Initializers;
using ASP_MVC_HW2_Comment.DAL.Models;
using ASP_MVC_HW2_Comment.DAL.Models.Account;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace ASP_MVC_HW2_Comment.DAL.EF.Contexts
{
    public class PokemonContext : IdentityDbContext<User>
    {
        static PokemonContext()
        {
            Database.SetInitializer<PokemonContext>(new PokemonContextDBInitializer());
        }

        public PokemonContext() : base("name=ApplicationAboutPokemon")
        {

        }
        public PokemonContext(string cs) : base(cs)
        {
        }
        public static PokemonContext Create(string сonectionString)
        {
            return new PokemonContext(сonectionString);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<User>().ToTable("User").HasKey(p => p.Id);
            modelBuilder.Entity<Role>().ToTable("IdentityRole");

        }
        public DbSet<Comment> Comments { get; set; }
    }
}