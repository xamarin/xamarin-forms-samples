using System.Collections.Generic;

namespace BindableLayoutDemo.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> TopFollowers { get; set; }
        public IEnumerable<string> FavoriteTech { get; set; }
    }
}
