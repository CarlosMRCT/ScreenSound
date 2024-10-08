using ScreenSound.Banco;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus
{
    internal class MenuMostratMusicaPorAno:Menu
    {
        public override void Executar(DAL<Artista> artistaDAL)
        {
            base.Executar(artistaDAL);
            ExibirTituloDaOpcao("Exibindo as musicas por ano");
            Console.WriteLine("Digite o ano para consultar as músicas: ");
            string anoLancamento = Console.ReadLine();
            var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
            var listarAnoLancamento = musicaDAL.ListarPor(a => a.AnoLancamento == Convert.ToInt32(anoLancamento));
            if (listarAnoLancamento.Any())
            {
                Console.WriteLine($"\nMusicas do ano {anoLancamento}");
                foreach (var musica in listarAnoLancamento)
                {
                    musica.ExibirFichaTecnica();
                }
                Console.WriteLine("\n Digite qualquer tecla para voltar ao menu principal: ");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"\nO ano {anoLancamento} não foi encontrado: ");
                Console.WriteLine("\n Digite qualquer tecla para voltar ao menu principal: ");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
