using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_WH.Models;
namespace MVC_WH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestProfile(ProfileEditModels model)
        {
            if (ModelState.IsValid)
            {
                //TODO: SubscribeUser(model.Email);
            }

            return View("ProfileEdit", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        [Authorize]
        public ActionResult ProfileEdit()
        {
            ViewBag.Message = "Your profile edit page.";
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Action", Value = "0" });

            items.Add(new SelectListItem { Text = "Drama", Value = "1" });

            items.Add(new SelectListItem { Text = "Comedy", Value = "2", Selected = true });

            items.Add(new SelectListItem { Text = "Science Fiction", Value = "3" });

            ViewBag.MovieType = items;
            return View();
        }

        [Authorize]
        public ActionResult JobTarget()
        {
            ViewBag.Message = "Your job target page.";

            return View();
        }

        [Authorize]
        public ActionResult Statistics()
        {
            ViewBag.Message = "Your statistics page.";

            return View();
        }

        [Authorize]
        public ActionResult Search()
        {
            ViewBag.Message = "Your search page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult InformatikaiTanfolyamok()
        {
            ViewBag.Message = "Your ssdfsdfch page.";
            return View();
        }

        

    }
}