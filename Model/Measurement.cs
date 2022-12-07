using System.ComponentModel.DataAnnotations;

namespace Model;

public class Measurements
{
    [Key]
    public int MeasureId { get; set; }
    
  
    public DateTime Timestamp { get; set; }


    public Decimal Temperature { get; set; }

    public Decimal Humidity { get; set; }


    public Decimal Co2 { get; set; }
    

    public decimal LightLevel { get; set; }
    
    public override string ToString()
    {
        return $"MEASUREMENT => TIMESTAMP = {Timestamp}," +
               $" TEMPERATURE = {Temperature}, HUMIDITY = {Humidity}, CO2 = {Co2}";
    }
    
    
}