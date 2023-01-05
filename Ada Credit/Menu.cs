using Ada_Credit.UseCasesClient;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada_Credit
{
    public class Menu
    {
        public static void Show(string[] args)
        {
            var Transactions = new ConsoleMenu(args, level: 1)
                .Add("Processar Transações", () => SomeAction("Sub_One"))
                .Add("Voltar", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = false;
                config.Title = "Transações";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });
            var ChangeClients = new ConsoleMenu(args, level: 1)
                .Add("Alterar Nome", Repositories.ClientRepositories.ClientChangeName)
                .Add("Alterar CPF", Repositories.ClientRepositories.ClientChangeCPF)
                .Add("Voltar", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = false;
                    config.Title = "Clientes";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                });

            var Clients = new ConsoleMenu(args, level: 1)
                .Add("Cadastrar Novo Cliente", AddNewClient.Execute)
                .Add("Consultar os Dados de um Cliente existente", Repositories.ClientRepositories.ClientConsult)
                .Add("Alterar o Cadastro de um Cliente existente", ChangeClients.Show)
                .Add("Desativar Cadastro de um Cliente existente", Repositories.ClientRepositories.ClientChangeStatus)
                .Add("Voltar", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = false;
                config.Title = "Clientes";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });

            var Employees = new ConsoleMenu(args, level: 1)
                .Add("Cadastrar Novo Funcionário", UseCases.AddNewEmployee.Execute)
                .Add("Alterar Senha de um Funcionário existente", () => SomeAction("Sub_Two"))
                .Add("Desativar Cadastro de um Funcionário existente", () => SomeAction("Sub_Three"))
                .Add("Voltar", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = false;
                config.Title = "Funcionários";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });

            var Reports = new ConsoleMenu(args, level: 1)
                .Add("Exibir Todos os Clientes Ativos com seus Respectivos Saldos", () => SomeAction("Sub_One"))
                .Add("Exibir Todos os Clientes Inativos", () => SomeAction("Sub_Two"))
                .Add("Exibir Todos os Funcionários Ativos e sua Última Data e Hora de Login", () => SomeAction("Sub_Three"))
                .Add("Exibir Transações com Erro", () => SomeAction("Sub_Four"))
                .Add("Voltar", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = false;
                config.Title = "Relatórios";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });

            var menu = new ConsoleMenu(args, level: 0)
              .Add("Clientes", Clients.Show)
              .Add("Funcionários", Employees.Show)
              .Add("Transações", Transactions.Show)
              .Add("Relatórios", Reports.Show)
              .Add("Sair", () => Environment.Exit(0))
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.EnableFilter = false;
                  config.Title = "Ada Credit";
                  config.EnableWriteTitle = false;
                  config.EnableBreadcrumb = true;
              });

            menu.Show();
        }
        private static void SomeAction(string subOne)
        {
            Console.WriteLine(subOne);
        }
    }

}
