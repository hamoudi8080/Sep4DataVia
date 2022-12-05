using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Measurement
{
    [Key]
    public int Id { get; set; }
        
    public DateTime TimeStamp { get; set; }
        //decimal takes up to 128 Bits 29 digits
    public decimal Temperature { get; set; }
        
    public decimal Humidity { get; set; }
        
    public decimal CO2 { get; set; }
        
    public decimal Light { get; set; }
}