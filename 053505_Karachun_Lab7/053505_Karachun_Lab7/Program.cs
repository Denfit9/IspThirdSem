using System;
using System.Collections.Generic;
using _053505_Karachun_Lab7.Entities;
using _053505_Karachun_Lab7.LINQ;

namespace _053505_Karachun_Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new();
            journal.FirstAndSecondEvent();
            Purchase purchase = new Purchase();
            persons.onBoughtTicket += purchase.Message1;

            persons peopleList = new();
            terminal exactTerminal = new();
            peopleList.AddPerson(new person { passport = "MP23123" });
            peopleList.AddPerson(new person { passport = "MP12345" });
            peopleList.AddPerson(new person { passport = "MP11111" });
            peopleList.AddPerson(new person { passport = "MP22222" });
            peopleList.ShowPersons();

            exactTerminal.AddToTerminal("Fast as Never", new ticket { ticketNumber = 1, destination = "Minsk", price = 100 });
            exactTerminal.AddToTerminal("Expensive and fast", new ticket { ticketNumber = 2, destination = "Minsk", price = 150 });
            exactTerminal.AddToTerminal("Way to Pinsk", new ticket { ticketNumber = 3, destination = "Pinsk", price = 50 });
            exactTerminal.AddToTerminal("Way to Brest", new ticket { ticketNumber = 4, destination = "Brest", price = 75 });
            exactTerminal.Showtickets();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n********EVENT COUNT FUNCTION********\n");
            Console.ForegroundColor = ConsoleColor.White;
            Journal.AllRegisteresEvents();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n********BUYING FUNCTION********\n");
            Console.ForegroundColor = ConsoleColor.White;
            peopleList.BuyTicket(2, "MP12345", exactTerminal);
            peopleList.BuyTicket(3, "MP23123", exactTerminal);
            peopleList.BuyTicket(1, "MP23123", exactTerminal);
            peopleList.BuyTicket(1, "MP22222", exactTerminal);
            peopleList.BuyTicket(2, "MP22222", exactTerminal);
            peopleList.BuyTicket(4, "MP22222", exactTerminal);

            peopleList.ShowPersons();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n********EVENT COUNT FUNCTION********\n");
            Console.ForegroundColor = ConsoleColor.White;
            Journal.AllRegisteresEvents();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n********SEARCHING BY DESTINATION********\n");
            Console.ForegroundColor = ConsoleColor.White;
            peopleList.SearchByDestination("Minsk");
            peopleList.SearchByDestination("Moscow");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n********DELETE FUNCTION********\n");
            Console.ForegroundColor = ConsoleColor.White;
            peopleList.SellTicketByNumber("MP23123", 3);

            peopleList.ShowPersons();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n********SEARCH BY INDEX FUNCTION********\n");
            Console.ForegroundColor = ConsoleColor.White;
            peopleList.Index(1);
            //peopleList.Index(10);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n********LINQ FUNCTIONS********\n");
            Console.ForegroundColor = ConsoleColor.White;
            exactTerminal.linqueSorted();
            peopleList.countAllBoughtTicketsPrice();
            peopleList.boughtSumForExactPerson(1);
            peopleList.mostSpender();
            peopleList.numPaidMoreThan(100);
            peopleList.showTracks("MP22222");
        }
    }
}
