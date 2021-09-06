using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeekOpdrachtSecurity.API.DbContexts;
using WeekOpdrachtSecurity.API.Entities;

namespace WeekOpdrachtSecurity.API.Repos
{
    public class SecretRepo : ISecretRepo
    {

        private readonly WeekOpdrachtDbContext _mBDbContext;

        public SecretRepo(WeekOpdrachtDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }

        public IEnumerable<Secret> GetAllSecrets()
        {
            return _mBDbContext.Secrets;
        }

        
        
    }
}
