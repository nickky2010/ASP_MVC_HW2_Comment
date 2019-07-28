using ASP_MVC_HW2_Comment.Filters;
using ASP_MVC_HW2_Comment.BLL.Interfaces;
using ASP_MVC_HW2_Comment.Models;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using ASP_MVC_HW2_Comment.App_LocalResources;

namespace ASP_MVC_HW2_Comment.Controllers
{
    [MyAuth]
    [Culture]

    public class HomeController : Controller
    {
        IDataBaseService<CommentDTO> commentService;
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        public HomeController(IDataBaseService<CommentDTO> commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<PokemonViewModel> pokemonViewModels = new List<PokemonViewModel>
            {
                new PokemonViewModel { Name = Resource.Bulbasaur, PathPicture = "~/Images/Pokemons/Bulbasaur/Bulbasaur.png"},
                new PokemonViewModel { Name = Resource.Ivysaur, PathPicture = "~/Images/Pokemons/Bulbasaur/Ivysaur.png"},
                new PokemonViewModel { Name = Resource.Venusaur, PathPicture = "~/Images/Pokemons/Bulbasaur/Venusaur.png"},
                new PokemonViewModel { Name = Resource.Charmander, PathPicture = "~/Images/Pokemons/Charmander/Charmander.png"},
                new PokemonViewModel { Name = Resource.Charmeleon, PathPicture = "~/Images/Pokemons/Charmander/Charmeleon.png"},
                new PokemonViewModel { Name = Resource.Charizard, PathPicture = "~/Images/Pokemons/Charmander/Charizard.png"},
                new PokemonViewModel { Name = Resource.Gastly, PathPicture = "~/Images/Pokemons/Gastly/Gastly.png"},
                new PokemonViewModel { Name = Resource.Haunter, PathPicture = "~/Images/Pokemons/Gastly/Haunter.png"},
                new PokemonViewModel { Name = Resource.Gengar, PathPicture = "~/Images/Pokemons/Gastly/Gengar.png"},
                new PokemonViewModel { Name = Resource.Machop, PathPicture = "~/Images/Pokemons/Machop/Machop.png"},
                new PokemonViewModel { Name = Resource.Machoke, PathPicture = "~/Images/Pokemons/Machop/Machoke.png"},
                new PokemonViewModel { Name = Resource.Machamp, PathPicture = "~/Images/Pokemons/Machop/Machamp.png"},
                new PokemonViewModel { Name = Resource.Pichu, PathPicture = "~/Images/Pokemons/Pichu/Pichu.png"},
                new PokemonViewModel { Name = Resource.Pikachu, PathPicture = "~/Images/Pokemons/Pichu/Pikachu.png"},
                new PokemonViewModel { Name = Resource.Raichu, PathPicture = "~/Images/Pokemons/Pichu/Raichu.png"},
                new PokemonViewModel { Name = Resource.Squirtle, PathPicture = "~/Images/Pokemons/Squirtle/Squirtle.png"},
                new PokemonViewModel { Name = Resource.Wartortle, PathPicture = "~/Images/Pokemons/Squirtle/Wartortle.png"},
                new PokemonViewModel { Name = Resource.Blastoise, PathPicture = "~/Images/Pokemons/Squirtle/Blastoise.png"},
                new PokemonViewModel { Name = Resource.Turtwig, PathPicture = "~/Images/Pokemons/Turtwig/Turtwig.png"},
                new PokemonViewModel { Name = Resource.Grotle, PathPicture = "~/Images/Pokemons/Turtwig/Grotle.png"},
                new PokemonViewModel { Name = Resource.Torterra, PathPicture = "~/Images/Pokemons/Turtwig/Torterra.png"},
            };
            return View(pokemonViewModels);
        }
        [HttpGet]
        public async Task<ActionResult> Comment()
        {
            ICollection<CommentViewModel> commentViewModels =
                Mapper.Map<ICollection<CommentDTO>, List<CommentViewModel>>(await commentService.GetAllAsync());
            return View(commentViewModels);
        }
        [HttpPost]
        public async Task<ActionResult> Comment(CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = await UserService.FindIdUserByNameAsync(User.Identity.Name);
                if (userId != null)
                {
                    commentViewModel.DateTimeOfCreation = DateTime.Now;
                    commentService.Add(Mapper.Map<CommentViewModel, CommentDTO>(commentViewModel), userId);
                    ICollection<CommentViewModel> commentViewModels =
                        Mapper.Map<ICollection<CommentDTO>, List<CommentViewModel>>(await commentService.GetAllAsync());
                    return PartialView("CommentsUser", commentViewModels);
                }
                else
                {
                    TempData["errorMessage"] = Resource.СanNotLeaveComment + User.Identity.Name + Resource.NotRegistered;
                    return RedirectToAction("ErrorMessage", "Error");
                }
            }
            TempData["errorMessage"] = Resource.CommentDataNotValid;
            return RedirectToAction("ErrorMessage", "Error");
        }
    }
}