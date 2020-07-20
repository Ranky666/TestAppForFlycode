using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppForFlycode.Models
{
    public class PostContext : DbContext
    {

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostsTags { get; set; }

        public PostContext(DbContextOptions<PostContext> options)
                  : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Data Source=./;Initial Catalog=Posts;Trusted_Connection=False;");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(e => e.Heading)
                    .HasName("sqlserver_autoindex_Tags_1")
                    .IsUnique();

                entity.Property(e => e.Heading).IsRequired();
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagName).IsRequired();
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.Property(e => e.PostId).IsRequired();
                entity.Property(e => e.TagsId).IsRequired();

                entity.HasOne(posttag => posttag.post)
                    .WithMany(post => post.Tags)
                    .HasForeignKey(postag => postag.PostId);

                entity.HasOne(posttag => posttag.tag)
                    .WithMany(tag => tag.Posts)
                    .HasForeignKey(posttag => posttag.TagsId);
            });
        }





    }
}
