using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreSqlDb.Models;

namespace DotNetCoreSqlDb.Controllers
{
    public class QueryController : Controller
    {
        private readonly MyDatabaseContext _context;
        //private Query query;

        public QueryController(MyDatabaseContext context/* , Query query*/)//z query nie działa
        {
            _context = context;
            //this.query=query;    
        }

    
        public IActionResult Index()
        {
            return View();
        }
        

        





    }
}
