using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();   

        static void Main(string[] args)
        {
           string opçãoUsuario=ObterOpcaoUsuario();

            while (opçãoUsuario.ToUpper() !="X")
            {
                switch(opçãoUsuario)
                {
                case "1":
                    listaSeries();
                break;
                case "2":
                    InserirSerie();
                break;
                case "3":
                    AtualizarSerie();
                break;
                case "4":
                    ExcluirSerie();
                break;
                case "5":
                    VisualizarSerie();
                break;
                case "C":
                    //Console.Clear();
                break;
                default:
                    throw new ArgumentOutOfRangeException();
               
                }
                opçãoUsuario= ObterOpcaoUsuario();
            }


        }

        private static void listaSeries()
        {
            Console.WriteLine("Listar Série");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            
            foreach ( var serie in lista)
            {
                var excluido = serie.retornaExcluido();
               
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(),(excluido ? "*Excluído*" : ""));
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int inGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série:");
            string inTitulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição da série:");
            string inDescricao = Console.ReadLine();

            Console.WriteLine("Digite o ano da série:");
            int inAno= int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero de temporadas:");
            int inTemporada = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)inGenero,
                                        titulo: inTitulo,
                                        ano: inAno,
                                        descricao: inDescricao,
                                        temporada: inTemporada);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int inGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série:");
            string inTitulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição da série:");
            string inDescricao = Console.ReadLine();

            Console.WriteLine("Digite o ano da série:");
            int inAno= int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero de temporadas:");
            int inTemporada = int.Parse(Console.ReadLine());

            Serie atualizeSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)inGenero,
                                        titulo: inTitulo,
                                        ano: inAno,
                                        descricao: inDescricao,
                                        temporada: inTemporada);
            repositorio.Atualiza(indiceSerie, atualizeSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da serie que você deseja excluir:");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da serie:");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        



        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Série");
            Console.WriteLine("2- Inserir nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série ");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opçãoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opçãoUsuario;
        }
    }
}
