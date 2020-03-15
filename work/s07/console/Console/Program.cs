using Microsoft.Xrm.Sdk.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Console
{
    class Program
    {

        static void Main(string[] args)

        {
            List<Accounts> accounts = JsonConvert.DeserializeObject<List<Accounts>>(File.ReadAllText(@"c:\account.json"));

            int choice = 0;
            do { Menu();

                 choice = Convert.ToInt32(System.Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        for (int i = 0; i < accounts.Count; i++)
                        {
                            System.Console.WriteLine(accounts[i]);
                        }

                        break;

                    case 2:

                        System.Console.WriteLine("Enter Account Number:");
                        int Nmber = Convert.ToInt32(System.Console.ReadLine());
                        for (int i = 0; i < accounts.Count; i++)
                        {
                            if (Nmber == accounts[i].Number)
                            {
                                System.Console.WriteLine(accounts[i]);
                            }
                            else
                            {
                              
                            }
                        }
                        break;
                    case 3:
                        System.Console.WriteLine("Thank You for Visit!");
                      break;

                }

            } while (choice <= 2);
            
        }

        public static void Menu()
        {
            System.Console.WriteLine("Welcome to Dotnet Bank");
            System.Console.WriteLine("************ + ************");
            System.Console.WriteLine("1) View All Accounts");
            System.Console.WriteLine("2) View Account by Number");
            System.Console.WriteLine("3) Exit");
            System.Console.WriteLine("************ + ************");
        }
    }

    public class Accounts
    {
        public int Number { get; set; }
        public int Balance { get; set; }
        public string Label { get; set; }
        public int Owner { get; set; }

        public override string ToString()
        {
            string str = String.Empty;
            str = String.Concat(str, "Number = ", Number, "\r\n");
            str = String.Concat(str, "Balance = ", Balance, "\r\n");
            str = String.Concat(str, "Label = ", Label, "\r\n");
            str = String.Concat(str, "Owner = ", Owner, "\r\n");
            return str;

        }
    }   
}



