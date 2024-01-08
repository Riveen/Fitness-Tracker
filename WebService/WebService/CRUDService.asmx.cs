using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebService
{
    /// <summary>
    /// Summary description for CRUDService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CRUDService : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable GetAll() 
        {
            SqlConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (dbcon) 
            {
                if (dbcon.State == ConnectionState.Closed) 
                {
                    dbcon.Open();
                }

                string query = "SELECT [Id] AS ID, [date] AS DATE, [workout] AS WORKOUT, [used_weight] AS \"WEIGHT USED\", [sets] AS SETS, [reps] AS REPS, [duration] AS DURATION FROM [workouts];";

                SqlCommand cmd = new SqlCommand(query, dbcon);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable("Workouts");
                dt.Load(reader);
                dbcon.Close();
                return dt;
            }
        }

        [WebMethod]
        public bool insertdb(string date, string workout, string weight, string sets, string reps, string duration)
        {
            bool t = false;

            SqlConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (dbcon)
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }

                string query = "INSERT INTO [workouts] VALUES ('" + date + "','" + workout + "','" + weight + "','" + sets + "','" + reps + "','" + duration + "')";
                SqlCommand cmd = new SqlCommand(query, dbcon);
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    t = true;
                }
                dbcon.Close();
                return t;
            }

        }


        [WebMethod]
        public bool updatedb(int id, string date, string workout, string weight, string sets, string reps, string duration)
        {
            bool t = false;
            SqlConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (dbcon)
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }

                string query = "UPDATE [workouts] SET [date] = '" + date + "', [workout] = '" + workout + "', [used_weight] = '" + weight + "', [sets] = '" + sets + "', [reps] = '" + reps + "', [duration] = '" + duration + "'  WHERE [Id] = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, dbcon);
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    t = true;
                }

                dbcon.Close();
                return t;
            }
        }



        [WebMethod]
        public bool delete(int id) 
        {
            bool t = false;
            SqlConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);


            using (dbcon)
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }

                string query = "DELETE FROM [workouts] WHERE [Id] = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, dbcon);
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    t = true;
                }

                dbcon.Close();
                return t;
            }
        }

    }
}
