namespace coderush.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IeltsDBContext : DbContext
    {
        public IeltsDBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<blog> blogs { get; set; }
        public virtual DbSet<category_librarys> category_librarys { get; set; }
        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<course_customer> course_customer { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<group_role> group_role { get; set; }
        public virtual DbSet<image> images { get; set; }
        public virtual DbSet<introduce> introduces { get; set; }
        public virtual DbSet<library> librarys { get; set; }
        public virtual DbSet<position> positions { get; set; }
        public virtual DbSet<staff> staffs { get; set; }
        public virtual DbSet<teacher> teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<blog>()
                .Property(e => e.bl_slug)
                .IsUnicode(false);

            modelBuilder.Entity<blog>()
                .Property(e => e.bl_image)
                .IsUnicode(false);

            modelBuilder.Entity<blog>()
                .Property(e => e.bl_summary)
                .IsUnicode(false);

            modelBuilder.Entity<blog>()
                .Property(e => e.bl_content)
                .IsUnicode(false);

            modelBuilder.Entity<category_librarys>()
                .Property(e => e.ca_slug)
                .IsUnicode(false);

            modelBuilder.Entity<category_librarys>()
                .Property(e => e.ca_icon)
                .IsUnicode(false);

            modelBuilder.Entity<category_librarys>()
                .HasMany(e => e.librarys)
                .WithOptional(e => e.category_librarys)
                .HasForeignKey(e => e.category_library_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<contact>()
                .Property(e => e.co_icon)
                .IsUnicode(false);

            modelBuilder.Entity<contact>()
                .Property(e => e.co_link)
                .IsUnicode(false);

            modelBuilder.Entity<course>()
                .Property(e => e.co_slug)
                .IsUnicode(false);

            modelBuilder.Entity<course>()
                .Property(e => e.co_image)
                .IsUnicode(false);

            modelBuilder.Entity<course>()
                .Property(e => e.co_content)
                .IsUnicode(false);

            modelBuilder.Entity<course>()
                .HasMany(e => e.course_customer)
                .WithOptional(e => e.course)
                .HasForeignKey(e => e.course_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<customer>()
                .Property(e => e.cu_mobile)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cu_email)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cu_address)
                .IsFixedLength();

            modelBuilder.Entity<customer>()
                .Property(e => e.cu_note)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.course_customer)
                .WithOptional(e => e.customer)
                .HasForeignKey(e => e.customer_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<group_role>()
                .Property(e => e.gr_description)
                .IsUnicode(false);

            modelBuilder.Entity<group_role>()
                .HasMany(e => e.staffs)
                .WithOptional(e => e.group_role)
                .HasForeignKey(e => e.group_role_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<introduce>()
                .Property(e => e.in_logo)
                .IsUnicode(false);

            modelBuilder.Entity<introduce>()
                .Property(e => e.in_phone)
                .IsUnicode(false);

            modelBuilder.Entity<introduce>()
                .Property(e => e.in_email)
                .IsUnicode(false);

            modelBuilder.Entity<introduce>()
                .Property(e => e.in_facebook)
                .IsUnicode(false);

            modelBuilder.Entity<introduce>()
                .Property(e => e.in_title)
                .IsUnicode(false);

            modelBuilder.Entity<introduce>()
                .Property(e => e.in_content)
                .IsUnicode(false);

            modelBuilder.Entity<library>()
                .Property(e => e.li_slug)
                .IsUnicode(false);

            modelBuilder.Entity<library>()
                .Property(e => e.li_image)
                .IsUnicode(false);

            modelBuilder.Entity<library>()
                .Property(e => e.li_summary)
                .IsUnicode(false);

            modelBuilder.Entity<library>()
                .Property(e => e.li_content)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .Property(e => e.pos_description)
                .IsUnicode(false);

            modelBuilder.Entity<position>()
                .HasMany(e => e.teachers)
                .WithOptional(e => e.position)
                .HasForeignKey(e => e.position_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<staff>()
                .Property(e => e.sta_email)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.sta_password)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.sta_image)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.courses)
                .WithOptional(e => e.staff)
                .HasForeignKey(e => e.staff_id);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.teachers)
                .WithOptional(e => e.staff)
                .HasForeignKey(e => e.staff_id);

            modelBuilder.Entity<teacher>()
                .Property(e => e.te_content)
                .IsUnicode(false);

            modelBuilder.Entity<teacher>()
                .Property(e => e.te_image)
                .IsUnicode(false);
        }
    }
}
