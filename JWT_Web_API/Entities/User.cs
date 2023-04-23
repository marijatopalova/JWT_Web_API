using System.ComponentModel.DataAnnotations;

namespace JWT_Web_API.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
