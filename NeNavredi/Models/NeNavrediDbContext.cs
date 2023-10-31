using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NeNavredi.Models;

public partial class NeNavrediDbContext : DbContext
{
    public NeNavrediDbContext()
    {
    }

    public NeNavrediDbContext(DbContextOptions<NeNavrediDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Bookkeeper> Bookkeepers { get; set; }

    public virtual DbSet<BookkeeperBill> BookkeeperBills { get; set; }

    public virtual DbSet<BookkeeperService> BookkeeperServices { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<CompleeteService> CompleeteServices { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeService> EmployeeServices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderService> OrderServices { get; set; }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<Recycler> Recyclers { get; set; }

    public virtual DbSet<RecyclerWork> RecyclerWorks { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("server=localhost;user id=postgres;password=12345678;database=NeNavrediDb;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_pk");

            entity.ToTable("Admin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Bookkeeper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bookkeeper_pk");

            entity.ToTable("Bookkeeper");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastEnter)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_enter");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Patronomic)
                .HasMaxLength(50)
                .HasColumnName("patronomic");
        });

        modelBuilder.Entity<BookkeeperBill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bookkeeperbill_pk");

            entity.ToTable("BookkeeperBill");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookkeeperId).HasColumnName("bookkeeper_id");
            entity.Property(e => e.OrganisationId).HasColumnName("organisation_id");

            entity.HasOne(d => d.Bookkeeper).WithMany(p => p.BookkeeperBills)
                .HasForeignKey(d => d.BookkeeperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookkeeperbill_fk");

            entity.HasOne(d => d.Organisation).WithMany(p => p.BookkeeperBills)
                .HasForeignKey(d => d.OrganisationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookkeeperbill_fk_1");
        });

        modelBuilder.Entity<BookkeeperService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bookkeeperservices_pk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookkeeperId).HasColumnName("bookkeeper_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Bookkeeper).WithMany(p => p.BookkeeperServices)
                .HasForeignKey(d => d.BookkeeperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookkeeperservices_fk_1");

            entity.HasOne(d => d.Service).WithMany(p => p.BookkeeperServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookkeeperservices_fk");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pk");

            entity.ToTable("Client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birth_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.OrganisationId).HasColumnName("organisation_id");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(50)
                .HasColumnName("passport_number");
            entity.Property(e => e.PassportSerial)
                .HasMaxLength(50)
                .HasColumnName("passport_serial");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Patronomic)
                .HasMaxLength(50)
                .HasColumnName("patronomic");

            entity.HasOne(d => d.Organisation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.OrganisationId)
                .HasConstraintName("client_fk");
        });

        modelBuilder.Entity<CompleeteService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("compleeteservice_pk");

            entity.ToTable("CompleeteService");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('compleeteservice_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.RecyclerId).HasColumnName("recycler_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.CompleeteServices)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compleeteservice_fk_2");

            entity.HasOne(d => d.Recycler).WithMany(p => p.CompleeteServices)
                .HasForeignKey(d => d.RecyclerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compleeteservice_fk");

            entity.HasOne(d => d.Service).WithMany(p => p.CompleeteServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compleeteservice_fk_1");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pk");

            entity.ToTable("Employee");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('employee_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.IsExplorer).HasColumnName("is_explorer");
            entity.Property(e => e.LastEnter)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_enter");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Patronomic)
                .HasMaxLength(50)
                .HasColumnName("patronomic");
        });

        modelBuilder.Entity<EmployeeService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employeeservice_pk");

            entity.ToTable("EmployeeService");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeServices)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeservice_fk");

            entity.HasOne(d => d.Service).WithMany(p => p.EmployeeServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeservice_fk2");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_pk");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_fk");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orderservice_pk");

            entity.ToTable("OrderService");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderservice_fk");

            entity.HasOne(d => d.Service).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderservice_fk_1");
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organisation_pk");

            entity.ToTable("Organisation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Bik)
                .HasColumnType("character varying")
                .HasColumnName("bik");
            entity.Property(e => e.Bill)
                .HasMaxLength(50)
                .HasColumnName("bill");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Tin)
                .HasMaxLength(50)
                .HasColumnName("tin");
        });

        modelBuilder.Entity<Recycler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recycler_pk");

            entity.ToTable("Recycler");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('recycler_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RecyclerWork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recyclerwork_pk");

            entity.ToTable("RecyclerWork");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('recyclerwork_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.DateEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_start");
            entity.Property(e => e.RecylerId).HasColumnName("recyler_id");

            entity.HasOne(d => d.Recyler).WithMany(p => p.RecyclerWorks)
                .HasForeignKey(d => d.RecylerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recyclerwork_fk");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("service_pk");

            entity.ToTable("Service");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvargeDeviation).HasColumnName("avarge_deviation");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Time).HasColumnName("time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
