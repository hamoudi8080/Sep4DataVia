namespace Model.Contract;

public interface IMushroom
{
    Task<MashroomRoom> GetMeasurementById(MashroomRoom mushroom);
   
    Task<MashroomRoom> DeleteMushroomAsync(string mui);
    
    
}