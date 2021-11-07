using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _053505_Karachun_Lab7.Entities;

namespace _053505_Karachun_Lab7.LINQ
{
    class LINQue
    {
        public static void tarifsSortedByPrice(Dictionary<string,ticket> terminal)
        {
            var orderedPrices = from ticket in terminal
                                orderby ticket.Value.price
            select ticket;
            
            foreach (KeyValuePair<string, ticket> ticket in orderedPrices)
            {
                Console.WriteLine("Tarif name is: " + ticket.Key + "  " + "\nTicket number= " + ticket.Value.ticketNumber + "\nDestination point is: " + ticket.Value.destination + "\nPrice is: " +
                +ticket.Value.price + "\n___________________\n\n");
            }
        }
        public static decimal allBoughtTickets(List<ticket> tickets)
        {
            var boughtTickets = from tick in tickets
                                select tick;
            decimal sum = boughtTickets.Sum(tick => tick.price);
            return sum;
        }
        public static void whoPaidMore(List<person> persons)
        {
            var paidmore = from person in persons
                           where person.moneySpent == persons.Max(n => n.moneySpent)
                           select person;
            foreach (person p in paidmore)
            {
                Console.WriteLine("Money spent = " + p.moneySpent + " Passport = " + p.passport + "\n");
                break;
            }
        }
        public static void passengersWhoPaidMoreThan(List<person> persons, int price)
        {
            List<int> numberOfRichPassengers = new();
            foreach (person p in persons)
            {
                if (p.moneySpent> price)
                {
                    numberOfRichPassengers.Add(1);
                }
            }
            int number = numberOfRichPassengers.Aggregate((x, y)=> x + y);
            Console.WriteLine("\nNumber of passengers who paid more than " + price + " is " + number + "\n" );
        }
        public static void paidOnTrackTo(List<ticket> tickets)
        {
            var groupedTickets = tickets.GroupBy(d => d.destination)
                .Select(d => new
                {
                    Name = d.Key,
                    Sum = d.Sum(d => d.price),
                    tickets = d.Select(p => p)
                });

            foreach (var group in groupedTickets)
            {
                Console.WriteLine("\nWay: " +  group.Name  + " Spent: " + group.Sum);
            }                   
        }
    }
}
