using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication2.Models
{
    public class Query
    {
        public static List<Moto> Get_Data(SqlConnection connection) 
        {

            List<Moto> Data = new List<Moto>();
            SqlCommand command = new SqlCommand("Select * FROM Motos", connection);
            SqlDataReader reader = command.ExecuteReader();
            //if (!reader.HasRows){ DbCreating.Insert_Defolts(connection);}
            //reader.Close();
            //reader = command.ExecuteReader();
                try
                {
                while (reader.Read())
                {
                    Moto moto = new Moto()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        Model = Convert.ToString(reader.GetValue(1)),
                        Producer = Convert.ToString(reader.GetValue(2)),
                        MaxSpeed = Convert.ToString(reader.GetValue(3)),
                        Price = Convert.ToInt32(reader.GetValue(4))
                };
                        Data.Add(moto);
                    
                    }
                    

                }

                catch (Exception exeption) { Console.WriteLine($"\n\n\n\n{exeption}\n\n\n\n\n");}

                finally 
                {
                    if (!reader.IsClosed) { reader.Close(); Console.WriteLine("operation over"); }
                }
            
            


            return Data;
         }


        public static List<Moto> DataSearch(string query) 
        {
            var Data = Get_Data(DbCreating.Connection());

            return Data.Where(moto => moto.Model.Contains(query) || moto.Producer.Contains(query)).ToList();
        }

    }
}