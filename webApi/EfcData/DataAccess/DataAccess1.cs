using Microsoft.EntityFrameworkCore;
using Model;
using Model.Contract;

namespace WebAPI.EfcData.DataAccess;

public class DataAccess1:DbContext
{
    public DbSet<MashroomRoom>? MushroomRooms { get; set; }
    public DbSet<Measurement> Measurements { get; set; }

    public DbSet<Threshold> Thresholds { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer(ConnectionString.GetConnectionStringFromEnvironment());


        optionsBuilder.UseSqlServer("Server=LAPTOP-038MJ8RP;Database=FinalSep4DataBase1;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        
     
        
/*
        optionsBuilder.UseSqlServer @"(connectionstring  = "Data Source = LAPTOP - 038MJ8RP;
        Initial Catalog = Sep4Data;
        User ID = Samar97;
        Password = 1234;
        */

    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
    
    
}