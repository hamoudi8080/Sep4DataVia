namespace Model.Contract;

public interface ICo2Threshhold
{
    Task<Co2Threshold> GetCO2Async(string mui);
    Task<IList<Co2Threshold>> GetListOfCo2Async(string mui);


}