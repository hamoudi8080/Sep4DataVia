namespace Model.Contract;

public interface IMushroom
{
    Task<MashroomRoom> PostPlantAsync(MashroomRoom mashroom);
    Task<MashroomRoom> GetPlantByDeviceAsync(string mui);
    Task<MashroomRoom> DeletePlantAsync(string mui);
}
    
    
