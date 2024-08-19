using LitLounge.Areas.Identity.Data;
using LitLounge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LitLounge.Data;


    public class LitLoungeContext : IdentityDbContext<LitLoungeUser>
    {
        public LitLoungeContext(DbContextOptions<LitLoungeContext> options)
            : base(options)
        {
        }


        public DbSet<Comment> Comments { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<PrivateMessage> PrivateMessages { get; set; } = default!;



    //public DbSet<Comment> Comments { get; set; }
    //public object Blog { get; internal set; }
    //public object Category { get; internal set; }

    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           // builder.Entity<Post>()
           //.HasOne(p => p.User)
           //.WithMany()
           //.HasForeignKey(p => p.UserId)
           //.OnDelete(DeleteBehavior.Cascade);



            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        //public DbSet<LitLounge.Models.Subcategory> Subcategory { get; set; } = default!;

        //public DbSet<LitLounge.Models.Category> Category_1 { get; set; } = default!;

        //public object Subcategory { get; internal set; }


        //public object Posts { get; internal set; }
    }


