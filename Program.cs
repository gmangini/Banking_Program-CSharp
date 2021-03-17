// Project Prolog
// Name: Gino Mangini
// CS3260 Section X01
// Project: Lab_05
// Date: 02/25/2021 08:29:44 PM
// Purpose: Implement a generic dictionary to store IAccount values instead of an array.
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------


using System;
using System.Text.RegularExpressions;


namespace Banking_Program
{
    /// <summary>
    /// Main driver of Account program interface.
    /// </summary>
    class Program
    {
    static void Main(string[] args)
        {

            IArrayBank bank = new ArrayBank();
            bool addAccount = true;

            while (addAccount)
            {
                // User input for name parameter.
                Console.WriteLine("Please enter the full name: ");
                var name = Console.ReadLine().Trim();

                // User input for address parameter.
                Console.WriteLine("Please enter the address: ");
                var address = Console.ReadLine().Trim();

                // User input for balance parameter.
                decimal decimalVal;
                while (true)
                {
                    Console.WriteLine("Please enter the starting balance: ");
                    var balance = Console.ReadLine();
                    if (Regex.IsMatch(balance, "^[0-9]+$"))
                    {
                        decimalVal = Convert.ToDecimal(balance);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter in a valid account " +
                            "number with integers only.");
                    }
                }

                // User input for account type.
                Console.WriteLine("Please enter the account type: ");
                Console.WriteLine("Checking, Savings, CDAccount.");
                string type = Console.ReadLine().Trim();
                IAccount account;
                if (type == "Checking")
                {
                    account = new CheckingAccount(name, address, decimalVal, type);
                    bank.StoreAccount(name, account);
                }
                else if (type == "Savings")
                {
                    account = new SavingsAccount(name, address, decimalVal, type);
                    bank.StoreAccount(name, account);
                }
                else if (type == "CDAccount")
                {
                    account = new CDAccount(name, address, decimalVal, type);
                    bank.StoreAccount(name, account);
                }

                Console.WriteLine("Press q to quit adding accounts or any key to continue.");
                var quit = Console.ReadLine();
                if (quit.ToLower() == "q")
                {
                    addAccount = false;
                }
            }

            // Allow user to search for a stored account.
            bool search = true;
            while(search)
            {
                // Ask for user input, then if q, terminate while loop.
                Console.WriteLine("Enter user name for account to search for: ");
                Console.WriteLine("Or enter q to quit search for accounts.");
                string user = Console.ReadLine().Trim();
                if (user.ToLower() == "q")
                {
                    search = false;
                }

                IAccount uAcc = bank.FindAccount(user);
                if (uAcc is null)
                {
                    Console.WriteLine("Account not found.");
                }
                else
                {
                    Console.WriteLine($"ACCOUNT DATA:\n Name: {uAcc.GetName()}\n " +
                        $"Address: {uAcc.GetAddress()}\n Account number: {uAcc.GetAccountNumber()}\n " +
                        $"Account type: {uAcc.GetAccountType()}");
                }
            }
        }
    }
}
