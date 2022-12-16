namespace Model.Contract;

public class TemperatureThreshold
{
    public int Id { get; set; }
    
    public decimal TempratureLevel { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Location { get; set; }
        
    public string MusId { get; set; }

   
}