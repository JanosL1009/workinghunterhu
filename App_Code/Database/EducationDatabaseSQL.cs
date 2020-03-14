using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MVC_WH.App_Code.Database
{
    public class EducationDatabaseSQL
    {

        static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WhOktatasDatabase"].ConnectionString;

        static SqlConnection connection = new SqlConnection(connectionString);
        

        /// <summary>
        /// Jelentkezo beszurasa a tablaba. Szamla kiallitas eseten a masik fgv-t kell meghivni!!!
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="_Nev"></param>
        /// <param name="SzulIdo"></param>
        /// <param name="Email"></param>
        /// <param name="Varos"></param>
        /// <param name="Cim"></param>
        /// <param name="Orszag"></param>
        /// <param name="Vegzettseg"></param>
        /// <param name="Megjegyzes"></param>
        /// <param name="TelefonSzam"></param>
        public static void setNewApplier(string courseID, string _Nev, string SzulIdo, string Email, string Varos, string Cim, string Orszag, string Vegzettseg, string Megjegyzes, string TelefonSzam)
        {
            
            connection.Open();

            /*Tanolfyaam azonositokerese*/
            string tanfolyamAzonosito = string.Empty; //

            SqlCommand select = connection.CreateCommand();
            string Command = "select * from Tanfolyamok where tanfolyamRovidNeve = '" + courseID + "' ";
            select.CommandText = Command;
            SqlDataReader reader = select.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    tanfolyamAzonosito = reader["id"].ToString();

                }
            }
            catch (Exception e)
            {
                //atiranyitani majd egy hiba kiiro oldalra
                DB_Error.Error = e.Message;
                CloseDB();

            }


            
            
            SqlCommand insertApplier = connection.CreateCommand();
            Command = " insert into Jelentkezok values ('" + _Nev + "','" + Email + "','" + SzulIdo + "','" + Varos + "','" + Cim + "','" + Orszag + "','" + Vegzettseg + "','"+ActuallyDate()+"','" + tanfolyamAzonosito + "','" + Megjegyzes + "','" + TelefonSzam + "')";
            //Response.Write(Command);
            insertApplier.CommandText = Command;
            try
            {
                insertApplier.ExecuteNonQuery();

            }
            catch (Exception ex)
            {   //atiranyitani majd egy hiba kiiro oldalra 
                CloseDB();
            }
            

        }

        /// <summary>
        /// Ha a Jelentkezo a szamlazasi checkboxot is bepipapalta!
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="_Nev"></param>
        /// <param name="SzulIdo"></param>
        /// <param name="Email"></param>
        /// <param name="Varos"></param>
        /// <param name="Cim"></param>
        /// <param name="Orszag"></param>
        /// <param name="Vegzettseg"></param>
        /// <param name="Megjegyzes"></param>
        /// <param name="TelefonSzam"></param>
        /// <param name="SzamlaNev"></param>
        /// <param name="SzamlaCim"></param>
        /// <param name="Adoszam"></param>
        public static void setNewApplier(string courseID, string _Nev, string SzulIdo, string Email, string Varos, string Cim, string Orszag, string Vegzettseg, string Megjegyzes, string TelefonSzam,string SzamlaNev,string SzamlaCim,string Adoszam)
        {
            connection.Open();

            /*Tanolfyaam azonositokerese*/
            string tanfolyamAzonosito = string.Empty; //

            SqlCommand select = connection.CreateCommand();
            string Command = "select * from Tanfolyamok where tanfolyamRovidNeve = '" + courseID + "' ";
            select.CommandText = Command;
            SqlDataReader reader = select.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    tanfolyamAzonosito = reader["id"].ToString();

                }
            }
            catch (Exception e)
            {
                //atiranyitani majd egy hiba kiiro oldalra
                DB_Error.Error = e.Message;

            }



            //beszurjuk az jelentkezot
            SqlCommand insertApplier = connection.CreateCommand();
            Command = " insert into Jelentkezok values ('" + _Nev + "','" + Email + "','" + SzulIdo + "','" + Varos + "','" + Cim + "','" + Orszag + "','" + Vegzettseg + "','" + ActuallyDate() + "','" + tanfolyamAzonosito + "','" + Megjegyzes + "','" + TelefonSzam + "')";
            //Response.Write(Command);
            insertApplier.CommandText = Command;
            try
            {
                insertApplier.ExecuteNonQuery();

            }
            catch (Exception ex)
            {   //atiranyitani majd egy hiba kiiro oldalra 
            }

            int JelentkezokID = -1;
            //lekerjuk a beszurt rekord ID-jat
            SqlCommand userSelect = connection.CreateCommand();
            Command = "SELECT id FROM Jelentkezok WHERE nev = '"+_Nev+"' and email = '"+Email+"' and TanfolyamID = "+tanfolyamAzonosito+" ";
            userSelect.CommandText = Command;

            reader = select.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    JelentkezokID = Convert.ToInt32(reader["id"].ToString());

                }
            }
            catch (Exception e)
            {
                //atiranyitani majd egy hiba kiiro oldalra
                DB_Error.Error = e.Message;

            }
            reader.Close();

            SqlCommand insertBilling = connection.CreateCommand();
            Command = "INSERT INTO SzamlazasiCim VALUES ("+JelentkezokID+",'"+SzamlaNev+"','"+SzamlaCim+"','"+Adoszam+"')";
            insertBilling.CommandText = Command;

            try
            {
                insertBilling.ExecuteNonQuery();

            }
            catch (Exception ex)
            {   //atiranyitani majd egy hiba kiiro oldalra 
                
            }

            


        }



        private static bool getCourseType(string input)
        {
            bool ret = false;
            switch (input)
            {
                case "csharp40atipikus":
                    ret = true;
                    break;

                case "csharp80atipikus":
                    ret = true;
                    break;

                case "aspdotnet80atipikus":
                    ret = true;
                    break;
                case "senior80atipikus":
                    ret = true;
                    break;
                case "linuxtanfolyam":
                    ret = true;
                    break;
                case "pythontanfolyam":
                    ret = true;
                    break;
                default:
                    ret = false;
                    break;
            }

            return ret;
        }

        private static string ActuallyDate()
        {
            DateTime dt = DateTime.Now;

            return dt.Year + "/" + dt.Month + "/" + dt.Day + " " + dt.Hour + ":" + dt.Minute + ":" + dt.Second;

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