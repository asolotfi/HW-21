namespace HW_20.Domain.Contract.Repositoris
{
    public interface IAuthenticationRepository
    {
        bool Login(string userName, string phoneNumber);

    }
}
