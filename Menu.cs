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
                        updateSerie();
                        retornarMenuPrincipal();
                        break;
                    case "4":
                        deleteSerie();
                        retornarMenuPrincipal();
                        break;
                    case "5":
                        viewSerie();
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

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("|  ID  |  Título                                         |  Status       |");
            Console.WriteLine("--------------------------------------------------------------------------");
            foreach (var serie in list)
            {
                string status = "Ativa";

                if (serie.returnStatus())
                {
                    status = "Excluída";
                }

                Console.Write("|  ");
                Console.Write(serie.returnId().ToString().PadRight(4, ' '));
                Console.Write("|  ");
                Console.Write(serie.returnTitle().ToString().PadRight(47, ' '));
                Console.Write("|  ");
                Console.Write(status.PadRight(13, ' '));
                Console.Write("|");
                Console.WriteLine("");
                // Console.WriteLine("{0} | {1}", serie.returnId(), serie.returnTitle());
            }
            Console.WriteLine("--------------------------------------------------------------------------");
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
            Console.WriteLine("   ------------------------------");
            Console.WriteLine("   | Série incluída com sucesso |");
            Console.WriteLine("   ------------------------------");

        }

        private static void updateSerie()

        {
            int insertedId = -1;
            int insertedGender = 0;
            string insertedTitle = "";
            int insertedYear = 0;
            string insertedDescription = "";


            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção 3 - Atualizar série");
            Console.WriteLine("");

            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Informe o id da série que deseja atualizar.");
                Console.Write("--> ");

                int.TryParse(Console.ReadLine(), out insertedId);

                if (insertedId < 0 || insertedId > repository.NextId() - 1)
                {
                    insertedId = -1;

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("ATENÇÃO: ID não localizado!");
                    return;
                }

            } while (insertedId == -1);

            Console.WriteLine("");
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

            Serie updatedSerie = new Serie(id: insertedId,
                                       gender: (Gender)insertedGender,
                                       title: insertedTitle,
                                       year: insertedYear,
                                       description: insertedDescription);

            try
            {
                repository.Update(insertedId, updatedSerie);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }

            Console.WriteLine("");
            Console.WriteLine("   --------------------------------");
            Console.WriteLine("   | Série atualizada com sucesso |");
            Console.WriteLine("   --------------------------------");

        }

        private static void deleteSerie()
        {
            int insertedId = -1;


            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção 4 - Atualizar série");
            Console.WriteLine("");

            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Informe o id da série que deseja excluir.");
                Console.Write("--> ");

                int.TryParse(Console.ReadLine(), out insertedId);


                if (insertedId < 0 || insertedId > repository.NextId() - 1 || repository.GetSerieById(insertedId).returnStatus())
                {
                    insertedId = -1;

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("ATENÇÃO: ID não localizado!");
                    return;
                }

            } while (insertedId == -1);

            string confirmDelete = "";

            do
            {
                Console.WriteLine("");
                Console.WriteLine("ATENÇÃO: Deseja mesmo excluír esta série? 1 - SIM | 2 - NÃO");
                Console.Write("--> ");
                confirmDelete = Console.ReadLine();

                switch (confirmDelete)
                {
                    case "1":
                        try
                        {
                            repository.Delete(insertedId);
                        }
                        catch (System.Exception e)
                        {
                            throw new Exception(e.Message);
                        }

                        Console.WriteLine("");
                        Console.WriteLine("   ------------------------------");
                        Console.WriteLine("   | Série excluída com sucesso |");
                        Console.WriteLine("   ------------------------------");

                        break;
                    case "2":
                        Console.WriteLine("");
                        Console.WriteLine("Operação cancelada!");
                        break;

                    default:
                        confirmDelete = "";
                        break;
                }
            } while (confirmDelete.Equals(""));
        }

        private static void viewSerie()
        {
            int insertedId = -1;


            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Opção 5 - Visualizar série");
            Console.WriteLine("");

            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Informe o id da série que deseja visualizar.");
                Console.Write("--> ");

                int.TryParse(Console.ReadLine(), out insertedId);

                if (insertedId < 0 || insertedId > repository.NextId() - 1)
                {
                    insertedId = -1;

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("ATENÇÃO: ID não localizado!");
                    return;
                }

            } while (insertedId == -1);

            try
            {
                var serie = repository.GetSerieById(insertedId);

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(serie);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}