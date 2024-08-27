using FrontEnd.ApiModel;
using FrontEnd.ApiModels;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ISecurityHelper
    {
        LoginAPI GetUser(UserViewModel user);
        LoginAPI Login(UserViewModel user);
        bool Register(UserViewModel user);
        UserProfile GetUserProfile(string username);
        public bool Logout();
    }
}
