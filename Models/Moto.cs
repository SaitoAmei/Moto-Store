using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication2.Models
{
    public class Moto
    {
        public int Id { get; set; }

        public string Model { get; set; }
        public string Producer { get; set; }

        public string MaxSpeed { get; set; }

        public int Price { get; set; }
    }
}