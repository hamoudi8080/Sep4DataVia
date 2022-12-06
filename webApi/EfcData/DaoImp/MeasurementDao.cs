using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Contract;
using WebAPI.EfcData.DataAccess;

namespace WebAPI.EfcData.DaoImp;

public class MeasurementDao : IMeasurement
{
    private readonly DataAccess1 dbContext;

    public MeasurementDao(DataAccess1 dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddMeasurements(string Mui, IEnumerable<Measurements> measurements)
    {
        using (SqlConnection connection =
               new SqlConnection(
                   connectionString:
                   "Server=LAPTOP-038MJ8RP;Database=Sep4Data;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true"))
        {
            var query =
                "IF NOT EXISTS (SELECT * FROM dbo.Measurements where [Timestamp] = @timestamp_formatted AND ) " +
                "INSERT INTO dbo.Measurements(Timestamp, Temperature, Humidity, Co2,LightLevel ) " +
                "VALUES (@timestamp,@temperature,@humidity,@co2,@LightLevel) ";

            connection.Open();

            foreach (var measurement in measurements)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var formattedTimestamp =
                        $"{measurement.Timestamp.Year}-{measurement.Timestamp.Month}-{measurement.Timestamp.Day} {measurement.Timestamp.TimeOfDay}";
                    Console.WriteLine(formattedTimestamp);
                    command.Parameters.AddWithValue("@timestamp", measurement.Timestamp);
                    command.Parameters.AddWithValue("@timestamp_formatted", formattedTimestamp);
                    command.Parameters.AddWithValue("@temperature", measurement.Temperature);
                    command.Parameters.AddWithValue("@humidity", measurement.Humidity);
                    command.Parameters.AddWithValue("@co2", measurement.Co2);
                    command.Parameters.AddWithValue("@LightLevel",measurement.LightLevel);

                    var result = command.ExecuteNonQuery();

                    if (result < 0)
                    {
                        throw new ArgumentException("Could not insert new query");
                    }
                }
            }

            connection.Close();
        }
    }
}


/*
    public async Task<Measurements> GetMeasurementAsync(string mui)
    {
       
        var mushroom = await database.MushroomRooms.Include(m => m.Measurements)
            .FirstOrDefaultAsync(p => p.MusId.Equals(mui));
            
        if (mushroom == null)
        {
            throw new Exception("data NotFound");
        }
            
        var measurement = mushroom.Measurements.LastOrDefault();
            
        if (measurement is null)
        {
            throw new Exception("MeasurementNotFound");
        }
            
        return measurement;
    }

    public async Task<List<Measurements>> GetMeasurementHistoryAsync(string eui)
    {
        var dateTime = DateTime.Now.AddDays(-45);
            
        await using var database = new DataAccess1();
        var mushroom = await database.MushroomRooms.Include(m => m.Measurements)
            .FirstOrDefaultAsync(m => m.MusId.Equals(eui));
            
        if (mushroom == null)
        {
            throw new Exception("Data NotFound");
        }
            
        var measurements = mushroom.Measurements
            .Where(m => DateTime.Compare(m.Timestamp, dateTime) >= 0).ToList();

        if (!measurements.Any())
            throw new Exception("MeasurementNotFound");
        return measurements;
    }*/
