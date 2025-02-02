


using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Contract.Service;
using Microsoft.Extensions.Configuration;

namespace HW_20.Service.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly string _apiKey;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IConfiguration configuration)
        {
            _authenticationRepository = authenticationRepository;
            _apiKey = configuration["ApiKey"]; // خواندن apiKey از پیکربندی
        }

        public bool Login(string userName, string password)
        {
            var result = _authenticationRepository.Login(userName, password);
            return result;
        }

        public bool ValidateApiKey(string apiKey)
        {
            return _apiKey == apiKey;
        }
    }
}


