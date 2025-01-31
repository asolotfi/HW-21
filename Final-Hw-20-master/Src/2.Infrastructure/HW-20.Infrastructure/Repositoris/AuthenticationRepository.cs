using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Entites.User;
using HW_20.Infrastructure.DB;

namespace HW_20.Infrastructure.Repositoris
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppDbContext _appDbContext;

        public AuthenticationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public bool Login(string userName, string phoneNumber)
        {
            try
            {
                if (_appDbContext.Users.Any(x => x.UserName == userName && x.PhoneNumber == phoneNumber))
                {
                    InMemoryDB.OnlineUser = GetUser(userName);
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                throw new NotImplementedException("User not Found");
            }
        }
        public User GetUser(string userName)
        {
            User user = _appDbContext.Users
           .Where(c => c.UserName == userName)
           .FirstOrDefault();
            return user;

        }

    }
}
