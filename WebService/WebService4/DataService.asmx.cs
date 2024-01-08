using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Web;
using System.Web.DynamicData;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace WebService4
{
    /// <summary>
    /// Summary description for DataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataService : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable GetWeeklyData(string startDate, string endDate) 
        {
            ArrayList workout_types = new ArrayList(); //array list
            DataTable dto = new DataTable("weekly_table");
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString3"].ConnectionString);

            using (connection)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query1 = "SELECT DISTINCT [workout] AS workout FROM [workouts] WHERE date BETWEEN '"+ startDate +"' AND '"+ endDate +"'";
                SqlCommand cmd = new SqlCommand(query1, connection);
                SqlDataReader reader1 = cmd.ExecuteReader();

                if (reader1 != null) 
                {
                    while (reader1.Read())
                    {
                        //fill arraylist
                        workout_types.Add(reader1["workout"]);
                    }
                }
                reader1.Close();
                connection.Close();

                foreach (object item in workout_types)
                {
                    string name = item.ToString();
                    SqlConnection connection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString3"].ConnectionString);

                    if (connection2.State == ConnectionState.Closed)
                    {
                        connection2.Open();
                    }

                    string query2 = "SELECT DISTINCT workout AS 'WORKOUT TYPE', SUM(CAST(used_weight as int)) AS 'TOTAL WEIGHT USED (Kg)', SUM(CAST(reps as int)) AS 'TOTAL REPS', SUM(CAST(duration as int)) AS 'TOTAL DURATION(mins)' \r\nFROM [workouts]\r\nWHERE workout = '" + name + "' AND date BETWEEN '"+ startDate +"' AND '"+ endDate +"'\r\nGROUP BY workout";
                    SqlCommand cmd2 = new SqlCommand(query2, connection2);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    dto.Load(reader2);
                    reader2.Close();
                    connection2.Close();
                }

                return dto;
            }
        }

        [WebMethod]
        public DataTable GetAllData()
        {
            SqlConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString3"].ConnectionString);
            using (dbcon)
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }

                string query = "SELECT [date] as DATE, [workout] AS WORKOUT, [used_weight] AS \"WEIGHT USED(Kg)\", [reps] AS REPS, [duration] AS DURATION FROM [workouts];";

                SqlCommand cmd = new SqlCommand(query, dbcon);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dto = new DataTable("alldata");
                dto.Load(reader);
                dbcon.Close();
                return dto;
            }
        }

        [WebMethod]
        public DataTable GetMealData() 
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString3"].ConnectionString);
            using (connection)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "SELECT date as DATE, name as 'MEAL NAME', calories as 'CALORIES(KJ)', intake as 'CALORIE INTAKE'\r\nFROM meals";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dto = new DataTable("mealdata");
                dto.Load(reader);
                connection.Close();
                return dto;
            }
        }

    }
}
