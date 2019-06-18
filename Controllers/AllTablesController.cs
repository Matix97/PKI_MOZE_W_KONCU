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
    public class AllTablesController : Controller
    {
        private readonly MyDatabaseContext _context;

        public AllTablesController(MyDatabaseContext context)
        {
            _context = context;    
        }
             // GET: AllTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllTables.ToListAsync());
        }


    }
}
