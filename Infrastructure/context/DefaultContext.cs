using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.context;
public class DefaultContext : DbContext {
  private readonly ILogger<DefaultContext> _logger;

  public DefaultContext(ILoggerFactory loggerFactory, DbContextOptions<DefaultContext> options) : base(options) {
    _logger = loggerFactory.CreateLogger<DefaultContext>();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    base.OnModelCreating(modelBuilder);
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    base.OnConfiguring(optionsBuilder);
  }

  private static void ConfigureDevelopment(ModelBuilder modelBuilder) {
  }

  private static void ConfigureStaging(ModelBuilder modelBuilder) {
  }

  private static void ConfigureProduction(ModelBuilder modelBuilder) {
  }
}
