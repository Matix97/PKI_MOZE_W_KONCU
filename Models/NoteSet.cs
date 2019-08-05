using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSqlDb.Models
{
    public class NoteSet
    {
        [Key]
        public int note_id { get; set; }
        public string category { get; set; }
		
        public string main_name {get;set;}

        public string long_description {get;set;}
        public string tags {get;set;}
    }
}