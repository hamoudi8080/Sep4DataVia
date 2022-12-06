using Entities;
using Model;

namespace WebAPI.DataTransferObject;

public class PostMeasurement
{
    public string Mui { get; set; }
    public IList<Measurements> Measurements { get; set; } = new List<Measurements>();
}