using Ada_Credit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace AdaCredit
{
    public class Program
    {
        static void Main(string[] args)
        
        {
            Login.Show();
            Menu.Show(args);
        }
    }
}