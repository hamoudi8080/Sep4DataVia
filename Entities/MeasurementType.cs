using System.ComponentModel.DataAnnotations;

namespace Entities;

public class MeasurementType
{
    [Key]
    public int measurementTypeId { get; set; }
    public string type { get; set; }
    public decimal minValue { get; set; }
    public decimal maxValue { get; set; }
    
    public ICollection<Measurement> Measurements { get; set; }
    
}