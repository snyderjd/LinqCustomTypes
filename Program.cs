using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqCustomType
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Ticker="FTB"},
                new Bank(){ Name="Wells Fargo", Ticker="WF"},
                new Bank(){ Name="Bank of America", Ticker="BOA"},
                new Bank(){ Name="Citibank", Ticker="CITI"}
            };

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

            // var id = 1;
            // var query = database.Posts    // your starting point - table in the "from" statement
            //    .Join(database.Post_Metas, // the source table of the inner join
            //       post => post.ID,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
            //       meta => meta.Post_ID,   // Select the foreign key (the second part of the "on" clause)
            //       (post, meta) => new { Post = post, Meta = meta }) // selection
            //    .Where(postAndMeta => postAndMeta.Post.ID == id);    // where statement

            var query = customers.Where(customer => customer.Balance >= 1000000)
                .Join(banks, customer => customer.Bank, bank => bank.Ticker,
                (customer, bank) => new ReportItem { BankName = bank.Name, CustomerName = customer.Name })
                .OrderBy(item => item.CustomerName.Split(" ")[1]);

            foreach(ReportItem item in query)
            {
                Console.WriteLine($"{item.CustomerName} at {item.BankName}");
            }

            // ============== Using Custom Types exercise ===============

            // Given the same customer set, display how many millionaires per bank.
            // Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq
            // Example Output:
            // WF: 2
            // BOA: 1
            // FTB: 1
            // CITI: 1

            List<Customer> millionaires = customers.Where(customer => customer.Balance >= 1000000).ToList();

            var millionairesByBank = millionaires.GroupBy(millionaire => millionaire.Bank, (key, value) => new {
                bankName = key,
                count = value.Count()
            });

            foreach(var kvp in millionairesByBank)
            {
                // Console.WriteLine($"{kvp.bankName}: {kvp.count}");
            }
        }
    }
}
