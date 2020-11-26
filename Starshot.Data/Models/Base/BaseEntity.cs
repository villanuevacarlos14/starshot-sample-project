using System;
namespace Starshot.Data.Models.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.DateCreated = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
