using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Repository.Interfaces
{
    public interface IAuthRepository
    {
        void InjectAuthorizationHeader(string token);
    }
}
