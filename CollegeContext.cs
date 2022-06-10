using HWS_EF_CRUD_CLI_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWS_EF_CRUD_CLI_App
{
    public class CollegeContext : DbContext
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<Course>? Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HL11Q1M;Database=CollegeDB;Trusted_Connection=True;");
        }
    }
}
