using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IAPL_Assignment.Data
{
    public partial class dbsIAPLAssignmentContext : DbContext
    {
        public dbsIAPLAssignmentContext()
        {
        }

        public dbsIAPLAssignmentContext(DbContextOptions<dbsIAPLAssignmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=169.1.24.102,1433;Database=dbsIAPLAssignment;User Id=Gaven;Password=P@ssword22!; Trusted_Connection=True; Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.Property(e => e.Measurementid).ValueGeneratedNever();

                entity.Property(e => e.Fahrenherint).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Hectare).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Kelvin).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Kilometer).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Meter).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Measurements)
                    .HasForeignKey(d => d.Unitid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Measurements_Unit");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
