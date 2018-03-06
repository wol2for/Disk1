namespace Disk1.Models.bd
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Disk : DbContext
    {
        public Disk()
            : base("name=Disk")
        {
        }

        public virtual DbSet<Alteration> Alteration { get; set; }
        public virtual DbSet<CNAP> CNAP { get; set; }
        public virtual DbSet<ControlCNAP> ControlCNAP { get; set; }
        public virtual DbSet<Dumping> Dumping { get; set; }
        public virtual DbSet<Left> Left { get; set; }
        public virtual DbSet<NotPrivatization> NotPrivatization { get; set; }
        public virtual DbSet<Online> Online { get; set; }
        public virtual DbSet<Regulations> Regulations { get; set; }
        public virtual DbSet<Sixzem> Sixzem { get; set; }
        public virtual DbSet<Who> Who { get; set; }
        public virtual DbSet<Zav80> Zav80 { get; set; }
        public virtual DbSet<Other> Other { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CNAP>()
                .Property(e => e.Comment)
                .IsFixedLength();

            modelBuilder.Entity<Who>()
                .HasMany(e => e.CNAP)
                .WithOptional(e => e.Who1)
                .HasForeignKey(e => e.Who);
        }
    }
}
