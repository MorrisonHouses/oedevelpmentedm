using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OEWebApplicationApp.Models;
using OEWebApplicationApp;

namespace OEWebApplicationApp;

public partial class MorrisonHomesContext : DbContext
{
    public MorrisonHomesContext()
    {
    }

    public MorrisonHomesContext(DbContextOptions<MorrisonHomesContext> options)
        : base(options)
    {
    }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=MORSQL;Initial Catalog=MorrisonHomes;User Id=bpm_user;Password=resu_mpb1; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public DbSet<OEWebApplicationApp.Models.TblCgyoeModel>? TblCgyoeModel { get; set; }
    public DbSet<OEWebApplicationApp.Models.ViewGlaccountModel>? ViewGlaccountModel { get; set; }
    public DbSet<OEWebApplicationApp.Models.VendorModel>? VendorModel { get; set; }
    public DbSet<OEWebApplicationApp.Models.ImageModel>? ImageModel { get; set; }
}
