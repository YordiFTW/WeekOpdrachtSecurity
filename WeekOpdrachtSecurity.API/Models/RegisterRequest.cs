using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeekOpdrachtSecurity.API.Enums;

namespace WeekOpdrachtSecurity.API.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        //public bool IsBlocked { get; set; }

        //public bool IsAdmin { get; set; }

        [Required]

        public UserTypeEnum UserType { get; set; }
    }
}
