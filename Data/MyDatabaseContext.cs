using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreSqlDb.Models
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext (DbContextOptions<MyDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<DotNetCoreSqlDb.Models.Todo> Todo { get; set; }
         public DbSet<DotNetCoreSqlDb.Models.Klient> Klient { get; set; }

        public DbSet<DotNetCoreSqlDb.Models.AllTables> AllTables {get;set;}
         public DbSet<DotNetCoreSqlDb.Models.Adres> Adres {get;set;}

          public DbSet<DotNetCoreSqlDb.Models.NoteSet> NoteSet {get;set;}

       
    }
}
