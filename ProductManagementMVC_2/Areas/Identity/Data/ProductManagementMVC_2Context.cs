using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductManagementMVC_2.Entities;

namespace ProductManagementMVC_2.Data;

public class ProductManagementMVC_2Context : IdentityDbContext<IdentityUser>
{
    public DbSet<Category> Categories { get; set; }

    public ProductManagementMVC_2Context(DbContextOptions<ProductManagementMVC_2Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new CategoryConfiguration());
    }
}
