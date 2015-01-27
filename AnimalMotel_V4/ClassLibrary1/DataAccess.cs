using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;


namespace AnimalManager
{
    public class DataAccess
    {
       System.Configuration.ConnectionStringSettings ConectionString = ConfigurationManager.ConnectionStrings["AnimalDBConnectionString"];
        public void DeleteAnimalData()
        {

        }

        public DataTable LoadAnimalData()
        {
            string quary = "SELECT * FROM dbo.Animal;";
            return RunQuery(quary);
        }

        public DataTable RunQuery(string quary)
        {
            using (SqlConnection connection = new SqlConnection(ConectionString.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = quary;
                    cmd.Connection = connection;
                    if (cmd.Connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        connection.Close();
                        return dt;
                    }
                }
            }
        }

        public void SaveAnimalData(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(ConectionString.ConnectionString))
             using(var command = new SqlCommand(queryString, connection))
   
            {
                connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                connection.Close();
                
            }
        }
        
        public void NewRowInAnimal(string id, string name, double age, string gender, string categori, string info)
        {

        }
        public void NewRowInMammals(string species, int teeth, int quarantine)
        {

        }
        public void SaveMammalAnimal(string id, string name, double age, string gender, string categori, string info, string species, int teeth, int quarantine)
        {

        }



        public DataTable LoadExtraAnimalInfo(string id)
        {
            string quary = string.Format("Select * from Mammal where id_fk = '{0}'", id);            
            return RunQuery(quary);
        }
    }
}
