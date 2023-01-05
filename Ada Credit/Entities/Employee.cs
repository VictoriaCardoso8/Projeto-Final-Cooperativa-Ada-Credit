using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada_Credit.Entities
{
    public sealed class Employee
    {
        public string NameEmp { get; private set; }
        public string loginEmp { get; private set; }
        public string passwordEmp { get; private set; }


        public Employee(string name, string login, string password)
        {
            NameEmp= name;
            loginEmp= login;
            passwordEmp= password;
        }
    }
}
