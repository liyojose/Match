using System.Threading.Tasks;
using Match.API.V1.Model;
using System.Linq;

namespace Match.API.V1.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        AuthRepository(DataContext context)
        {
            this._context = context;
        }
        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordhash,passwordsalt;
            CreatepasswordHash(password,out passwordhash,out passwordsalt);
            user.Passwordhash = passwordhash;
            user.Passwordsalt = passwordsalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatepasswordHash(string password,out  byte[] passwordhash,out  byte[] passwordsalt)
        {
                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordsalt= hmac.Key;
                    passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                }
        }

        public async Task<bool> UserExists(string username)
        {
          return   _context.Users.Any(u => u.Username == username);
        }
    }
    public interface IAuthRepository
    {
        Task<User> Register(User user,string password);
        Task<User> Login(string username,string password);
        Task<bool> UserExists(string username);
    }
}