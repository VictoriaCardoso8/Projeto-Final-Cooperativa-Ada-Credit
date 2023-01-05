using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Ada_Credit.Entities
{
    public sealed class Account
    {
        public string Number { get; private set; }
        public string Branch { get; private set; }

        public decimal Balance { get; private set; }
        
        private List<Account> ListOfAccounts = new List<Account>();

        public Account()
        {
            Number = new Faker().Random.ReplaceNumbers("#####-#");
            Branch = "0001";
            Balance = 0;
         
                    // preciso mandar para a account repositories e ver se n ta duplicada;
        }
    }

}
