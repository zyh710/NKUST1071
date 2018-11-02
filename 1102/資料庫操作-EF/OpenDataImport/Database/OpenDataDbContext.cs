using Microsoft.EntityFrameworkCore;
using OpenDataImport.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace OpenDataImport.Database
{
    public class OpenDataDbContext:DbContext
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\NKUST1071\1102\資料庫操作-EF\OpenDataImport\App_Data\Database.mdf;Integrated Security=True";
                
            }

        }

        public DbSet<OpenData> OpenData { get; set; }



        public OpenDataDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }


    }
}
