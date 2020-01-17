using System.ComponentModel.DataAnnotations;

namespace Match.API.V1.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Passwordsalt { get; set; }
        public byte[] Passwordhash { get; set; }
    }
    public class UserForRegDto
    {
        [Required] 
               public string Username { get; set; }
                 [Required] 

        public string Password { get; set; }
    }
}