namespace HW_20.Domain.Contract.Service
{
    public interface IAuthenticationAppService
    {
        bool Login(string userName, string phoneNumber);

    }
}

