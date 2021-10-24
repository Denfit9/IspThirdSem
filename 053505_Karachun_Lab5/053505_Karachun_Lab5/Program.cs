using System;
using _053505_Karachun_Lab5.Collections;
using _053505_Karachun_Lab5.Interfaces;
using _053505_Karachun_Lab5.Entities;

namespace _053505_Karachun_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            persons peopleList = new persons();
            terminal exactTerminal = new terminal();
            exactTerminal.AddToTerminal(new ticket { ticketNumber = 1, destination = "Minsk", price = 100 });
            exactTerminal.AddToTerminal(new ticket { ticketNumber = 2, destination = "Minsk", price = 150 });
            exactTerminal.AddToTerminal(new ticket { ticketNumber = 3, destination = "Pinsk", price = 200 });
            exactTerminal.AddToTerminal(new ticket { ticketNumber = 4, destination = "Brest", price = 300 });
            exactTerminal.ShowTickets();
            peopleList.AddPerson(new person { passport = "MP23123" });
            peopleList.AddPerson(new person { passport = "MP12345" });
            peopleList.AddPerson(new person { passport = "MP11111" });
            peopleList.ShowPersons();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n********BUYING FUNCTION********\n");
            Console.ForegroundColor = ConsoleColor.White;
            peopleList.BuyTicket(2, "MP12345", exactTerminal);
            peopleList.BuyTicket(3, "MP23123", exactTerminal);
            peopleList.BuyTicket(1, "MP23123", exactTerminal);  

            peopleList.ShowPersons();

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
        }
    }
}
