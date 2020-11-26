using System;
namespace Starshot.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
    }
}
