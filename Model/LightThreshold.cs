using System.ComponentModel.DataAnnotations;

namespace Model.Contract;

public class LightThreshold
{
    [Key]
    public int Id { get; set; }
    
    public decimal LightLevel { get; set; }
    public DateTime TimeStamp { get; set; }
        
    public string MusId { get; set; }

    public override string ToString()
    {
        return $"Light: TIMESTAMP: {TimeStamp}, Light level: {LightLevel}, ID: {Id},MUSID: {MusId}";
    }
}