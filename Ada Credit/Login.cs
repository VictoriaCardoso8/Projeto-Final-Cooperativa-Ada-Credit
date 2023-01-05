using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ada_Credit.Entities;
using BCrypt.Net;
using Bogus.DataSets;
using static BCrypt.Net.BCrypt;


namespace Ada_Credit
{
    public class Login
    {
        public static void Show()
        {
            Repositories.EmployeeRepositories.UpdateEmployeeList();
            Repositories.ClientRepositories.UpdateClientList();
            Console.Clear();
            Console.Write("Digite o nome do usuário: ");
            var username = Console.ReadLine();
            Console.Write("Digite a senha: ");
            var password = Console.ReadLine();
            var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)));
            var csvPath = Path.Combine(path, "EmployeeList.csv");
            string[] Lines = System.IO.File.ReadAllLines(csvPath);

            
            var EmployeeLogin = Repositories.EmployeeRepositories.ListOfEmployees.FirstOrDefault(x => x.loginEmp == username);
            var EmployeePassword = Repositories.EmployeeRepositories.ListOfEmployees.FirstOrDefault(x => x.passwordEmp == password);
            
            if (EmployeeLogin != null && EmployeePassword == null)
            {
                Console.Clear();
                Console.WriteLine("Login efetuado com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
                return;
            }


            Console.Clear();
            Console.WriteLine("Login ou senha incorretos!");
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Login.Show();
                

        
        }




        // pra verificar se a senha que digitei hasheada é a do usuario: var passwordsMatch = Verify(Console.ReadLine(), hashedPassword);
      

    }
}
