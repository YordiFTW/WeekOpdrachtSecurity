using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeekOpdrachtSecurity.API.Entities;
using WeekOpdrachtSecurity.API.Enums;

namespace WeekOpdrachtSecurity.API.DbContexts
{
    public class WeekOpdrachtDbContext : DbContext
    {
        public WeekOpdrachtDbContext(DbContextOptions<WeekOpdrachtDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Secret> Secrets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "Test1", LastName = "Test1", Username = "test", Password = "test", IsBlocked = false, Role = Role.Civilian, IsAdmin = false, Privilages = SecretClassificationEnum.topsecret },
            new User { Id = 2, FirstName = "Test2", LastName = "Test2", Username = "test2", Password = "test", IsBlocked = false, Role = Role.FBI, IsAdmin = false, Privilages = SecretClassificationEnum.gevoeligeinformatie },
            new User { Id = 3, FirstName = "Test3", LastName = "Test3", Username = "test3", Password = "test", IsBlocked = true, Role = Role.GovermentEmployee, IsAdmin = false, Privilages = SecretClassificationEnum.staatsgeheim },
            new User { Id = 4, FirstName = "Test4", LastName = "Test4", Username = "test4", Password = "test", IsBlocked = false, Role = Role.SecretAgent, IsAdmin = false, Privilages = SecretClassificationEnum.topsecret },
            new User { Id = 5, FirstName = "Admin", LastName = "Admin", Username = "admin", Password = "admin", IsBlocked = false, Role = Role.Civilian, IsAdmin = true,  Privilages = SecretClassificationEnum.gevoeligeinformatie }
            );

            modelBuilder.Entity<Secret>().HasData(
                new Secret { Id = 1, Context = "Lorem Ipsum1", Classification = SecretClassificationEnum.gevoeligeinformatie },
                new Secret { Id = 2, Context = "Lorem Ipsum2", Classification = SecretClassificationEnum.staatsgeheim },
                new Secret { Id = 3, Context = "Lorem Ipsum3", Classification = SecretClassificationEnum.topsecret },
                new Secret { Id = 4, Context = "Lorem Ipsum4", Classification = SecretClassificationEnum.gevoeligeinformatie },
                new Secret { Id = 5, Context = "Lorem Ipsum5", Classification = SecretClassificationEnum.staatsgeheim },
                new Secret { Id = 6, Context = "Lorem Ipsum6", Classification = SecretClassificationEnum.topsecret }
                );
        }
    }
}
