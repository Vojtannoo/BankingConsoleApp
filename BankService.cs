using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp
{
    internal class BankService
    {


        public List<BankAccount> Accounts { get; set; } = new List<BankAccount>();
        public int NextId { get; set; } = 1;

        public void CreateAccount()
        {
            Console.Write("Zadej jméno majitele: ");
            string ownerName = Console.ReadLine();

            BankAccount newAccount = new BankAccount(NextId, ownerName);
            Accounts.Add(newAccount);

            NextId++;

            Console.WriteLine("Účet byl vytvořen.");
        }

        public void ShowAccounts()
        {
            if (Accounts.Count == 0)
            {
                Console.WriteLine("Žádné účty neexistují.");
            }
            else
            {
                foreach (BankAccount account in Accounts)
                {
                    Console.WriteLine($"ID: {account.Id}");
                    Console.WriteLine($"Majitel: {account.OwnerName}");
                    Console.WriteLine($"Zůstatek: {account.Balance} Kč");
                    Console.WriteLine("---------------------");
                }
            }
        }

        public void Deposit()
        {
            Console.Write("Zadej ID účtu: ");
            int depositId = int.Parse(Console.ReadLine());

            BankAccount depositAccount = Accounts.Find(a => a.Id == depositId);

            if (depositAccount == null)
            {
                Console.WriteLine("Účet nebyl nalezen.");
            }
            else
            {
                Console.Write("Zadej částku: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                depositAccount.Balance += amount;

                depositAccount.Transactions.Add(
                    new Transaction("Vklad", amount, "Vklad peněz na účet")
                );

                Console.WriteLine("Peníze byly vloženy.");
            }
        }

        public void Withdraw()
        {
            Console.Write("Zadej ID účtu: ");
            int withdrawId = int.Parse(Console.ReadLine());

            BankAccount withdrawAccount = Accounts.Find(a => a.Id == withdrawId);

            if (withdrawAccount == null)
            {
                Console.WriteLine("Účet nebyl nalezen.");
            }
            else
            {
                Console.Write("Zadej částku k výběru: ");
                decimal withdrawAmount = decimal.Parse(Console.ReadLine());

                if (withdrawAmount > withdrawAccount.Balance)
                {
                    Console.WriteLine("Nedostatek peněz.");
                }
                else
                {
                    withdrawAccount.Balance -= withdrawAmount;

                    withdrawAccount.Transactions.Add(
                        new Transaction("Výběr", withdrawAmount, "Výběr peněz z účtu")
                    );

                    Console.WriteLine("Peníze byly vybrány.");
                }
            }
        }

        public void Transfer()
        {
            Console.Write("Zadej ID odesílacího účtu: ");
            int fromId = int.Parse(Console.ReadLine());

            Console.Write("Zadej ID cílového účtu: ");
            int toId = int.Parse(Console.ReadLine());

            BankAccount fromAccount = Accounts.Find(a => a.Id == fromId);
            BankAccount toAccount = Accounts.Find(a => a.Id == toId);

            if (fromAccount == null || toAccount == null)
            {
                Console.WriteLine("Jeden z účtů neexistuje.");
            }
            else
            {
                Console.Write("Zadej částku převodu: ");
                decimal transferAmount = decimal.Parse(Console.ReadLine());

                if (transferAmount > fromAccount.Balance)
                {
                    Console.WriteLine("Nedostatek peněz.");
                }
                else
                {
                    fromAccount.Balance -= transferAmount;
                    toAccount.Balance += transferAmount;

                    fromAccount.Transactions.Add(
                        new Transaction("Převod odchozí", transferAmount, $"Převod na účet ID {toAccount.Id}")
                    );

                    toAccount.Transactions.Add(
                        new Transaction("Převod příchozí", transferAmount, $"Převod z účtu ID {fromAccount.Id}")
                    );

                    Console.WriteLine("Převod úspěšný.");
                }
            }
        }

        public void ShowHistory()
        {
            Console.Write("Zadej ID účtu: ");
            int historyId = int.Parse(Console.ReadLine());

            BankAccount historyAccount = Accounts.Find(a => a.Id == historyId);

            if (historyAccount == null)
            {
                Console.WriteLine("Účet nebyl nalezen.");
            }
            else if (historyAccount.Transactions.Count == 0)
            {
                Console.WriteLine("Žádné transakce.");
            }
            else
            {
                foreach (Transaction transaction in historyAccount.Transactions)
                {
                    Console.WriteLine($"{transaction.Date}");
                    Console.WriteLine($"{transaction.Type}");
                    Console.WriteLine($"{transaction.Amount} Kč");
                    Console.WriteLine($"{transaction.Description}");
                    Console.WriteLine("-------------------");
                }
            }
        }
    }
}





