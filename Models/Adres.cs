using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSqlDb.Models
{
    public class Adres
    {
        [Key]
        public int adres_id { get; set; }
        public string miast { get; set; }
		
        public string ulicac {get;set;}

        public int nrDomy {get;set;}

        public int kodPocztowy {get;set;}

        public int adres_klient_id {get;set;}


    }
}
