namespace API_university_labor_exchange.Services.Interfaces
{
    public interface IEncrypt
    {
        string GetSHA256(string password);
    }
}
