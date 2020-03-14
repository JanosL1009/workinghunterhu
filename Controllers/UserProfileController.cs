using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using MVC_WH.Models;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using MVC_WH.App_Code.Database;
namespace MVC_WH.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Index()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Action", Value = "0" });

            items.Add(new SelectListItem { Text = "Drama", Value = "1" });

            items.Add(new SelectListItem { Text = "Comedy", Value = "2", Selected = true });

            items.Add(new SelectListItem { Text = "Science Fiction", Value = "3" });

            ViewBag.MovieType = items;

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult TestProfile(ProfileEditModels model, JobEnum je)
        {
            if (ModelState.IsValid)
            {
                //TODO: SubscribeUser(model.Email);
            }


            // return View("~/Views/Home/ProfileEdit.cshtml");
            return RedirectToAction("ProfileEdit", "Home");
        }

        [HttpPost]
        public ActionResult UserProfilePictureUpload()
        {


            return RedirectToAction("ProfileEdit", "Home");
        }

        [HttpPost]
        public ActionResult BirthPlaceChange()
        {
            return RedirectToAction("Contact", "Home");
        }

        [HttpPost]
        public ActionResult CurrentPlaceChange()
        {
            return RedirectToAction("Contact", "Home");
        }

        [HttpPost]
        public ActionResult PhoneNumberChange()
        {
            return RedirectToAction("ProfileEdit", "Home");
        }

        [HttpPost]
        public ActionResult EmailContactChange()
        {
            return RedirectToAction("ProfileEdit", "Home");
        }

        public ActionResult FbUrlChange()
        {
            //mukodik! teszteltem
            string fb = Request.Form["newFbUrl"].ToString();
            string WorkerID = Request.Form["worker"].ToString();
            DatabaseSQL.UpdateFbUrl_Change(WorkerID, fb);
            DatabaseSQL.CloseDB();
            return RedirectToAction("ProfileEdit", "Home");
        }

        public ActionResult SelectCategory()
        {

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Action", Value = "0" });

            items.Add(new SelectListItem { Text = "Drama", Value = "1" });

            items.Add(new SelectListItem { Text = "Comedy", Value = "2", Selected = true });

            items.Add(new SelectListItem { Text = "Science Fiction", Value = "3" });

            ViewBag.MovieType = items;

            return View();

        }


        [HttpPost]
        public  ActionResult SaveTarget()
        {


            return RedirectToAction("Contact", "Home");
        }


        /// <summary>
        /// Visszatér a városok listájával a viewba!
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetCities(int countryID)
        {
            // List<ListItem> items =  DatabaseSQL.GetCitiesList(countryID);
            //DatabaseSQL.CloseDB();
            string items = "jott az elem Teeee!";
            return items;
        }

    }
}