using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InsaatAPI.Models
{
    public partial class InsaatContext : DbContext
    {
        public InsaatContext()
        {
        }

        public InsaatContext(DbContextOptions<InsaatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerRequest> CustomerRequests { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Flat> Flats { get; set; }
        public virtual DbSet<FlatStatus> FlatStatuses { get; set; }
        public virtual DbSet<FlatType> FlatTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<IncomeType> IncomeTypes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }

        internal City Find(City name)
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-L6GAVKA;Database=Insaat;User ID=sa;Password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityID).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.CustomerNo, "IX_Customer")
                    .IsUnique();

                entity.HasIndex(e => e.Tc, "IX_Customer_1")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CityID).HasColumnName("CityID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMail");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.Gsm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GSM");

                entity.Property(e => e.IncomeTypeId).HasColumnName("IncomeTypeID");

                entity.Property(e => e.Tc)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("TC")
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_City");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Customer_Gender");

                entity.HasOne(d => d.IncomeType)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.IncomeTypeId)
                    .HasConstraintName("FK_Customer_IncomeType");
            });

            modelBuilder.Entity<CustomerRequest>(entity =>
            {
                entity.ToTable("CustomerRequest");

                entity.Property(e => e.CustomerRequestId).HasColumnName("CustomerRequestID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FlatTypeId).HasColumnName("FlatTypeID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerRequests)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerRequest_Customer");

                entity.HasOne(d => d.FlatType)
                    .WithMany(p => p.CustomerRequests)
                    .HasForeignKey(d => d.FlatTypeId)
                    .HasConstraintName("FK_CustomerRequest_FlatType");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Flat>(entity =>
            {
                entity.ToTable("Flat");

                entity.Property(e => e.FlatId).HasColumnName("FlatID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlatNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlatStatusId).HasColumnName("FlatStatusID");

                entity.Property(e => e.FlatTypeId).HasColumnName("FlatTypeID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.FlatStatus)
                    .WithMany(p => p.Flats)
                    .HasForeignKey(d => d.FlatStatusId)
                    .HasConstraintName("FK_Flat_FlatStatus");

                entity.HasOne(d => d.FlatType)
                    .WithMany(p => p.Flats)
                    .HasForeignKey(d => d.FlatTypeId)
                    .HasConstraintName("FK_Flat_FlatType");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Flats)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Flat_Project");
            });

            modelBuilder.Entity<FlatStatus>(entity =>
            {
                entity.ToTable("FlatStatus");

                entity.Property(e => e.FlatStatusId).HasColumnName("FlatStatusID");

                entity.Property(e => e.FlatStatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlatType>(entity =>
            {
                entity.ToTable("FlatType");

                entity.Property(e => e.FlatTypeId).HasColumnName("FlatTypeID");

                entity.Property(e => e.FlatTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GenderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IncomeType>(entity =>
            {
                entity.ToTable("IncomeType");

                entity.Property(e => e.IncomeTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("IncomeTypeID");

                entity.Property(e => e.IncomeTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProjectID");

                entity.Property(e => e.CityID).HasColumnName("CityID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStatusId).HasColumnName("ProjectStatusID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProjectNavigation)
                    .WithOne(p => p.Project)
                    .HasForeignKey<Project>(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_City");

                entity.HasOne(d => d.ProjectStatus)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectStatusId)
                    .HasConstraintName("FK_Project_ProjectStatus");
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.ToTable("ProjectStatus");

                entity.Property(e => e.ProjectStatusId).HasColumnName("ProjectStatusID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProjectStatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.SalesId);

                entity.Property(e => e.SalesId).HasColumnName("SalesID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FlatId).HasColumnName("FlatID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SalesDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Sales_Customer");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Sales_Employee");

                entity.HasOne(d => d.Flat)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.FlatId)
                    .HasConstraintName("FK_Sales_Flat");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("Visit");

                entity.Property(e => e.VisitId).HasColumnName("VisitID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.VisitDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
