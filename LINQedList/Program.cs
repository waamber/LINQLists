using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            var LFruits = from fruit in fruits
                          where fruit[0] == 'L'
                          select fruit;

            foreach (var fruit in LFruits)
            {
                //Console.WriteLine(fruit);
            }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>(){ 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 9 };

            var fourSixMultiples = from num in numbers
                                   where num % 4 == 0 || num % 6 == 0
                                   select num;

            foreach(var num in fourSixMultiples)
            {
                //Console.WriteLine(num);
            }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            var descend = names.OrderByDescending(name => name);

            foreach(var name in descend)
            {
                //Console.WriteLine(name);
            }

            // Build a collection of these numbers sorted in ascending order
            List<int> numbers1 = new List<int>(){ 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 9 };

            var ascend = numbers1.OrderBy(num => num);

            foreach(var num in ascend)
            {
                //Console.WriteLine(num);
            }


            // Output how many numbers are in this list
            List<int> numbers2 = new List<int>() { 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96 };

            var numCount = numbers2.Count();

            //Console.WriteLine(numCount);

            // How much money have we made?
            List<double> purchases = new List<double>(){ 2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65 };

            var purchaseSum = purchases.Sum();

            //Console.WriteLine(purchaseSum);

            // What is our most expensive product?
            List<double> prices = new List<double>() { 879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76 };

            var maxPrice = prices.Max();

            //Console.WriteLine(maxPrice);


            //Store each number in the following List until a perfect square is detected.
            List<int> wheresSquaredo = new List<int>() { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14 };

            foreach(var num in wheresSquaredo)
            {
              if(Math.Sqrt(num) % 1 == 0)
              {
                    //Console.WriteLine(num);
              }
            }

            // Build a collection of customers who are millionaires

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


            var millionaires = from customer in customers
                               where customer.Balance >= 1000000
                               select customer;


            //Given the same customer set, display how many millionaires per bank.

            var groupedByBanks = millionaires.GroupBy(millionaire => millionaire.Bank);

            foreach(var bank in groupedByBanks)
            {
                //Console.WriteLine($"{bank.Key} - {bank.Count()}");
            }


            /*TASK:
            As in the previous exercise, you're going to output the millionaires,
            but you will also display the full name of the bank. You also need
            to sort the millionaires' names, ascending by their LAST name.*/


            // Define a bank
            List<Bank> banks = new List<Bank>()
            {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            // Create some customers and store in a List
            List<Customer> customers1 = new List<Customer>()
            {
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

            var millionaireReport = from customer in customers1
                                    join bank in banks
                                    on customer.Bank equals bank.Symbol
                                    where customer.Balance >= 1000000
                                    orderby customer.Name.Substring(customer.Name.IndexOf(" ") + 1)
                                    select new
                                    {
                                        CustomerName = customer.Name,
                                        CustomerBank = bank.Name,
                                    };
                                   

            foreach (var customer in millionaireReport)
            {
                Console.WriteLine($"{customer.CustomerName} at {customer.CustomerBank}");
            }

            Console.ReadLine();
        }
    }
}
