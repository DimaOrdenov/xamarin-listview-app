using MobileApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);

        void InjectAuthorization(IAuthRepository authRepository);
    }
}
