namespace Model.Contract;

public interface IThreshold
{
    Task<Threshold> GetThresholdByMushroomId (string mushroomId);
    
    Task<Threshold> PostThresholdAsync(Threshold threshold);
}