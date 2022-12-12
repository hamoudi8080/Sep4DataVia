namespace Model.Contract;

public interface IHumidity
{
    Task<HumidityThreshold> GetHumidity2Async(string mui);
    Task<IList<HumidityThreshold>> GetListOfHumidityAsync(string mui);
}