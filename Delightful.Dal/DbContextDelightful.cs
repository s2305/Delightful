using Delightful.ViewModel.Model;
using Delightful.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Delightful.Dal
{
    public class DbContextDelightful : IdentityDbContext<ApplicationUser>
    {

        public DbContextDelightful()
            : base("DbContextDelightful")
        {
            //int i = 4;
        }

        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static DbContextDelightful Create()
        {
            return new DbContextDelightful();
        }
        
    }

   //public class Bidon
   // {
   //     [Dependency]
   //     public  DbContextDelightful context { get; set; }

   //     public  DbContextDelightful Create()
   //     {
   //         return context;
   //     }
   // }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection")
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}



}



