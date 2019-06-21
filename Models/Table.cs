using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetCoreSqlDb.Models
{
    public class Table
    {
        public int ID { get; set; }
        public string Name { get; set; }
public IEnumerable<SelectListItem> States { get; set; }
    }
}
