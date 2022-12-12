namespace Model.Contract;

public class TemperatureThreshold
{
    public int Id { get; set; }
    
    public decimal TempratureLevel { get; set; }
    public DateTime TimeStamp { get; set; }
        
    public string MusId { get; set; }

    public override string ToString()
    {
        return $"TemperatureThreshold: TIMESTAMP: {TimeStamp}, Temperature level: {TempratureLevel}, ID: {Id},MusID: {MusId}";
    }
}