using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text.Json.Serialization;
using Model.Contract;

namespace Model;

public class MashroomRoom
{
    [Key]
    [StringLength(50)]
    public string MusId { get; set; }
    

    [StringLength(50)] 
    public string Name { get; set; }

    public string Location { get; set; }
    
 
    public IList<Measurement?> Measurements { get; set; } = new List<Measurement?>();
    
    [JsonIgnore]
    public IList<Threshold?> Threshold { get; set; } = new List<Threshold>();
    
    

    public MashroomRoom()
    {
    }
}