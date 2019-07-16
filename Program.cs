using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Millions
{
    public class Program
{
    public static void Main() {
        List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

        List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Deep Patel", Balance=1790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=7849582.68, Bank="CITI"}
        };
        // Create list of millionaires
        var millionaires = from customer in customers
                                         where customer.Balance >= 1000000
                                         orderby customer.Name.Split(" ")[1]
                                         select customer;
        var millionairesInBank = millionaires.GroupBy(customer => customer.Bank);
        // List the number of millionaires in each bank
        foreach (IGrouping<String, Customer> bank in millionairesInBank)
        {
            System.Console.WriteLine($"{bank.Key}-{bank.Count()}");
        }
        // List the name of the millionaire next to the full name of their bank
        var bigBankers =
        millionaires.Join(banks,
                    millionaire => millionaire.Bank,
                    bank => bank.Symbol,
                    (millionaire, bank) =>
                        new ReportItem { CustomerName = millionaire.Name, BankName = bank.Name });

            foreach (var banker in bigBankers)
            {
                Console.WriteLine(
                    "{0} - {1}",
                    banker.CustomerName,
                    banker.BankName);
            }

            System.Console.WriteLine("---------------------");
            
                                              
    }
}
}
