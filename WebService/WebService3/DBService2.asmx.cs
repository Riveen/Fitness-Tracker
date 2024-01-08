using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService3
{
    /// <summary>
    /// Summary description for DBService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DBService2 : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable GetAll()
        {
            SqlConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
            using (dbcon)
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }

                string query = "SELECT [Id] AS ID, [date] AS DATE, [name] AS \"MEAL NAME\", [description] AS DESCRIPTION, [calories] AS CALORIES FROM [meals];";

                SqlCommand cmd = new SqlCommand(query, dbcon);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable("Meals");
                dt.Load(reader);
                dbcon.Close();
                return dt;
            }
        }

        [WebMethod]
        public bool insertdb(string date, string name, string description, string calories, string intake)
        {
            bool t = false;
            SqlConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);

            using (dbcon)
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }

                string query = "INSERT INTO [meals] VALUES ('" + name + "','" + description + "','" + calories + "','" + date + "','" + intake + "')";
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
        public bool updatedb(int id, string date, string name, string description, string calories, string intake)
        {
            bool t = false;
            SqlConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);

            using (dbcon)
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }

                string query = "UPDATE [meals] SET [date] = '" + date + "', [name] = '" + name + "', [description] = '" + description + "', [calories] = '" + calories + "', [intake] = '" + intake + "' WHERE [Id] = '" + id + "'";
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
            SqlConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);

            using (dbcon)
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }

                string query = "DELETE FROM [meals] WHERE [Id] = '" + id + "'";
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
