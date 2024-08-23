using Domain.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]

        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        [Required]
        [JsonIgnore]
        public string Password { get; set; }
        
        public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();
    }
}
