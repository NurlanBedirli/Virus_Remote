using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virus_Remote.Models;

namespace Virus_Remote.Data
{
    public class RemoteDbContext : DbContext
    {
        public RemoteDbContext(DbContextOptions<RemoteDbContext> options) : base(options) { }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Redirect> Redirects { get; set; }
        public DbSet<UserRedirect> UserRedirects { get; set; }
        public DbSet<Settings> Settings { get; set; }
    }
}
