using System.ComponentModel.DataAnnotations;

namespace Model;

public class Measurements
{
    [Key]
    public int MeasureId { get; set; }
    
    [Required]
    public DateTime Timestamp { get; set; }

    [Required]
    public float Temperature { get; set; }
    [Required]
    public int Humidity { get; set; }

    [Required]
    public int Co2 { get; set; }
    
    [Required]
    public decimal LightLevel { get; set; }
    
    
}