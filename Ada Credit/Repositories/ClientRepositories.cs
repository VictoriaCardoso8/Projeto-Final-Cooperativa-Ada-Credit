using Ada_Credit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using System.IO;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace Ada_Credit.Repositories
{
    internal class ClientRepositories
    {
        static List<Client> ListOfClients = new List<Client>();
        public static void AddClient(Client client, Account account)
        {
            TryClient(client.Name);
            ListOfClients.Add(client);
            var csvPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ClientList.csv");
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(csvPath, true))
            {
                file.WriteLine(client.Name + "," + client.Document + "," + account.Number + "," + client.Active);
            }
        }
        public static void TryClient(string name)
        {
            
            if (ListOfClients.Any(x => x.Name.Equals(name)))
            {
                Console.WriteLine("Cliente já cadastrado");
                return;

            }
        }
        public static void ClientConsult()
        {

            Console.Clear();
            Console.Write("Insira o nome do cliente: ");
            var name = Console.ReadLine();
            var csvPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ClientList.csv");
            var result = ListOfClients.FirstOrDefault(x => x.Name == name);
            if (result != null)
            {
                string[] Lines = System.IO.File.ReadAllLines(csvPath);

                foreach (string Line in Lines)
                {
                    string[] dados = Line.Split(',');
                    string ClientName = dados[0];
                    string ClientDocument = dados[1];
                    string ClientAccount = dados[2];
                    string ClientActive = dados[3];
                    if (ClientName == name && ClientActive == "True")
                    {
                        Console.Clear();
                        Console.WriteLine("Cliente ativo!");
                        Console.WriteLine($"Cliente possui CPF:{ClientDocument}");
                        Console.WriteLine($"Cliente possui numero de conta:{ClientAccount}");
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey();
                        return;
                    }
                    if (ClientName == name && ClientActive == "False")
                    {
                        Console.Clear();
                        Console.WriteLine("Cliente inativo!");
                        Console.WriteLine($"Cliente possui CPF:{ClientDocument}");
                        Console.WriteLine($"Cliente possui numero de conta:{ClientAccount}");
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey();
                        return;
                    }
                }

            }
            Console.Clear();
            Console.WriteLine("Cliente não encontrado!");
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }

        public static void ClientChangeName()
        {
            Console.Clear();
            Console.Write("Insira o nome do cliente que deseja alterar: ");
            var name = Console.ReadLine();

            var csvPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ClientList.csv");
            string[] Lines = System.IO.File.ReadAllLines(csvPath);

            foreach (string Line in Lines)
            {
                string[] dados = Line.Split(',');
                string ClientName = dados[0];
                string ClientDocument = dados[1];
                string ClientAccount = dados[2];
                string ClientActive = dados[3];
                if (ClientName == name && ClientActive == "True")
                {
                    Console.Clear();
                    Console.WriteLine("Cliente encontrado!");



                    return;

                }
            }
            Console.Clear();
            Console.WriteLine("Cliente não encontrado!");
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }
        public static void ClientChangeCPF()
        {
            Console.Clear();
            Console.Write("Insira o nome do cliente que deseja alterar: ");
            var name = Console.ReadLine();

            var csvPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ClientList.csv");
            string[] Lines = System.IO.File.ReadAllLines(csvPath);

            foreach (string Line in Lines)
            {
                string[] dados = Line.Split(',');
                string ClientName = dados[0];
                string ClientDocument = dados[1];
                string ClientAccount = dados[2];
                string ClientActive = dados[3];
                if (ClientName == name && ClientActive == "True")
                {
                    Console.Clear();
                    Console.WriteLine("Cliente encontrado!");


                    return;
                }
            }
            Console.Clear();
            Console.WriteLine("Cliente não encontrado!");
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();

        }
        public static void UpdateClientList()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            var csvPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ClientList.csv");
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, configuration))
            {
                var records = csv.GetRecords<Client>();
                ListOfClients.AddRange(records);
            }
        }

        public static void ClientChangeStatus()
        {
            UpdateClientList();
            Console.Clear();
            Console.Write("Insira o nome do cliente: ");
            var name = Console.ReadLine();
            if (ListOfClients.Any(x => x.Name.Equals(name))) 
            {
                Console.WriteLine("Cliente existente");
                


            }
            else
                Console.WriteLine("Cliente não existente");
        }

    }
}
