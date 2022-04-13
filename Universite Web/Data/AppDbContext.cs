using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Models;

namespace Universite_Web.Data
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<CustomUser> CustomUser { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Total> Totals { get; set; }
        public DbSet<UniverstyVideo> UniverstyVideos { get; set; }
        public DbSet<Dersnovu>  Dersnovus { get; set; }
        public DbSet<EducationSection> EducationSections { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Muhazire> Muhazires { get; set; }
        public DbSet<Seminar> Seminar { get; set; }
        public DbSet<SerbestIs> SerbestIs { get; set; }
        public DbSet<Specialty> Specialty { get; set; }
        public DbSet<Subject> Subject { get; set; }


    }
}
