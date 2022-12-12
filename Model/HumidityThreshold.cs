using System.ComponentModel.DataAnnotations;

namespace Model;

public class HumidityThreshold
{
    [Key]
    public int Id { get; set; }
    
    [Range(80, 90)]
    public decimal HumidityLevel { get; set; }
    
    public DateTime TimeStamp { get; set; }
        
    public string MusId { get; set; }

    public override string ToString()
    {
        return $"Humidity: TIMESTAMP: {TimeStamp}, HumidityLevel: {HumidityLevel}, ID: {Id},MUSID: {MusId}";
    }
}