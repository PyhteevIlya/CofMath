using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CofMath.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class ApplicationContext : DbContext
{
    public DbSet<Coffee> Coffee { get; set; } = null!;
    public DbSet<Storage> Storage { get; set; } = null!;

    //public ApplicationContext() => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Coffee>().HasData(new Coffee[] { });

        modelBuilder.Entity<Storage>().HasData(new Storage[] { });

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=cofmathdb;Trusted_Connection=True;");
    }
}