//Task 1
//Customer class has three public properties -Name(string), ContactPhone(string) and Revenue(decimal). 
// Implement for the Customer's objects the capability of a various string representation. 
// For example, the object with the Name = "Jeffrey Richter", Revenue = 1000000, ContactPhone = "+1 (425) 555-0100" 
// can have the following string representation:
//- Customer record: Jeffrey Richter, 1, 000, 000.00, +1(425) 555 - 0100
//- Customer record: +1(425) 555 - 0100
//- Customer record: Jeffrey Richter, 1, 000, 000.00
//- Customer record: Jeffrey Richter
//- Customer record: 1000000, etc.
//Add to Customer class an additional formatting capability, that is not provided by the class (Customer class do not change). 
// Develop unit tests.


// This realisation uses Strategy design pattern: IFormatStrategy declares report methods, TextOutput class holds switching variable with 
// chosen strategy (bufferFiller), and the general method for reporting (GetTextOutput).

namespace NET03_01_01
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03. Task 01-01. Different output formats with Strategy pattern.");

            var customer1 = new Customer()
            {
                Name = "Jeffrey Richter",
                Revenue = 1000000,
                ContactPhone = "+1 (425) 555-0100"
            };

            var customer2 = new Customer()
            {
                Name = "Michael Jackson",
                Revenue = 10000,
                ContactPhone = "+1 (423) 222-3245"
            };

            var customersList = new List<Customer>();
            customersList.Add(customer1);
            customersList.Add(customer2);
            var textMaker = new TextOutput();

            foreach(FormatType type in Enum.GetValues(typeof(FormatType)))
            {
                foreach(Customer customer in customersList)
                {
                    textMaker.SetOutputStrategy(type);
                    Console.WriteLine(textMaker.GetTextOutput(customer));
                }

                Console.WriteLine();
            }
        }
    }
}
