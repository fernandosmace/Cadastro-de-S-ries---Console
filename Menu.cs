using System;
using System.Threading;

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
                        retornarMenuPrincipal();
                        break;
                    case "2":

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
    }
}