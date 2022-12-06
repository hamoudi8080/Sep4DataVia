using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text.Json.Serialization;

namespace Model;

public class MashroomRoom
{
    [Key]
    [StringLength(50)]
    public string MusId { get; set; }
    
    [StringLength(50)] 
    public string name { get; set; }
    
    [JsonIgnore]
    public ICollection<Measurements> Measurements { get; set; } 
}