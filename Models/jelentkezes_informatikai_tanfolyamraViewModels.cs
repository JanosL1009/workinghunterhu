using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MVC_WH.App_Code;

namespace MVC_WH.Models
{
    public class jelentkezes_informatikai_tanfolyamraViewModels
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Név")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Lakhely")]
        public string PlaceCity { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Cím")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Terms and Conditions")]
       
        public bool TermsAndConditions { get; set; }

        [Required]
        [Display(Name = "Data Security and GDPR")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You gotta tick the box!")]
        public bool Gdpr { get; set; }

    }


    /// <summary>
    /// Jelentkezés formhoz feliratok!
    /// </summary>
    public class htmlJelentkezoLabels
    {
        protected string tanfolyamAzonisito = string.Empty;
        
        public string CimH1 = string.Empty;


        /// <summary>
        /// Egy GET paramétert dolgoz fel, amit a kulso linkbol kapunk!
        /// PL: workinghunter.com/jelentkezes_informatikai_tanfolyamra.aspx?tanfolyam=csharp40atipikus
        /// </summary>
        /// <param name="tanfolyamAzonisito">A GET paraméter kerül a lokális paraméterbe!</param>
        public htmlJelentkezoLabels(string tanfolyamAzonisito)
        {

            this.tanfolyamAzonisito = tanfolyamAzonisito;

            this.gethtmlH1_PageTitle(this.tanfolyamAzonisito);
        }


        protected void gethtmlH1_PageTitle(string tanfolyamAzonisito)
        {

            switch (tanfolyamAzonisito)
            {
                case "csharp40atipikus":
                    CimH1 = "C# programozó (40)";
                    break;

                case "csharp80atipikus":
                    CimH1 = "C# programozó (80)";
                    break;

                case "aspdotnet80atipikus":
                    CimH1 = "ASP.NET webprogramozó ";
                    break;
                case "php80atipikus":
                    CimH1 = "PHP programozó ";
                    break;
                case "linuxtanfolyam":
                    CimH1 = "Linux tanfolyam";
                    break;
                case "pythontanfolyam":
                    CimH1 = "Python programozó tanfolyam";
                    break;
                default:
                    CimH1 = "Nem létező";
                    break;
            }

        }

        public string getPageTitle_H1Tag()
        {
            return this.CimH1;
        }

    }

    /**********             *******             ********    *******             *********               ********/

}