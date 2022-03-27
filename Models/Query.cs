﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication2.Models
{
    public class Query
    {
        public List<Moto> Get_Data(SqlConnection connection) 
        {

            List<Moto> Data = new List<Moto>();
            SqlCommand command = new SqlCommand("Select * FROM Motos", connection);
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows){ DbCreating.Insert_Defolts(connection);}
                try
                {
                    while (reader.Read())
                    {
                        Moto moto = new Moto();
                            moto.Id = Convert.ToInt32(reader.GetValue(0));
                            moto.Model = Convert.ToString(reader.GetValue(1));
                            moto.Producer = Convert.ToString(reader.GetValue(2));
                            moto.MaxSpeed = Convert.ToString(reader.GetValue(3));
                            moto.Price = Convert.ToInt32(reader.GetValue(4));
                        
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
    }
}