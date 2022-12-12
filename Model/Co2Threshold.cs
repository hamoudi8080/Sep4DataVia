using System.ComponentModel.DataAnnotations;
using Model.Contract;

namespace Model;

public class Co2Threshold
{
    
    [Key]
    public int Id { get; set; }
    
    
    [Range(10,100)] 
    public decimal Co2Level { get; set; }
    public DateTime TimeStamp { get; set; }
    
  
        
    public string MUSID { get; set; }

    public override string ToString()
    {
        return $"CO2: TIMESTAMP: {TimeStamp}, CO2 MinLevel{Co2Level}, ID: {Id},EUI: {MUSID}";
    }
        
}
