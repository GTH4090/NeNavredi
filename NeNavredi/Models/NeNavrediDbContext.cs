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

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Bookkeeper> Bookkeepers { get; set; }

    public virtual DbSet<BookkeeperBill> BookkeeperBills { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<CompleeteService> CompleeteServices { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeService> EmployeeServices { get; set; }

    public virtual DbSet<EnterHistory> EnterHistories { get; set; }

    public virtual DbSet<ExplorerEmployee> ExplorerEmployees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderService> OrderServices { get; set; }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<Recycler> Recyclers { get; set; }

    public virtual DbSet<RecyclerWork> RecyclerWorks { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<SoialSecType> SoialSecTypes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("server=localhost;user id=postgres;password=12345678;database=NeNavrediDb;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("address_pk");

            entity.ToTable("Address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HouseNumber).HasColumnName("house_number");
            entity.Property(e => e.StreetId).HasColumnName("street_id");

            entity.HasOne(d => d.Street).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StreetId)
                .HasConstraintName("address_fk");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_pk");

            entity.ToTable("Admin");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("admin_fk");
        });

        modelBuilder.Entity<Bookkeeper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bookkeeper_pk");

            entity.ToTable("Bookkeeper");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Patronomic)
                .HasMaxLength(50)
                .HasColumnName("patronomic");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Bookkeeper)
                .HasForeignKey<Bookkeeper>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookkeeper_fk");
        });

        modelBuilder.Entity<BookkeeperBill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bookkeeperbill_pk");

            entity.ToTable("BookkeeperBill");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrganisationId).HasColumnName("organisation_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Organisation).WithMany(p => p.BookkeeperBills)
                .HasForeignKey(d => d.OrganisationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookkeeperbill_fk_1");

            entity.HasOne(d => d.User).WithMany(p => p.BookkeeperBills)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookkeeperbill_fk");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("city_pk");

            entity.ToTable("City");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("city_fk");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pk");

            entity.ToTable("Client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birth_date");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Ein)
                .HasMaxLength(50)
                .HasColumnName("ein");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Guid)
                .HasMaxLength(50)
                .HasColumnName("guid");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasColumnName("ip_address");
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
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.SocialSecNum)
                .HasMaxLength(50)
                .HasColumnName("social_sec_num");
            entity.Property(e => e.SocialSecTypeId).HasColumnName("social_sec_type_id");
            entity.Property(e => e.Ua)
                .HasMaxLength(250)
                .HasColumnName("ua");

            entity.HasOne(d => d.Country).WithMany(p => p.Clients)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("client_fk_1");

            entity.HasOne(d => d.Organisation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.OrganisationId)
                .HasConstraintName("client_fk");

            entity.HasOne(d => d.SocialSecType).WithMany(p => p.Clients)
                .HasForeignKey(d => d.SocialSecTypeId)
                .HasConstraintName("client_fk_2");
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
            entity.Property(e => e.RecyclerId).HasColumnName("recycler_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Recycler).WithMany(p => p.CompleeteServices)
                .HasForeignKey(d => d.RecyclerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compleeteservice_fk_2");

            entity.HasOne(d => d.Service).WithMany(p => p.CompleeteServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compleeteservice_fk_1");

            entity.HasOne(d => d.User).WithMany(p => p.CompleeteServices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compleeteservice_fk");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("country_pk");

            entity.ToTable("Country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pk");

            entity.ToTable("Employee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Patronomic)
                .HasMaxLength(50)
                .HasColumnName("patronomic");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_fk");
        });

        modelBuilder.Entity<EmployeeService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employeeservice_pk");

            entity.ToTable("EmployeeService");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Service).WithMany(p => p.EmployeeServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeservice_fk2");

            entity.HasOne(d => d.User).WithMany(p => p.EmployeeServices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeservice_fk");
        });

        modelBuilder.Entity<EnterHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enterhistory_pk");

            entity.ToTable("EnterHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasColumnName("ip_address");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Succes).HasColumnName("succes");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.EnterHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("enterhistory_fk");
        });

        modelBuilder.Entity<ExplorerEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("exploreremployee_pk");

            entity.ToTable("ExplorerEmployee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Patronomic)
                .HasMaxLength(50)
                .HasColumnName("patronomic");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ExplorerEmployee)
                .HasForeignKey<ExplorerEmployee>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("exploreremployee_fk");
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

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_fk_1");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orderservice_pk");

            entity.ToTable("OrderService");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderservice_fk");

            entity.HasOne(d => d.Service).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderservice_fk_1");

            entity.HasOne(d => d.Status).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderservice_fk_2");
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organisation_pk");

            entity.ToTable("Organisation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
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

            entity.HasOne(d => d.Address).WithMany(p => p.Organisations)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organisation_fk");
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

        modelBuilder.Entity<SoialSecType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("soialsectype_pk");

            entity.ToTable("SoialSecType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_pk");

            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("street_pk");

            entity.ToTable("Street");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.City).WithMany(p => p.Streets)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("street_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
