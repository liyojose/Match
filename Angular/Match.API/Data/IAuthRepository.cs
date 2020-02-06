using System.Threading.Tasks;
using  Match.API.V1.Models;

namespace  Match.API.V1.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);

         Task<User> Login(string username, string password);

         Task<bool> UserExists(string username);
    }
}