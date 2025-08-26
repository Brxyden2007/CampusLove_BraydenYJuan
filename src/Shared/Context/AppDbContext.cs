using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CampusLove.src.Modules.Usuario.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.intereses.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.likes.Domain.Entities;
using CampusLove_BraydenYJuan.src.Modules.matches.Domain.Entities;
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
            // Configuración para la tabla de unión UsuarioInteres
            modelBuilder.Entity<UsuarioInteres>(entity =>
            {
                entity.ToTable("interesusuario");
                entity.HasKey(e => new { e.UsuarioId, e.InteresId });
                
                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioIntereses)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_interesusuario_usuarios");
                    
                entity.HasOne(d => d.Interes)
                    .WithMany(p => p.UsuarioIntereses)
                    .HasForeignKey(d => d.InteresId)
                    .HasConstraintName("FK_interesusuario_intereses");
            });

            // Configuración para la entidad Match
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasOne(m => m.Usuario1)
                    .WithMany(u => u.Matches1)
                    .HasForeignKey(m => m.Usuario1Id)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Usuario2)
                    .WithMany(u => u.Matches2)
                    .HasForeignKey(m => m.Usuario2Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración para la entidad Like
            modelBuilder.Entity<Like>(entity =>
            { 
                entity.HasOne(l => l.UsuarioDador)
                    .WithMany(u => u.LikesDados)
                    .HasForeignKey(l => l.UsuarioDadorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.UsuarioReceptor)
                    .WithMany(u => u.LikesRecibidos)
                    .HasForeignKey(l => l.UsuarioReceptorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            // Si tienes clases de configuración separadas, descomenta esta línea:
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}