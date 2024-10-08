using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using SoundScreen.Shared.Dados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    public class ScreenSoundContext : IdentityDbContext<PessoaComAcesso, PerfilDeAcesso, int>
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<AvaliacaoArtista> AvaliacaoArtistas { get; set; }

        //declaração da string connectionString com os dados de aceso do banco.
        private string connectionString = "Data Source=(localdb)\\" +
            "MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;" +
            "Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musica>()
                .HasMany(c => c.Generos)
                .WithMany(c => c.Musicas);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AvaliacaoArtista>()
                .HasKey(a => new { a.ArtistaId, a.PessoaId});
        }

    }
}
