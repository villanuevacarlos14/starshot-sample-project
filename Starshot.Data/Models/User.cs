using System;
using Starshot.Data.Models.Base;

namespace Starshot.Data.Models
{
    public class User : BaseEntity
    {
        public User()
        {
        }

        public string UserName { get; set; }
        public string HashedPassword { get; set; }
    }
}
