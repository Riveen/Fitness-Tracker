using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;

namespace WebService2
{
    /// <summary>
    /// Summary description for xmlService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class xmlService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool write(string filepath, DataTable tbldata) 
        {
            bool t = false;

            DataTable newtbl = new DataTable();
            newtbl = tbldata;

            newtbl.WriteXml(filepath);

            if (File.Exists(filepath)) 
            {
                t = true;
            }

            return t;
        }

        [WebMethod]
        public DataTable read(string filepath) 
        {
            DataTable newtbl = new DataTable("xmldata");

            newtbl.Columns.Add("ID");
            newtbl.Columns.Add("Date");
            newtbl.Columns.Add("Weight");
            newtbl.Columns.Add("Height");

            if (File.Exists(filepath))
            {
                newtbl.ReadXml(filepath);
            }

            return newtbl;
        }


        [WebMethod]
        public int predict_weight(string filepath)
        {
            int weight1 = 0, avg_weight = 0;
            string weight = "";
            DataTable newtbl = new DataTable("xmldata");

            newtbl.Columns.Add("ID");
            newtbl.Columns.Add("Date");
            newtbl.Columns.Add("Weight");
            newtbl.Columns.Add("Height");

            if (File.Exists(filepath))
            {
                newtbl.ReadXml(filepath);
            }

            if (newtbl.Rows.Count > 0)
            {
                for (int i = 0; i < newtbl.Rows.Count; i++)
                {
                    weight = newtbl.Rows[i].Field<string>("Weight");
                    weight1 = weight1 + Int32.Parse(weight);
                }

                avg_weight = weight1 / newtbl.Rows.Count;
            }

            return avg_weight;
        }

        [WebMethod]
        public double predict_bmi(string filepath)
        {
            double BMI = 0.0, BMI_tot = 0.0, avg_bmi = 0.0, rounded_bmi = 0.0;
            string weight = "", height = "";
            DataTable newtbl = new DataTable("xmldata");

            newtbl.Columns.Add("ID");
            newtbl.Columns.Add("Date");
            newtbl.Columns.Add("Weight");
            newtbl.Columns.Add("Height");

            if (File.Exists(filepath))
            {
                newtbl.ReadXml(filepath);
            }

            if (newtbl.Rows.Count > 0)
            {
                for (int i = 0; i < newtbl.Rows.Count; i++)
                {
                    weight = newtbl.Rows[i].Field<string>("Weight");
                    height = newtbl.Rows[i].Field<string>("Height");
                    double weight_val = Double.Parse(weight);
                    double height_val = Double.Parse(height) / 100.0;
                    BMI = weight_val / (height_val * height_val);
                    BMI_tot = BMI_tot + BMI;
                }

                avg_bmi = BMI_tot / double.Parse(newtbl.Rows.Count.ToString());
                rounded_bmi = Math.Round(avg_bmi, 2);
            }

            return rounded_bmi;
        }

        [WebMethod]
        public string fitness_stats(double bmi)
        {
            if (bmi < 18.5 || bmi > 24.9)
            {
                return "Low";
            }
            else
            {
                return "High";
            }
        }

    }
}
