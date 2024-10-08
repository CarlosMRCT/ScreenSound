namespace ScreenSound.API.Requests
{
    public record MusicaRequestEdit(int id, string nome, int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null) : MusicaRequest(nome, ArtistaId, anoLancamento);
}
