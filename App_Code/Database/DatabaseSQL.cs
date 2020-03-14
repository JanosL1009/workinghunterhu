using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MVC_WH.App_Code.Database
{

    /// <summary>
    /// 
    /// </summary>
    public class DatabaseSQL
    {
        static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultWorkinghunterDatabase"].ConnectionString;

        static SqlConnection connection = new SqlConnection(connectionString);



        //AccountController
        public static string GetUserId(string Email)
        {
            connection.Open();
            SqlCommand select = connection.CreateCommand();
            string CommandSelect = "SELECT Id FROM dbo.AspNetUsers WHERE Email = '" + Email + "'; ";
            select.CommandText = CommandSelect;
            SqlDataReader reader = select.ExecuteReader();
            string ID = string.Empty;
            try
            {
                while (reader.Read())
                {
                    ID = reader["id"].ToString();
                }


            }
            catch (SqlException ex)
            {
                string message = ex.Message;

            }
            return ID;
        }

        //ProfileEdit.cshtml

            /// <summary>
            /// Frissíti az adatbázis user_birthData tábla 3 mezőjét (ev,honap,nap)
            /// </summary>
            /// <param name="WorkerID">Azonosito</param>
            /// <param name="newYear">Ev</param>
            /// <param name="newMonth">Honap</param>
            /// <param name="newDay">Nap</param>
        public static void UpdateBirthPlace_Change(string WorkerID, int newYear,int newMonth,int newDay)
        {
            connection.Open();
           
            SqlCommand update = connection.CreateCommand();
            string command = "UPDATE user_Birthdata SET birth_year = "+newYear+", birth_month = "+newMonth+", birth_day = "+newDay+" WHERE user_worker_ID = "+WorkerID;
            update.CommandText = command;

            update.ExecuteNonQuery();
            
        }


        /// <summary>
        /// A jelenlegi lakhelyet frissiti a WorkerID alapjan.
        /// </summary>
        /// <param name="WorkerID">User azonosito</param>
        /// <param name="CountryID">Orszag azonosito</param>
        /// <param name="cityID">Varos azonosito</param>
        /// <param name="ZipCode">Korzetszam</param>
        /// <param name="Address">Cim</param>
        public static void UpdateCurrentPlace_Change(string WorkerID,int CountryID,int cityID,string ZipCode,string Address)
        {
            connection.Open();

            SqlCommand update = connection.CreateCommand();
            string command = "UPDATE user_From SET country_ID = " + CountryID + ", city_ID = " + cityID + ", zipcode = '" + ZipCode + "', address = '"+Address+"' WHERE user_worker_ID = " + WorkerID;
            update.CommandText = command;

            update.ExecuteNonQuery();
            
        }

        /// <summary>
        /// Frissiti a user telefonszamat a A userContact tablaba
        /// </summary>
        /// <param name="WorkerID">User azonosito</param>
        /// <param name="phone">Telefonszam</param>
        public static void UpdatePhoneNumber_Change(string WorkerID, string phone)
        {
            connection.Open();

            SqlCommand update = connection.CreateCommand();
            string command = "UPDATE userContacts SET phone = " + phone + " WHERE worker_user_ID = " + WorkerID;
            update.CommandText = command;

            update.ExecuteNonQuery();

           
        }

        /// <summary>
        /// Frissiti az email cimet! A userContact tablaba
        /// </summary>
        /// <param name="WorkerID">User azonosito</param>
        /// <param name="mail">E-mail cim</param>
        public static void UpdateEmailContact_Change(string WorkerID, string mail)
        {
            connection.Open();

            SqlCommand update = connection.CreateCommand();
            string command = "UPDATE userContacts SET email = " + mail + " WHERE worker_user_ID = " + WorkerID;
            update.CommandText = command;

            update.ExecuteNonQuery();

            
        }

        /// <summary>
        /// Frissiti a FB URL-t a userContact tablaba!
        /// </summary>
        /// <param name="WorkerID">User azonisto</param>
        /// <param name="FB_URL">Facebook url</param>
        public static void UpdateFbUrl_Change(string WorkerID, string FB_URL)
        {
            connection.Open();

            SqlCommand update = connection.CreateCommand();
            string command = "UPDATE userContacts SET facebook = " + FB_URL + " WHERE worker_user_ID = " + WorkerID;
            update.CommandText = command;

            update.ExecuteNonQuery();
            
        }
        /***************        *****************           *******************     ***************         *****************           **************  **********/
        public static void Insert_JobTarget()
        {
            connection.Open();

            SqlCommand update = connection.CreateCommand();
            //string command = "UPDATE userContacts SET phone = " + phone + " WHERE user_worker_ID = " + WorkerID;
           // update.CommandText = command;

            update.ExecuteNonQuery();
        }



        //*************************         ******************              ************************                ********************            *******************



        /// <summary>
        /// Az ország azonosító alapján vissza adja az adott országhoz tartozó városokat.
        /// </summary>
        /// <param name="countryID">Ország azonosító</param>
        /// <returns>A városok listája: List<ListItem> </returns>
        public static List<ListItem> GetCitiesList(int countryID)
        {

            connection.Open();
            SqlCommand select = connection.CreateCommand();
            string Command = "select ID,cityName from Cities where country_ID = " + countryID;
            select.CommandText = Command;
            SqlDataReader reader = select.ExecuteReader();
            List<ListItem> cities = new List<ListItem>();
            
            try
            {
                while (reader.Read())
                {
                    cities.Add(new ListItem { Value = reader["id"].ToString(), Text = reader["cityName"].ToString() });
                }


            }
            catch (SqlException ex)
            {
                string message = ex.Message;

            }
           
           


            return cities;
        }

        //itt jartam
        public static void SetSchoolForUserProfile(string WorkerID,string SchoolName,int Year,int CountryID)
        {

        }

      

       


        /// <summary>
        /// Bezárja az aktuálisan megnyitott SQL kapcsolatot!
        /// A dokumentum végén kötelezően hívni kell!
        /// </summary>
        public static void CloseDB()
        {
            connection.Close();
        }

    }
}