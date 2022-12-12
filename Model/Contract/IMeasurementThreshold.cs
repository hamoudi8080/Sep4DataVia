namespace Model.Contract;

public interface IMeasurementThreshold
{
    Task<Co2Threshold> GetCo2Async(string Mui);
    Task<Co2Threshold> postCo2Threshold(string mui);

}