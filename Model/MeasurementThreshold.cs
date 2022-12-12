using System.ComponentModel.DataAnnotations;

namespace Model.Contract;

public class MeasurementThreshold
{
    [Key]
    public int Id { get; set; }

    public Co2Threshold? Threshold { get; set; }
    public decimal MinValue { get; set; }
    public decimal MaxValue { get; set; }
    
}