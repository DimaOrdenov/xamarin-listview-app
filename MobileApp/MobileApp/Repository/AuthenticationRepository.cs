using MobileApp.Models.Common;
using MobileApp.Repository.Base;
using MobileApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Repository
{
    public class AuthenticationRepository : BaseRepository, IAuthenticationRepository
    {
        public AuthenticationRepository() : base("oauth/v2/token") { }

        public async Task<Result<string>> Login(string email, string password)
        {
            // Temporary login with success code for hard-coded token
            return await Task.Factory.StartNew(()=>
            {
                return new Result<string> { Success = true };
            });
        }
    }
}
