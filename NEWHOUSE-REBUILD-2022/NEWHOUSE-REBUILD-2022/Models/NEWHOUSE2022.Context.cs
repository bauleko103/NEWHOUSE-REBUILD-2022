﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NEWHOUSE_REBUILD_2022.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NEWHOUSE2022Entities : DbContext
    {
        public NEWHOUSE2022Entities()
            : base("name=NEWHOUSE2022Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<CongNghe> CongNghes { get; set; }
        public virtual DbSet<DoiTac> DoiTacs { get; set; }
        public virtual DbSet<DUAN> DUANs { get; set; }
        public virtual DbSet<GiaiPhap> GiaiPhaps { get; set; }
        public virtual DbSet<IconXaHoi> IconXaHois { get; set; }
        public virtual DbSet<KT> KTS { get; set; }
        public virtual DbSet<KTS_DUAN> KTS_DUAN { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<LoiGioiThieu> LoiGioiThieux { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TinhNang> TinhNangs { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<ThongTinKhach> ThongTinKhaches { get; set; }
    }
}
