using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using S =StudentApp.Services.Model;

namespace StudentApp.Tools.Configurations
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=entertainment.db");
        
        public DbSet<S.Subject> Subjects { get; set; }
    }
}
