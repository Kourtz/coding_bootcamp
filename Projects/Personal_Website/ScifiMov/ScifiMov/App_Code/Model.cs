namespace ScifiMov
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=ScifiMov")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(e => e.SubCategory)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Link1)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Link2)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Director)
                .IsFixedLength();

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Movie)
                .HasForeignKey(e => e.MovieID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Rates)
                .WithRequired(e => e.Movie)
                .HasForeignKey(e => e.MovieID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Rates)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
