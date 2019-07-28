using System.Web.Mvc;

namespace ASP_MVC_HW2_Comment.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }
        public ActionResult ErrorMessage()
        {
            ViewBag.ErrorMessage = TempData["errorMessage"];
            return View();
        }
    }
}