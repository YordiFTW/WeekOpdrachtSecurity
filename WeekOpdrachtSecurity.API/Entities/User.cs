using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeekOpdrachtSecurity.API.Enums;

namespace WeekOpdrachtSecurity.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsAdmin { get; set; }

        public Role Role { get; set; }

        public SecretClassificationEnum Privilages { get; set; }
    }
}