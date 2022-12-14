using Microsoft.EntityFrameworkCore;
using Model;
using Model.Contract;

namespace WebAPI.EfcData.DataAccess;

public class DataAccess1:DbContext
{
    public DbSet<MashroomRoom>? MushroomRooms { get; set; }
    public DbSet<MeasurementThreshold> MeasurementThresholds { get; set; }
    public DbSet<Measurements> Measurements { get; set; }   
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer(ConnectionString.GetConnectionStringFromEnvironment());


        optionsBuilder.UseSqlServer("Server=LAPTOP-038MJ8RP;Database=Sep4DataBase;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        
     
        
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