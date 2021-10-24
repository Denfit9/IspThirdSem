using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053505_Karachun_Lab6.Entities
{
    public class Journal
    {
        public static int ticketsChanged = 0;
        public static int peopleChanged = 0;
        public static int ticketBought = 0;
        public static void AllRegisteresEvents()
        {
            Console.WriteLine("\nNumber of changed tickets: " + ticketsChanged + "\nNumber of changed people: " + peopleChanged + "\nNumber of purchases: " + ticketBought + "\n\n");
        }
        public void FirstAndSecondEvent()
        {

            persons.onChangePeople += () => Console.WriteLine("People changed") ;
            persons.onChangePeople += () => peopleChanged++;
            terminal.onChangeTicket += () => Console.WriteLine("Ticket list changed");
            terminal.onChangeTicket += () => ticketsChanged++; 
        }
    }

    class Purchase
    {
        public void Message1()
        {
            string mes3() => "Somebody bought or sold something";
            Console.WriteLine(mes3());
            Journal.ticketBought = Journal.ticketBought + 1;
        }
    }
}
