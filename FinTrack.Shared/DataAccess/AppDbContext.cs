using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinTrack.Shared.DataAccess;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
    public DbSet<CostLog> CostLogs { get; set; }
    public DbSet<Asset> Assets { get; set; }

}
