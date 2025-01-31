

using HW_20.Domain.Contract.AppService;
using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Service;

namespace HW_20.Service.AppService
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IAuthenticationService _AuthenticationService;

        public AuthenticationAppService(IAuthenticationService AuthenticationService)
        {
            _AuthenticationService = AuthenticationService;
        }
        public bool Login(string userName, string password)
        {
            var result = _AuthenticationService.Login(userName, password);
            return result;
        }

    
    }
}

