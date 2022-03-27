using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public string Person { get; set; }

        public string Adress { get; set; }

        public DateTime Date { get; set; }

        public int MotoId { get; set; }

    }
}