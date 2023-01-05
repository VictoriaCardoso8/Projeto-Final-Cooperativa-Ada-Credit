using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada_Credit.UseCasesClient
{
    public class ClientConsult
    {
        public static void Execute()
        {

            Console.Clear();
            Console.Write("Insira o nome do cliente: ");
            var name = Console.ReadLine();
            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)));
            var csvPath = Path.Combine(path, "ClientList.csv");
            var result = Repositories.ClientRepositories.ListOfClients.FirstOrDefault(x => x.Name == name);
            if (result != null)
            {
                var clients = from c in Repositories.ClientRepositories.ListOfClients
                              where c.Name == name
                              select c;

                foreach (var c in clients)
                {
                    if (c.Active)
                        Console.Clear();
                    Console.WriteLine("Cliente ativo!");
                    Console.WriteLine($"Cliente de nome:{c.Name}");
                    Console.WriteLine($"Cliente possui CPF:{c.Document}");
                    Console.WriteLine($"Cliente possui numero de conta:{c.Account.Number}");
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cliente não encontrado!");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }
    }
}
