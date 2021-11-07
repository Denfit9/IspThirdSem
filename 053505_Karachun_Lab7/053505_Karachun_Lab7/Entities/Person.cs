using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _053505_Karachun_Lab7.LINQ;

namespace _053505_Karachun_Lab7.Entities
{
    class terminal
    {
        public delegate void ChangeFunction();
        public static event ChangeFunction onChangeTicket;
        Dictionary <string, ticket> tickets= new();
        public void Showtickets()
        {
            foreach (KeyValuePair<string,ticket> tick in tickets)
            {
                Console.WriteLine("Tarif name is: " + tick.Key + "  " + "\nTicket number= " + tick.Value.ticketNumber + "\nDestination point is: " + tick.Value.destination + "\nPrice is: " +
                +tick.Value.price + "\n___________________\n\n");
            }
        }
        public void linqueSorted()
        {
            LINQue.tarifsSortedByPrice(tickets);
        }

        public void AddToTerminal(string tarifName,ticket item)
        {
            foreach (KeyValuePair<string, ticket> tick in tickets)
            {
                
                if (tick.Value.ticketNumber == item.ticketNumber)
                {
                    tick.Value.destination = item.destination;
                    tick.Value.price = item.price;
                    Console.WriteLine("Ticket changed");
                    break;
                }
            }
            tickets.Add(tarifName,item);
            onChangeTicket();
        }
        public string ticketDestination(int ticketnumber)
        {
            foreach (KeyValuePair<string, ticket> tick in tickets)
            {
                if (tick.Value.ticketNumber == ticketnumber)
                {
                    return tick.Value.destination;
                    
                }
            }
            return "nothing";
        }
        public int ticketPrice(int ticketnumber)
        {
            foreach (KeyValuePair<string, ticket> tick in tickets)
            {
                if (tick.Value.ticketNumber == ticketnumber)
                {
                    return tick.Value.price;
                    
                }
            }
            return 0;
        }
        
        public bool isThereATicket(int ticketnumber)
        {
            foreach (KeyValuePair<string, ticket> tick in tickets)
            {
                if (tick.Value.ticketNumber == ticketnumber)
                {
                    return true;
                    
                }
            }
            return false;
        }
    }
    class ticket
    {
        public int ticketNumber;
        public string destination;
        public int price;
        public bool bought = false;
        public void ShowTicketInfo()
        {
            Console.WriteLine("Ticket number= " + ticketNumber + "\nDestination point is: " + destination + "\nPrice is: " +
                +price + "\n___________________\n\n");

        }
    }

    class person
    {
        public string passport;
        public int moneySpent;
        List<ticket> arr = new();
        public void ShowPersonInfo()
        {
            Console.WriteLine("Person's passport=" + passport + "\nThis person spent on his tickets= " + moneySpent + " money\n");
            Console.WriteLine("Person's tickets: ");
            if (arr.Count == 0)
            {
                Console.WriteLine("Actually this persong haven't bought anything");
            }
            else
            {
                foreach (ticket t in arr)
                {
                    t.ShowTicketInfo();
                }
            }
        }
        public void addTicket(int numTicket, int price, string destination)
        {
            arr.Add(new ticket { destination = destination, price = price, ticketNumber = numTicket });
            moneySpent = moneySpent + price;
        }
        public void doYouHaveThisTicket(string destination)
        {
            foreach (ticket t in arr)
            {
                if (t.destination == destination)
                {
                    Console.WriteLine("Person " + passport + " bough ticket number " + t.ticketNumber + " on the way to: " + destination + "\n");
                }
            }
        }
        public void doYouHaveThisTicket(int num)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i].ticketNumber== num)
                {
                    moneySpent = moneySpent - arr[i].price;
                    arr.RemoveAt(i);
                }
            }
        }
        public decimal boughtTickets()
        {
            decimal sum = LINQue.allBoughtTickets(arr);
            return sum;
        }
        public void showTicketByTrack()
        {
            LINQue.paidOnTrackTo(arr);
        }
    }
    class persons
    {
        public delegate void ChangeFunction();
        public static event ChangeFunction onChangePeople;
        public static event ChangeFunction onBoughtTicket;
        List<person> perss = new();
        public void ShowPersons()
        {
            Console.WriteLine("List of persons");
            foreach (person p in perss)
            { 
           
                p.ShowPersonInfo();
                Console.WriteLine("\n");
            }
        }
        public void AddPerson(person item)
        {
            foreach (person p in perss) 
            { 
                if (p.passport == item.passport)
                {
                    Console.WriteLine("Such person is  already in the list");
                    break;
                }
            }
            perss.Add(item);
            onChangePeople();
        }
        public void SearchByDestination(string dest)
        {
            foreach (person p in perss)
            {
                p.doYouHaveThisTicket(dest);
            }
        }
        public void SellTicketByNumber(string personPassport, int num)
        {
            foreach (person p in perss)
            {
                if (p.passport == personPassport)
                {
                    p.doYouHaveThisTicket(num);
                    onBoughtTicket();
                }
            }
        }
        public void BuyTicket(int ticket, string personPassport, terminal oneTicket)
        {
            if (oneTicket.isThereATicket(ticket) == true)
            {
                foreach (person p in perss)
                {
                    if (p.passport == personPassport)
                    {
                        p.addTicket(ticket, oneTicket.ticketPrice(ticket), oneTicket.ticketDestination(ticket));
                        onBoughtTicket();
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no such ticket");
            }
        }
        public void Index(int index)
        {
            try
            {
                if (index > perss.Count)
                {
                    throw new IndexOutOfRangeException("Index error");
                }
                perss[index].ShowPersonInfo();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }
        public void countAllBoughtTicketsPrice()
        {
            decimal completeSum=0;
            foreach (person p in perss)
            {
               completeSum += p.boughtTickets();
            }
            Console.WriteLine("\nAll bought tickets sum is: " + completeSum + "\n");
        }
        public void boughtSumForExactPerson(int n)
        {
            decimal moneySpent = 0;
            try
            {
                if (n > perss.Count)
                {
                    throw new IndexOutOfRangeException("Index error");
                }
                moneySpent+= perss[n].boughtTickets();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("\nPerson: " + perss[n].passport +" spent " + moneySpent + "\n");
        }
        public void mostSpender()
        {
            Console.WriteLine("And the most spender is: ");
            LINQue.whoPaidMore(perss);
        }
        public void numPaidMoreThan(int price)
        {
            LINQue.passengersWhoPaidMoreThan(perss, price);
        }
        public void showTracks(string passp)
        {
            foreach (person p in perss)
            {
                if (p.passport == passp)
                {
                    Console.WriteLine("\nPerson: " + p.passport + " bought his tickets in such ways: " );
                    p.showTicketByTrack();
                } 
            }
        }
    }
}
