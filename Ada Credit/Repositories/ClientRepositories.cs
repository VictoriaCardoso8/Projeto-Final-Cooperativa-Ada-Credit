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
using Bogus.DataSets;
using System.Xml.Linq;

namespace Ada_Credit.Repositories
{
    public class ClientRepositories
    {
        public static List<Client> ListOfClients = new List<Client>();
        public static void AddClient(Client client, Account account)
        {
            TryClient(client.Name);
            ListOfClients.Add(client);
            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)));
            var csvPath = Path.Combine(path, "ClientList.csv");
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

        public static void ClientChangeName()
        {
            Console.Clear();
            Console.Write("Insira o nome do cliente que deseja alterar: ");
            var name = Console.ReadLine();
            var result = ListOfClients.FirstOrDefault(x => x.Name == name);
            if (result != null)
            {
                var clients = from c in ListOfClients
                              where c.Name == name
                              select c;

                foreach (var c in clients)
                {
                    if (c.Active)
                        Console.Clear();
                        Console.WriteLine("Qual o novo nome a se utilizar? ");
                        var newname = Console.ReadLine();
                        result.Name = newname;
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey();
                        Save();
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
        public static void ClientChangeCPF()
        {
            Console.Clear();
            Console.Write("Insira o nome do cliente que deseja alterar: ");
            var name = Console.ReadLine();
            var result = ListOfClients.FirstOrDefault(x => x.Name == name);
            if (result != null)
            {
                var clients = from c in ListOfClients
                              where c.Name == name
                              select c;

                foreach (var c in clients)
                {
                    if (c.Active)
                        Console.Clear();
                    Console.WriteLine("Qual o novo CPF a se utilizar? ");
                    var newCPF = Console.ReadLine();
                    result.Document = newCPF;
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    Save();
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
        public static void UpdateClientList()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)));
            var csvPath = Path.Combine(path, "ClientList.csv");
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, configuration))
            {
                var records = csv.GetRecords<Client>();
                ListOfClients.AddRange(records);
            }
        }

        public static async void ClientChangeStatus()
        {
            Console.Clear();
            Console.Write("Insira o nome do cliente que deseja alterar: ");
            var name = Console.ReadLine();
            var result = ListOfClients.FirstOrDefault(x => x.Name == name);
            if (result != null)
            {
                var clients = from c in ListOfClients
                              where c.Active == true
                              select c;

                foreach (var c in clients)
                {
                    if (c.Active)
                        Console.Clear();
                    Console.WriteLine("Desativar cliente? (Responder com s ou n)");
                    var answer = Console.ReadLine();
                    if (answer == "s")
                    {
                        result.Active = false;
                        Console.WriteLine("Cliente desativado com sucesso!");

                    }
                    if (answer == "n")
                    {
                        result.Active = true;
                        Console.WriteLine("Cliente ainda ativo!");
                    }

                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    Save();
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
        public static void Save()
        {
            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)));
            var csvPath = Path.Combine(path, "ClientList.csv");
            using (var writer = new StreamWriter(csvPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(ListOfClients);
            }
        }

    }
}
