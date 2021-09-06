using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeekOpdrachtSecurity.API.Entities;

namespace WeekOpdrachtSecurity.API.Repos
{
    public interface ISecretRepo
    {
        IEnumerable<Secret> GetAllSecrets();
        
    }
}
