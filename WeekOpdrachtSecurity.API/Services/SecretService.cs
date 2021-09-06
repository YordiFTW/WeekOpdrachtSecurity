using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeekOpdrachtSecurity.API.DbContexts;
using WeekOpdrachtSecurity.API.Entities;

namespace WeekOpdrachtSecurity.API.Services
{
    public interface ISecretService
    {

        IEnumerable<Secret> GetAllSecrets();
        
    }

    public class SecretService : ISecretService
    {
        private readonly WeekOpdrachtDbContext _mBDbContext;

        public SecretService(WeekOpdrachtDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }

        public IEnumerable<Secret> GetAllSecrets()
        {
            return _mBDbContext.Secrets;
        }
    }
}