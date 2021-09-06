using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeekOpdrachtSecurity.API.Enums;

namespace WeekOpdrachtSecurity.API.Entities
{
    public class Secret
    {
        public int Id { get; set; }

        public SecretClassificationEnum Classification { get; set; }

        public string Context { get; set; }
    }
}
