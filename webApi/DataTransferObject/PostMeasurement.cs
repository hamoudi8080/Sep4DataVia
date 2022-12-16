using Model;

namespace WebAPI.DataTransferObject;

public class PostMeasurement
{
    public string Mui { get; set; }
    public IList<Measurement> Measurements { get; set; } = new List<Measurement>();
}