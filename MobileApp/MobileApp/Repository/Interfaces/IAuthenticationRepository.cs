using MobileApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Repository.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<Result<string>> Login(string email, string password);
    }
}
