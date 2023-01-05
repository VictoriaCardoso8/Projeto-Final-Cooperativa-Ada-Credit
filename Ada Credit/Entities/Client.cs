using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada_Credit.Entities
{
    public sealed class Client
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public Account Account { get; set; } = null;
        public bool Active { get; set; }

        public Client(string name, string document) 
        {
            Name= name;
            Document = document;
            Active = true;
            Account = new Account();
        }

    }
}
