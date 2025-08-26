using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.likes.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.matches.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.usuarios_intereses.Domain.Entities;
using CampusLove_BraydenYJuan.src.Shared.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CampusLove_BraydenYJuan.src.Shared.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Like> Likes => Set<Like>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<Interes> Intereses => Set<Interes>();
        public DbSet<UsuarioInteres> UsuarioIntereses => Set<UsuarioInteres>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}