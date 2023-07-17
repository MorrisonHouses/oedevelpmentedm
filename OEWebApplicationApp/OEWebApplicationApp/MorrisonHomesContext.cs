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
