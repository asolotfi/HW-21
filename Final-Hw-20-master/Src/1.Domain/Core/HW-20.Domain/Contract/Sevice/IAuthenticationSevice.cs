namespace HW_20.Domain.Contract.Service
{
    public interface IAuthenticationService
    {
        bool Login(string userName, string phoneNumber);
        bool ValidateApiKey(string apiKey);
    }
}

