using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model;

public class Threshold
{
    [Key]
    public int ThresholdId { get; set; }


    [JsonIgnore]
    public MashroomRoom? mui { get; set; }
    public DateTime Timestamp { get; set; }


    public Decimal TemperatureMinLevel { get; set; }
    public Decimal TemperatureMaxLevel { get; set; }

    public Decimal HumidityMinLevel { get; set; }
    public Decimal HumidityMaxLevel { get; set; }


    public Decimal Co2MinLevel { get; set; }
    public Decimal Co2MaxLevel { get; set; }
    public Decimal LightMinLevel { get; set; }
    public Decimal LightMaxLevel { get; set; }
    
    
   
}