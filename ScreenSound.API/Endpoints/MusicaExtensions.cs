using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class MusicaExtensions
    {
        public static void AddEndPointMusicas(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("musicas").RequireAuthorization().WithTags("Musicas");
            #region
            groupBuilder.MapGet("", ([FromServices] DAL<Musica> dal, [FromServices] DAL<Artista> dalArtista) =>
            {
                var artistas = dalArtista.Listar();
                   var musicaList = dal.Listar().Select(m => {
                    var artista = artistas.FirstOrDefault(a => m.ArtistaId == a.Id);
                    m.Artista = artista;
                    return m;
                    });
                if (musicaList is null)
                {
                    return Results.NotFound();
                }
                var musicaListResponse = EntityListToResponseList(musicaList);
                return Results.Ok(musicaListResponse);
            });

            groupBuilder.MapGet("{nome}", ([FromServices] DAL<Musica> dal, string nome, [FromServices] DAL<Artista> dalArtista) =>
            {

                var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                musica.Artista = dalArtista.Listar().FirstOrDefault(a => musica.ArtistaId == a.Id);
                if (musica is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(EntityToResponse(musica));

            });

            groupBuilder.MapPost("", ([FromServices] DAL<Musica> dal, [FromServices] DAL <Genero> dalGenero,[FromBody] MusicaRequest musicaRequest) =>
            {
                var musica = new Musica(musicaRequest.nome)
                {
                    ArtistaId = musicaRequest.ArtistaId,
                    AnoLancamento = musicaRequest.anoLancamento,
                    Generos = musicaRequest.Generos is not null?
                    GeneroRequestConverter(musicaRequest.Generos, dalGenero):
                    new List<Genero>()
                };
                dal.Adicionar(musica);
                return Results.Ok();
            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<Musica> dal, int id) =>
            {
                var musica = dal.RecuperarPor(a => a.Id == id);
                if (musica is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(musica);
                return Results.Ok();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequestEdit musicaRequestEdit) =>
            {
                var musicaAAtualizar = dal.RecuperarPor(a => a.Id == musicaRequestEdit.id);
                if (musicaAAtualizar is null)
                {
                    return Results.NotFound();
                }
                musicaAAtualizar.Nome = musicaRequestEdit.nome;
                musicaAAtualizar.AnoLancamento = musicaRequestEdit.anoLancamento;

                dal.Atualizar(musicaAAtualizar);
                return Results.Ok();
            });
            #endregion
        }
        private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicaList)
        {
            return musicaList.Select(a => EntityToResponse(a)).ToList();
        }

        private static MusicaResponse EntityToResponse(Musica musica)
        {
            return new MusicaResponse(musica.Id, musica.Nome!, musica?.Artista?.Id, musica?.Artista?.Nome);
        }
            
        private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos, DAL<Genero> dalGenero)
        {
            var listaDeGeneros = new List<Genero>();
            foreach (var item in generos)
            {
                var entity = RequestToEntity(item);
                var genero = dalGenero.RecuperarPor
                    (g => g.Nome.ToUpper().Equals(item.Nome.ToUpper()));
                if (genero is not null)
                {
                    listaDeGeneros.Add(genero);
                }
                else
                {
                    listaDeGeneros.Add(entity);
                }
            }
            return listaDeGeneros;
        }

        private static Genero RequestToEntity(GeneroRequest genero)
        {
            return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao };
        }
    }
}
