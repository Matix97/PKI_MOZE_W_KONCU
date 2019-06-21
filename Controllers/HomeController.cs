﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using DotNetCoreSqlDb.Models;

namespace DotNetCoreSqlDb.Controllers
{
    public class HomeController : Controller
    {

         //
        // 1. Action method for displaying 'Sign Up' page
        //
        public ActionResult SignUp()
        {
            // Let's get all states that we need for a DropDownList
            var tables = GetAllStates();

            var model = new AllTables();

            // Create a list of SelectListItems so these can be rendered on the page
            model.Tables = GetSelectListItems(tables);

            return View(model);
        }

        //
        // 2. Action method for handling user-entered data when 'Sign Up' button is pressed.
        //
        [HttpPost]
        public ActionResult SignUp(AllTables model)
        {
            // Get all states again
            var tables = GetAllStates();

            // Set these states on the model. We need to do this because
            // only the selected value from the DropDownList is posted back, not the whole
            // list of states.
            model.Tables = GetSelectListItems(tables);

            // In case everything is fine - i.e. both "Name" and "State" are entered/selected,
            // redirect user to the "Done" page, and pass the user object along via Session
            if (ModelState.IsValid)
            {
               HttpContext.Items["AllTables"] = model;
                return RedirectToAction("Done");
            }

            // Something is not right - so render the registration page again,
            // keeping the data user has entered by supplying the model.
            return View("SignUp", model);
        }

        //
        // 3. Action method for displaying 'Done' page
        //
        public ActionResult Done()
        {
            // Get Sign Up information from the session
            var model = HttpContext.Items["AllTables"] as AllTables;

            // Display Done.html page that shows Name and selected state.
            return View(model);
        }

        // Just return a list of states - in a real-world application this would call
        // into data access layer to retrieve states from a database.
        private IEnumerable<string> GetAllStates()
        {
            return new List<string>
            {
                "ACT",
                "New South Wales",
                "Northern Territories",
                "Queensland",
                "South Australia",
                "Victoria",
                "Western Australia",
            };
        }

        // This is one of the most important parts in the whole example.
        // This function takes a list of strings and returns a list of SelectListItem objects.
        // These objects are going to be used later in the SignUp.html template to render the
        // DropDownList.
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }
        public IActionResult Index()
        {
            downloadAllTables();
            ViewData["choosenTable"] = "Klient";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        private void downloadAllTables()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            List<SelectListItem> listItems = new List<SelectListItem>();
            builder.ConnectionString = "Server=tcp:zpiprojetk.database.windows.net,1433;Initial Catalog=zpiProjekt;Persist Security Info=False;User ID=zpiAdmin;Password=catch23!M;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder next = new StringBuilder();
                next.Append("SELECT Distinct TABLE_NAME FROM information_schema.TABLES");
                String forSQL = next.ToString();
              
                using (SqlCommand command = new SqlCommand(forSQL, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           if(!(reader.GetString(0).Equals("__EFMigrationsHistory") || reader.GetString(0).Equals("database_firewall_rules") ))//nie wyświetlaj jakiś systemowych tabel
                           {
                                listItems.Add(new SelectListItem
                                {
                                    Text = reader.GetString(0),
                                    Value = reader.GetString(0)
                                });
                           }
                        }
                    }
                }

            }
           
              ViewData["AllTables"] = listItems;
        }
    }
}
