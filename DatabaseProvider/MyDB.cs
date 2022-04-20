using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseProvider
{
    public partial class MyDB : DbContext
    {
        public MyDB()
            : base("name=MyDB")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<payment> payments { get; set; }
        public virtual DbSet<paymentType> paymentTypes { get; set; }
        public virtual DbSet<reception> receptions { get; set; }
        public virtual DbSet<reservation> reservations { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<room> rooms { get; set; }
        public virtual DbSet<roomStatu> roomStatus { get; set; }
        public virtual DbSet<roomType> roomTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.acc_username)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.acc_password)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.customer_address)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.customer_contact_number)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.emp_position)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.emp_contact_number)
                .IsUnicode(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.payment_amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<paymentType>()
                .Property(e => e.payment_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<reception>()
                .Property(e => e.customer_id)
                .IsUnicode(false);

            modelBuilder.Entity<reservation>()
                .Property(e => e.expected_room_id)
                .IsUnicode(false);

            modelBuilder.Entity<reservation>()
                .Property(e => e.reservation_status)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.role_name)
                .IsUnicode(false);

            modelBuilder.Entity<roomStatu>()
                .Property(e => e.room_status_name)
                .IsUnicode(false);

            modelBuilder.Entity<roomType>()
                .Property(e => e.room_type_name)
                .IsUnicode(false);
        }
    }
}
