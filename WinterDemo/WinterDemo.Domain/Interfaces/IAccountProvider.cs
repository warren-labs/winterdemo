using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WinterDemo.Domain.Models;

namespace WinterDemo.Domain.Interfaces
{
    public interface IAccountProvider
    {
        Task<User> GetAuthorizationAsync(string email);
        //bool IsAnExistingUser(string userName);
        //bool IsValidUserCredentials(string userName, string password);
        string GetUserRole(string userName);
    }
}
