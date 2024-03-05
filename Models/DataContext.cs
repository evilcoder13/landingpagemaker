
using Microsoft.EntityFrameworkCore;

namespace landingpagemaker.Models;

public class DataContext:DbContext {
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }
    public virtual DbSet<Log> Logs { get; set; }
    public virtual DbSet<LandingPage> LandingPages { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<LandingPageStat> LandingPageStats { get; set; }
}