namespace Model.Contract;

public interface ILight
{
    Task<LightThreshold> GetLightAsync(string mui);
    Task<IList<LightThreshold>> GetListOfLightAsync(string mui);

}