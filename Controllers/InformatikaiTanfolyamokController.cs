using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_WH.App_Code.Database;
namespace MVC_WH.Controllers
{
    public class InformatikaiTanfolyamokController : Controller
    {
        // GET: InformatikaiTanfolyamok
        [AllowAnonymous]
        public ActionResult InformatikaiTanfolyamok()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Csharp_Programozo_Tanfolyam()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Csharp_Programozo_Tanfolyam40()
        {
            return View();
        }

        

        public ActionResult AspNet_wwebpogramozo_tanfolyam()
        {
            return View();
        }

        public ActionResult kezdo_linux_tanfolyam()
        {
            return View();
        }

        public ActionResult php_webprogramozo_tanfolyam()
        {
            return View();
        }

        public ActionResult jelentkezes_informatikai_tanfolyamra()
        {
          /*  List<SelectListItem> BirthDates = new List<SelectListItem>();

            for (int i = 1950; i < 2002; i++)
            {
                BirthDates.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            
            ViewBag.irthDateList = BirthDates;
            */
            return View();
        }

        public ActionResult office_irodai_tanfolyam()
        {
            return View();
        }
        

        public ActionResult JelentkezoForm()
        {
            string courseID = Request.Form["courseID"];
            string FullName = Request.Form["FullName"];
            string Email = Request.Form["Email"];

            string GDPR = Request.Form["TermsAndConditions"];
            bool isGDPR = false;
            if (GDPR == "true,false")
            {
                isGDPR = true;
            }

            if (isGDPR)
            {
                GDPR = "elfogadva";
            }
            else GDPR = "nem jo";


            string AccountAddress = Request.Form["UjSzamlazasiCim"];
            bool isAccountAddress = false;
            if (AccountAddress == "on")
            {
                isAccountAddress = true;
            }


            string birthYear = Request.Form["szulEv"];
            string birthMonth = Request.Form["szulHonap"];
            string birthDay = Request.Form["szulNap"];

            string CustomBirthDate = getCustomBirtdateFormat(birthYear,birthMonth,birthDay);
            string BirthCity = Request.Form["PlaceCity"];
            string BirthCountry = Request.Form["placecountry"];
            string Address =  Request.Form["Address"];

            string HighestEducation = Request.Form["HighestEducation"];
            string Telephone = Request.Form["TelephoneNumber"];
            
            string OtherComment = Request.Form["Megjegyzes"];



            try
            {
                if (isAccountAddress)
                {
                    string BillingName = Request.Form["SzamlazasiNev"];
                    string BillingAddress = Request.Form["SzamlazasiCim"];
                    string TaxNumber = Request.Form["TaxNumber"];
                    EducationDatabaseSQL.setNewApplier(courseID, FullName, Email, CustomBirthDate, BirthCity, Address, BirthCountry, HighestEducation, OtherComment, Telephone, BillingName, BillingAddress, TaxNumber);
                }
                else
                {

                    EducationDatabaseSQL.setNewApplier(courseID, FullName, Email, CustomBirthDate, BirthCity, Address, BirthCountry, HighestEducation, OtherComment, Telephone);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                EducationDatabaseSQL.CloseDB();
            }

           

           
            return View("jelentkezes_informatikai_tanfolyamra");
        }



        /*
         *                        PRIVATE METHODS      PRIVATE METHODS             PRIVATE METHODS
         */
         /// <summary>
         /// Visszatér egy szuletesi ido stringgel
         /// </summary>
         /// <returns></returns>
        private string getCustomBirtdateFormat(string ev,string ho,string nap)
        {
            return ev + "." + ho + "." + nap;
        }


        /*
         *                       PRIVATE METHODS END     PRIVATE METHODS END    PRIVATE METHODS END
         * 
         */
    }
}