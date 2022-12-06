namespace Model.Contract;

public interface IMushroom
{
    Task<MashroomRoom> PostMushroomAsync(MashroomRoom mushroom);
   
    Task<MashroomRoom> DeleteMushroomAsync(string mui);
}