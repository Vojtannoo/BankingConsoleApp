using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp
{
    internal class AuthService
    {
        public List<User> Users { get; set; } = new List<User>();
        public bool IsLoggedIn { get; set; } = false;
    
      public void Register()
        {
            Console.Write("Zadej uživatelské jméno: ");
            string username = Console.ReadLine();

            Console.Write("Zadej heslo: ");
            string password = Console.ReadLine();

            Users.Add(new User(username, password));

            Console.WriteLine("Registrace proběhla úspěšně.");
        }

        public void Login()
        {
            Console.Write("Zadej uživatelské jméno: ");
            string username = Console.ReadLine();

            Console.Write("Zadej heslo: ");
            string password = Console.ReadLine();

            User foundUser = Users.Find(u => u.Username == username && u.Password == password);

            if (foundUser == null)
            {
                Console.WriteLine("Špatné jméno nebo heslo.");
            }
            else
            {
                IsLoggedIn = true;
                Console.WriteLine("Přihlášení úspěšné.");
            }
        }

        public void Logout()
        {
            IsLoggedIn = false;
            Console.WriteLine("Byl jsi odhlášen.");
        }


    }


}

