﻿using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Modelos; 

public class Artista 
{
    public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();
    public virtual ICollection<AvaliacaoArtista> avaliacoes { get; set; } = new List<AvaliacaoArtista>();
    public Artista(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
    }
    public Artista(string nome) { 

         Nome = nome;
    }
    public Artista()
    {
    }
    public string Nome { get; set; }
    public string FotoPerfil { get; set; }
    public string Bio { get; set; }
    public int Id { get; set; }

    

    public void AdicionarMusica(Musica musica)
    {
        Musicas.Add(musica);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do artista {Nome}");
        foreach (var musica in Musicas)
        {
            Console.WriteLine($"Música: {musica.Nome} - Ano de Lançamento: {musica.AnoLancamento}" );
            
        }
    }

    public void AdicionarNota(int pessoaId, int nota)
    {
        nota = Math.Clamp(nota, 1, 5);
        avaliacoes.Add(new AvaliacaoArtista (){ArtistaId = this.Id, PessoaId = pessoaId, Nota = nota});
    }

    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
    }
}