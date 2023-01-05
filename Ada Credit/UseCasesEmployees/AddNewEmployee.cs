using Ada_Credit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;
using Ada_Credit.Repositories;

namespace Ada_Credit.UseCases
{
    internal class AddNewEmployee
    {
        //private const int WorkFactor = 8;
        public static void Execute()
        {
            Console.Clear();
            Console.WriteLine("CADASTRO DE NOVO FUNCIONARIO");
            Console.Write("Insira o nome do Funcionário:");
            var name = Console.ReadLine();
            Console.Write("Insira o login do funcionário:");
            var login = Console.ReadLine();
            Console.Write("Insira a senha para login do funcionário, de no mínimo 4 caracteres:");
            var password = Console.ReadLine();
            while (password.Length < 4)
            {
                Console.WriteLine("Senha com tamanho incorreto! Insira a senha novamente.");
                password= Console.ReadLine();
            }
            var hashedPassword = HashPassword(password);
            var Employee = new Employee(name, login, hashedPassword);
            Repositories.EmployeeRepositories.AddEmployee(Employee);

            Console.Clear();
            Console.WriteLine("Funcionário cadastrado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();

        }
    }
}
