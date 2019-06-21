using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetCoreSqlDb.Controllers
{
    public class HomeController : Controller
    {
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
