using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2.Models
{
     abstract public class DbCreating
    {
        public  static SqlConnection Connection() 
        { SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            connection.Open();
            return connection;

        }

        public static  void  Close_Connection(SqlConnection connection) { connection.Close(); }
        
        public static void Creating_Db(SqlConnection connection) 
        {
            SqlCommand command = new SqlCommand("IF OBJECT_ID(N'[dbo].[Motos]', N'U') IS NULL BEGIN CREATE TABLE Motos (id int IDENTITY(1,1) PRIMARY KEY, model nvarchar(50) NOT NULL, producer nvarchar(50) NOT NULL, max_speed nvarchar(50) NOT NULL, price int NOT NULL) END;", connection);
            command.ExecuteNonQuery();
        }

        public static void Insert_Defolts(SqlConnection connection) 
        {
            SqlCommand command = new SqlCommand("INSERT INTO Motos (model, producer, max_speed, price) VALUES ('Alpha', 'Mustang', '120', 23000)", connection);
            command.ExecuteNonQuery();

            SqlCommand command1 = new SqlCommand("INSERT INTO Motos (model, producer, max_speed, price) VALUES ('Panter', 'Spark', '135', 28500)", connection);
            command1.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand("INSERT INTO Motos (model, producer, max_speed, price) VALUES ('Alpha', 'Spark', '120', 22800)", connection);
            command2.ExecuteNonQuery();
        }

        public static void Creating_PurchaseDb(SqlConnection connection) 
        {
            // FOREIGN KEY (motoId) REFERENCES dbo.Motos(id))
            SqlCommand command = new SqlCommand("IF OBJECT_ID(N'[dbo].[Purchase]', N'U') IS NULL BEGIN CREATE TABLE Purchase (id int IDENTITY(1,1) PRIMARY KEY , person nvarchar(50) NOT NULL, adress nvarchar(50) NOT NULL, date nvarchar(50) NOT NULL, motoId int NOT NULL) END;" +
                "", connection);
            command.ExecuteNonQuery();

        }

        
        
        
        


    }
}