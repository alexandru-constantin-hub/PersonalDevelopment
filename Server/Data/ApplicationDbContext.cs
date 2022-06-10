using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PersonalDevelopment.Server.Models;
using PersonalDevelopment.Shared.Models;

namespace PersonalDevelopment.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public virtual DbSet<Objective> Objectives { get; set; }
        public virtual DbSet<Value> Value { get; set; }

        public virtual DbSet<Tak> Taks { get; set; }

        public virtual DbSet<ValueObjectiveTak> ValueObjectiveTaks { get; set;}

    }
}