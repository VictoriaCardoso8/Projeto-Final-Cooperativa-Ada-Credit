using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada_Credit.Entities
{
    public sealed class Client
    {
        public string Name { get; private set; }
        public long Document { get; private set; }
        public Account Account { get; private set; } = null;
        public bool Active { get; private set; }

        public Client(string name, long document) 
        {
            Name= name;
            Document = document;
            Active = true;
        }

    }
}
