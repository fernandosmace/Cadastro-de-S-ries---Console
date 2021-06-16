using System;
using System.Threading;
using DIO.Series.Classes;

namespace DIO.Series
{
    public class Menu
    {

        static SeriesRepository repository = new SeriesRepository();
        public static void menu()
        {
            Console.Clear();
            string opcao = "";

            while (opcao.Equals(""))
            {
                Console.WriteLine("");
                Console.WriteLine("Bem vindo ao DIO Séries!");
                Console.WriteLine("");
                Console.WriteLine("Informe a opção desejada!");
                Console.WriteLine("   1 - Listar séries");
                Console.WriteLine("   2 - Inserir nova série");
                Console.WriteLine("   3 - Atualizar série");
                Console.WriteLine("   4 - Excluir série");
                Console.WriteLine("   5 - Visualizar série");
                Console.WriteLine("   0 - Sair.");
                Console.WriteLine();
                Console.Write("--> ");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0":
                        finalizar();
                        break;
                    case "1":
                        listSeries();
                        retornarMenuPrincipal();
                        break;
                    case "2":
                        insertSerie();
                        retornarMenuPrincipal();
                        break;
                    case "3":

                        retornarMenuPrincipal();
                        break;
                    case "4":

                        retornarMenuPrincipal();
                        break;
                    case "5":

                        retornarMenuPrincipal();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Informe uma opção válida.");

                        retornarMenuPrincipal();
                        Console.WriteLine();
                        break;
                }
            }
        }

        private static void finalizar()
        {
            Console.Clear();
            Console.Write("Sistema encerrando.");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.Clear();
            Environment.Exit(0);
        }

        private static void retornarMenuPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");

            Console.ReadKey();
            Console.Clear();

            Menu.menu();
        }

        private static void listSeries()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção 1 - Listar séries ");
            Console.WriteLine("");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("   ----------------------------");
                Console.WriteLine("   | Nenhuma série cadastrada |");
                Console.WriteLine("   ----------------------------");
                return;
            }

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("|  ID  |  Título                                         |");
            Console.WriteLine("----------------------------------------------------------");
            foreach (var serie in list)
            {
                Console.Write("|  ");
                Console.Write(serie.returnId().ToString().PadRight(4, ' '));
                Console.Write("|  ");
                Console.Write(serie.returnTitle().ToString().PadRight(47, ' '));
                Console.Write("|");
                Console.WriteLine("");
                // Console.WriteLine("{0} | {1}", serie.returnId(), serie.returnTitle());
            }
            Console.WriteLine("----------------------------------------------------------");
        }

        private static void insertSerie()
        {
            int insertedGender = 0;
            string insertedTitle = "";
            int insertedYear = 0;
            string insertedDescription = "";


            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção 2 - Inserir nova série");
            Console.WriteLine("");

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Gender), i));
            }

            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Informe o número do gênero da série.");
                Console.Write("--> ");

                int.TryParse(Console.ReadLine(), out insertedGender);

                if (insertedGender < 0 || insertedGender > Enum.GetNames(typeof(Gender)).Length)
                {
                    insertedGender = 0;

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("ATENÇÃO: Informe um gênero válido!");
                }

            } while (insertedGender == 0);

            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Informe o título da série.");
                Console.Write("--> ");
                insertedTitle = Console.ReadLine();

                if (insertedTitle.Equals(""))
                {
                    insertedTitle = "";

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("ATENÇÃO: O título não pode ser em branco!");
                }

            } while (insertedTitle.Equals(""));

            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Informe o ano de início da série com 4 dígitos.");
                Console.Write("--> ");

                int.TryParse(Console.ReadLine(), out insertedYear);

                if (insertedYear.ToString().Length != 4)
                {
                    insertedYear = 0;

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("ATENÇÃO: Informe o ano com 4 dígitos!");
                }

            } while (insertedYear == 0);

            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Informe a descrição da série.");
                Console.Write("--> ");
                insertedDescription = Console.ReadLine();

                if (insertedDescription.Equals(""))
                {
                    insertedDescription = "";

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("ATENÇÃO: A descrição não pode ser em branco!");
                }

            } while (insertedDescription.Equals(""));

            Serie newSerie = new Serie(id: repository.NextId(),
                                       gender: (Gender)insertedGender,
                                       title: insertedTitle,
                                       year: insertedYear,
                                       description: insertedDescription);

            try
            {
                repository.Insert(newSerie);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }

            Console.WriteLine("");
            Console.WriteLine("   ------------------------------"); ;
            Console.WriteLine("   | Série incluída com sucesso |");
            Console.WriteLine("   ------------------------------");

        }
    }
}