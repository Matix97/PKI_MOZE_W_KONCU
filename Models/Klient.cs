using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSqlDb.Models
{
    public class Klient
    {
        [Key]
        public int klient_id { get; set; }
        public string imie { get; set; }
		
        public string nazwisko {get;set;}

        public double saldo {get;set;}
    }
}
