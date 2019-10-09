using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqCustomType
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build a collection of customers who are millionaries

            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

            // Given the same customer set, display how many millionaires per bank.
            // Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

            // Example Output:
            // WF: 2
            // BOA: 1
            // FTB: 1
            // CITI: 1

            var report = customers.GroupBy(
                customer => customer.Bank
            );

            foreach(var result in report)
            {
                foreach(Customer customer in result)
                {
                    Console.WriteLine(customer.Name);
                    Console.WriteLine(customer.Balance);
                    Console.WriteLine(customer.Bank);
                }
            }

        }
    }
}
