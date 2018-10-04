using MobileApp.Repository.Interfaces;
using MobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IAuthenticationRepository _authenticationRepository;
        private List<IAuthRepository> _repositories = new List<IAuthRepository>();

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _authenticationRepository.Login(email, password);

            // Inject token into authorization headers
            if (result.Success)
            {
                _repositories.ForEach((x) =>
                {
                    // Temporary token for this requests
                    x.InjectAuthorizationHeader(Config.TempAccessToken);
                });
            }

            return result.Success;
        }

        public void InjectAuthorization(IAuthRepository authRepository)
        {
            if (!_repositories.Contains(authRepository))
            {
                _repositories.Add(authRepository);
            }
        }
    }
}
