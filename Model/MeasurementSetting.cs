using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model;

public class MeasurementSetting
{
    [Key]
    public int MeasurementId { get; set; }
    
    public string MusId { get; set; }
    [Required]
    public DateTime TimeStamp { get; set; }

    [Required]
    public decimal Co2Threshold { get; set; }

    [Required]
    public int HumidityThreshold { get; set; }

    [Required]
    public float TargetTemperature { get; set; }
    
    [Required]
    public decimal LightLevel { get; set; }

    
    
}