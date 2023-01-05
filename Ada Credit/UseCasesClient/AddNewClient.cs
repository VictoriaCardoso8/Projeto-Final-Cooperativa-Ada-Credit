using Ada_Credit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada_Credit.UseCasesClient
{
    internal class AddNewClient
    {
        public static void Execute()
        {
            Console.Clear();
            Console.WriteLine("CADASTRO DE NOVO CLIENTE");
            Console.Write("Insira o nome do Cliente:");
            var name = Console.ReadLine();
            Console.Write("Insira o CPF do cliente:");
            var document = Console.ReadLine();
            var client = new Client(name, document);
            var account = new Account();
            Repositories.ClientRepositories.AddClient(client, account);
            Console.Clear();
            Console.Write("Cliente cadastrado com sucesso!");
            Console.ReadKey();
        }

        //criar aqui a checagem se existe;
    }
}
