using OneTETH.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Repository
{
    public class OneTEDBContext : DbContext
    {

        public OneTEDBContext() : base("OneTEConnection")
        {
           // Database.SetInitializer<OneTEDBContext>(null);
        }

        public virtual  DbSet<CustomsResponseDetail> CustomsResponseDetail { get; set; }
        public virtual DbSet<EzyExportPermit> EzyExportPermit { get; set; }
        public virtual DbSet<EzyInvoiceExpDetail> EzyInvoiceExpDetail { get; set; }
        public virtual DbSet<EzyInvoiceExpHeader> EzyInvoiceExpHeader { get; set; }
        public virtual DbSet<EzyMonitorExpHeader> EzyMonitorExpHeader { get; set; }
        public virtual DbSet<UdcDetails> UdcDetails { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<PortAreaCode> PortAreaCode { get; set; }
        public virtual DbSet<FTPFileDataList> FTPFileDataList { get; set; }
        public virtual DbSet<CustomsBroker> CustomsBroker { get; set; }

        public virtual DbSet<EZYReportExportMonitor_WinService> EZYReportExportMonitor_WinService { get; set; }

        public void Update(object obj)
        {
            this.Entry(obj).State = EntityState.Modified;

        }
        public void Add(object obj)
        {
            this.Entry(obj).State = EntityState.Added;
        }
        public void Delete(object obj)
        {
            this.Entry(obj).State = EntityState.Deleted;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EzyMonitorExpHeader>().ToTable("EzyMonitorExpHeader");
        }
    }
}
