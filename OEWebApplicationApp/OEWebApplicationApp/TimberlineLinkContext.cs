using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OEWebApplicationApp.Models;

namespace OEWebApplicationApp;

public partial class TimberlineLinkContext : DbContext
{
    public TimberlineLinkContext()
    {
    }
    public TimberlineLinkContext(DbContextOptions<TimberlineLinkContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public DbSet<OEWebApplicationApp.Models.ViewGlaccountModel>? ViewGlaccountModel { get; set; }
}
