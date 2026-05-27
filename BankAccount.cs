using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp
{
    internal class BankAccount
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();


        public BankAccount(int id, string ownerName)
        {
            Id = id;
            OwnerName = ownerName;
            Balance = 0;
        }
    }
}
