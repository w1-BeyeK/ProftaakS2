using Webapp.Models;

namespace Webapp.Repository
{
    public interface ILoginRepository
    {
        LoginResult Login(string username, string password);
        void Logout();
    }
}