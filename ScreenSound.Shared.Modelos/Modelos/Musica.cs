using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Modelos;

public class Musica
{
    public Musica(string nome)
    {
        Nome = nome;
        Id = Id;
    }

    public Musica(string nome, int id, int? anoLancamento, Artista? artista) : this(nome)
    {
        Id = id;
        AnoLancamento = anoLancamento;
        Artista = artista;
    }   

    public Musica()
    {

    }

    public Musica(string nome, int anoLancamento, int artistaId) : this(nome)
    {
    }

    public string Nome { get; set; }
    public int Id { get; set; }
    public int? AnoLancamento { get; set; }
    public virtual Artista? Artista { get; set; }
    public virtual ICollection<Genero> Generos { get; set; }
    public int? ArtistaId { get; set; }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
      
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}