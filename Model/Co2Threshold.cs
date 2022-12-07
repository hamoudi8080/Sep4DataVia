using System.ComponentModel.DataAnnotations;

namespace Model;

public class Co2Threshold
{
    
    [Key]
    public int Id { get; set; }
    
    
    [Range(10,100)]
    public decimal CO2Level { get; set; }
    public DateTime TimeStamp { get; set; }
        
    public string MUSID { get; set; }

    public override string ToString()
    {
        return $"CO2: TIMESTAMP: {TimeStamp}, CO2 level: {CO2Level}, ID: {Id},EUI: {MUSID}";
    }
        
}
