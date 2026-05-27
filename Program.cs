using BankingConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


class Program
{
    static void Main()
    {
        bool running = true;

        BankService bankService = new BankService();

        AuthService authService = new AuthService();




        while (running)
        {
            Console.Clear();

            if (!authService.IsLoggedIn)
            {
                Console.WriteLine("=== PŘIHLÁŠENÍ ===");
                Console.WriteLine("1. Registrovat");
                Console.WriteLine("2. Přihlásit");
                Console.WriteLine("3. Konec");
                Console.Write("Vyber možnost: ");

                string loginChoice = Console.ReadLine();

                switch (loginChoice)
                {
                    case "1":
                        authService.Register();
                        Console.ReadKey();
                        break;

                    case "2":
                        authService.Login();
                        Console.ReadKey();
                        break;

                    case "3":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Neplatná volba.");
                        Console.ReadKey();
                        break;
                }

                continue;
            }

            Console.WriteLine("=== BANKOVNÍ SYSTÉM ===");
            Console.WriteLine("1. Vytvořit účet");
            Console.WriteLine("2. Zobrazit účty");
            Console.WriteLine("3. Vložit peníze");
            Console.WriteLine("4. Vybrat peníze");
            Console.WriteLine("5. Převod mezi účty");
            Console.WriteLine("6. Historie transakcí");
            Console.WriteLine("7. Konec");
            Console.WriteLine("8. Odhlásit se");
            Console.Write("Vyber možnost: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bankService.CreateAccount();
                    break;

                case "2":
                    bankService.ShowAccounts();
                    break;

                case "3":
                    bankService.Deposit();
                    break;

                case "4":
                    bankService.Withdraw();
                    break;

                case "5":
                    bankService.Transfer();
                    break;

                case "6":
                    bankService.ShowHistory();
                    break;

                case "7":
                    running = false;
                    break;

                case "8":
                    authService.Logout();
                    break;

                default:
                    Console.WriteLine("Neplatná volba");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPokračuj stiskem klávesy...");
                Console.ReadKey();
            }
        }
    }
}
    