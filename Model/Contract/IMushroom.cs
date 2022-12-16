namespace Model.Contract;

public interface IMushroom
{
    Task<MashroomRoom> PostMushroomAsync(MashroomRoom mashroom);
    Task<MashroomRoom> GetPlantByDeviceAsync(string mui);
    Task<MashroomRoom> DeletePlantAsync(string mui);
}
    
    
