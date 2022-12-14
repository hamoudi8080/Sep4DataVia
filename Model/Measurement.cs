using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Model.Contract;

namespace Model;

public class Measurement
{
    [Key]
    
    public int MeasureId { get; set; }

    
    
  
    public DateTime Timestamp { get; set; }


    public Decimal Temperature { get; set; }

    public Decimal Humidity { get; set; }


    public Decimal Co2Level { get; set; }
    public Decimal LightLevel { get; set; }
    
    [JsonIgnore]
    public MashroomRoom? MushroomRoom { get; set; }

    


}