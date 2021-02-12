using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Apple_iPad_Pro_A2229> Apple_iPad_Pro_A2229 { get; set; }
        public virtual DbSet<Apple_Watch_Series_6> Apple_Watch_Series_6 { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<KazakhBest> KazakhBests { get; set; }
        public virtual DbSet<Nokia_230_DS> Nokia_230_DS { get; set; }
        public virtual DbSet<Samsung_Galaxy_S20_Plus> Samsung_Galaxy_S20_Plus { get; set; }
        public virtual DbSet<Skyworth_BD_400> Skyworth_BD_400 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.KazakhBests)
                .WithRequired(e => e.category)
                .HasForeignKey(e => e.category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KazakhBest>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<KazakhBest>()
                .HasMany(e => e.Apple_iPad_Pro_A2229)
                .WithRequired(e => e.KazakhBest)
                .HasForeignKey(e => e.KazakhBest_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KazakhBest>()
                .HasMany(e => e.Apple_Watch_Series_6)
                .WithRequired(e => e.KazakhBest)
                .HasForeignKey(e => e.KazakhBest_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KazakhBest>()
                .HasMany(e => e.Nokia_230_DS)
                .WithRequired(e => e.KazakhBest)
                .HasForeignKey(e => e.KazakhBest_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KazakhBest>()
                .HasMany(e => e.Samsung_Galaxy_S20_Plus)
                .WithRequired(e => e.KazakhBest)
                .HasForeignKey(e => e.KazakhBest_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KazakhBest>()
                .HasMany(e => e.Skyworth_BD_400)
                .WithRequired(e => e.KazakhBest)
                .HasForeignKey(e => e.KazakhBest_id)
                .WillCascadeOnDelete(false);
        }
    }
}
