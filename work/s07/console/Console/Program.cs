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
            do
            {
                Menu();

                choice = Convert.ToInt32(System.Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //header here

                        for (int i = 0; i < accounts.Count; i++)
                        {
                            if (i == 0)
                            {
                                printTable(true, false, accounts[i]);

                            }
                            else if (i < accounts.Count - 1)
                            {
                                printTable(false, false, accounts[i]);
                            }
                            else
                            {
                                printTable(false, true, accounts[i]);
                            }

                        }
                        System.Console.WriteLine();

                        break;

                    case 2:

                        System.Console.WriteLine("Enter Account Number:");
                        int Nmber = Convert.ToInt32(System.Console.ReadLine());
                        for (int i = 0; i < accounts.Count; i++)
                        {
                            if (Nmber == accounts[i].Number)
                            {
                                printTable(true, true, accounts[i]);
                            }
                            else
                            {

                            }
                        }
                        break;
                    case 3:

                        System.Console.WriteLine("Enter Search String");
                        String searchWord = System.Console.ReadLine();
                        List<Accounts> result = new List<Accounts>();
                        if (searchWord != null)
                        {
                            int len = searchWord.Length;
                            for (int i = 0; i < accounts.Count; i++)
                            {
                                if (searchWord.Equals(accounts[i].Label.Substring(0, len)))
                                {
                                    result.Add(accounts[i]);
                                }

                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Enter Correct String");
                        }

                        if (result.Count != 0)
                        {
                            if (result.Count == 1)
                            {
                                printTable(true, true, result[0]);

                            }
                            else
                            {

                                for (int f = 0; f < result.Count; f++)
                                {
                                    if (f == 0)
                                    {
                                        printTable(true, false, result[f]);

                                    }
                                    else if (f < result.Count - 1)
                                    {
                                        printTable(false, false, result[f]);
                                    }
                                    else
                                    {
                                        printTable(false, true, result[f]);
                                    }

                                }
                            }

                        }
                        else
                        {
                            System.Console.WriteLine("No account found !!");
                        }


                        break;

                    case 4:
                        int acctOne, acctTwo;
                        bool acct1 = false, acct2 = false;
                        List<Accounts> accounts1 = new List<Accounts>();

                        while (true)
                        {
                            System.Console.WriteLine("Enter Account to move balance FROM");
                            try
                            {

                                acctOne = Convert.ToInt32(System.Console.ReadLine());
                                break;
                            }
                            catch (FormatException e)
                            {
                                System.Console.WriteLine("Use interger value ONLY");
                                System.Console.ReadKey();
                                System.Console.Write("\n");

                            }
                        }
                        while (true)
                        {

                            System.Console.WriteLine("Enter Account to move balance TO");
                            try
                            {

                                acctTwo = Convert.ToInt32(System.Console.ReadLine());
                                break;
                            }
                            catch (FormatException e)
                            {
                                System.Console.WriteLine("Use interger value ONLY");
                                System.Console.ReadKey();
                                System.Console.Write("\n");

                            }

                        }
                        for (int x = 0; x < accounts.Count; x++)
                        {
                            if (acctOne == accounts[x].Number)
                            {
                                acct1 = true;

                                for (int y = 0; y < accounts.Count; y++)
                                {
                                    if (accounts[y].Number == acctTwo)
                                    {
                                        acct2 = true;
                                        accounts[y].Balance += accounts[x].Balance;
                                        accounts[x].Balance = 0;

                                        break;
                                    }

                                }

                            }
                        }
                        if (!acct1)
                        {
                            System.Console.WriteLine("Acoount Number FROM NOT exist", acctOne);
                        }
                        else if (!acct2)
                        {
                            System.Console.WriteLine("Account Number TO NOT exist", acctTwo);

                            if (acct1 && acct2)
                            {
                                saveMoneyToJson(accounts1);
                            }

                        }

                        break;


                    case 5:
                        System.Console.WriteLine("Thank You for Visit!");
                        break;

                    default:
                        System.Console.WriteLine("Invalid Choice Number");
                        break;

                }

            } while (choice <= 4);

        }
        public static void Menu()
        {
            System.Console.WriteLine("Welcome to Dotnet Bank");
            System.Console.WriteLine("--------------- + ----------------");
            System.Console.WriteLine("1) View All Accounts");
            System.Console.WriteLine("2) View Account by Number");
            System.Console.WriteLine("3) Search Account by Name");
            System.Console.WriteLine("4) Transfer Money");
            System.Console.WriteLine("5) Exit");
            System.Console.WriteLine("--------------- + ----------------");
        }
        public static void printTable(bool x, bool y, Accounts accounts)
        {
            if (x)
            {
                System.Console.WriteLine(" ---------------- + ----------- + ------------ + -------------");
                System.Console.WriteLine("| Number          |   Balance   |    Label     |      Owner  |");
                System.Console.WriteLine(" ---------------- + ----------- + ------------ + -------------");
            }

            System.Console.WriteLine("| {0,-15} |{1,10}   |{2,10}    |{3,10}   |", accounts.Number, accounts.Balance, accounts.Label, accounts.Owner);

            if (y)
            {
                System.Console.WriteLine(" ---------------- + ----------- + ------------ + -------------");
            }

        }

        private void moveMoney()
        {

        }

        private static void saveMoneyToJson(List<Accounts> accounts)
        {

            String jsonFile = (@"account.json");
            File.Delete(jsonFile);
            using (StreamWriter file = File.CreateText(jsonFile))
            {

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, accounts);
                /*JsonSerializer.Serialize<IEnumerable<Accounts>>(
                    new Utf8JsonWriter(
                        outPutStream, new JsonWriterOptions{
                            Indented = true
                        }
                    ),
                    accounts
                );*/
            }
        }
    }
    public class Accounts
    {
        public int Number { get; set; }
        public int Balance { get; set; }
        public string Label { get; set; }
        public int Owner { get; set; }


        /*
                public override string ToString()
                {
                    string str = String.Empty;

                    str = String.Concat(str, Number, " | ", Balance, " | ", Label, " | ", Owner, "\r\n");


                    //str = String.Concat(str, "Balance = ", Balance, "\r\n");
                    //str = String.Concat(str, "Label = ", Label, "\r\n");
                    //str = String.Concat(str, "Owner = ", Owner, "\r\n");


                    return str;

                }*/
    }

}



