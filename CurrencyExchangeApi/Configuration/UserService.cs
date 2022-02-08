using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchangeApi
{
    public interface IUserService
    {
        bool ValidateCredentials(String username, String password);
    }
    public class UserService : IUserService
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("admin") && password.Equals("Pa$$WoRd");
        }
    }
}
