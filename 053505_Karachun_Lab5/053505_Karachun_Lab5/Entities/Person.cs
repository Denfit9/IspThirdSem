using _053505_Karachun_Lab5.Collections;
using System;

namespace _053505_Karachun_Lab5.Entities
{
    class terminal
    {
        MyCustomCollection<ticket> tickets = new MyCustomCollection<ticket>();
        public void ShowTickets()
        {
            Console.WriteLine("\nList of tickets in this terminal:\n");
            Node<ticket> current = tickets.head;
            while (current != null)
            {
                current.Item.ShowTicketInfo();
                current = current.Next;
            }
        }
        public void AddToTerminal(ticket item)
        {
            Node<ticket> current = tickets.head;
            while (current != null)
            {
                if (current.Item.ticketNumber == item.ticketNumber)
                {
                    current.Item.destination = item.destination;
                    current.Item.price = item.price;
                    Console.WriteLine("Ticket changed");
                    break;
                }
                current = current.Next;
            }
            tickets.Add(item);
        }
        public string ticketDestination(int ticketnumber)
        {
            Node<ticket> current = tickets.head;
            while (current != null)
            {
                if (current.Item.ticketNumber == ticketnumber)
                {
                    return current.Item.destination;
                    break;
                }
                current = current.Next;
            }
            return "nothing";
        }
        public int ticketPrice(int ticketnumber)
        {
            Node<ticket> current = tickets.head;
            while (current != null)
            {
                if (current.Item.ticketNumber == ticketnumber)
                {
                    return current.Item.price;
                    break;
                }
                current = current.Next;
            }
            return 0;
        }
        public bool isThereATicket(int ticketnumber)
        {
            Node<ticket> current = tickets.head;
            while (current != null)
            {
                if (current.Item.ticketNumber == ticketnumber)
                {
                    return true;
                    break;
                }
                current = current.Next;
            }
            return false;
        }

    }
    class ticket
    {
        public int ticketNumber;
        public string destination;
        public int price;
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
        MyCustomCollection<ticket> arr = new MyCustomCollection<ticket>();

        public void ShowPersonInfo()
        {
            Console.WriteLine("Person's passport=" + passport + "\nThis person spent on his tickets= " + moneySpent + " money\n");
            Console.WriteLine("Person's tickets: ");
            Node<ticket> current = arr.head;
            if (arr.count == 0)
            {
                Console.WriteLine("Actually this person haven't bought anything");
            }
            while (current != null)
            {
                current.Item.ShowTicketInfo();
                current = current.Next;
            }
        }
        public void addTicket(int numTicket, int price, string destination)
        {
            arr.Add(new ticket { destination = destination, price = price, ticketNumber = numTicket });
            arr.count++;
            moneySpent = moneySpent + price;


        }
        public void doYouHaveThisTicket(string destination)
        {
            Node<ticket> current = arr.head;
            while (current != null)
            {
                if (current.Item.destination == destination)
                {
                    Console.WriteLine("Person " + passport + " bough ticket number " + current.Item.ticketNumber + " on the way to: " + destination + "\n");
                }
                current = current.Next;
            }
        }
        public void doYouHaveThisTicket(int num)
        {
            Node<ticket> current = arr.head;
            while (current != null)
            {
                if (current.Item.ticketNumber == num)
                {
                    moneySpent = moneySpent - current.Item.price;
                    arr.RemoveCurrent();
                    arr.count--;
                }
                current = current.Next;
            }
        }
    }
    class persons
    {
        MyCustomCollection<person> perss = new MyCustomCollection<person>();
        public void ShowPersons()
        {
            Console.WriteLine("List of persons");
            Node<person> current = perss.head;
            while (current != null)
            {
                current.Item.ShowPersonInfo();
                Console.WriteLine("\n");
                current = current.Next;
            }
        }
        public void AddPerson(person item)
        {
            Node<person> current = perss.head;
            while (current != null)
            {
                if (current.Item.passport == item.passport)
                {
                    Console.WriteLine("Such person is  already in the list");
                    break;
                }
                current = current.Next;
            }
            perss.Add(item);
        }
        public void BuyTicket(int ticket, string personPassport, terminal oneTicket)
        {
            if (oneTicket.isThereATicket(ticket) == true)
            {
                Node<person> currentPerson = perss.head;
                while (currentPerson != null)
                {
                    if (currentPerson.Item.passport == personPassport)
                    {
                        currentPerson.Item.addTicket(ticket, oneTicket.ticketPrice(ticket), oneTicket.ticketDestination(ticket));
                    }
                    currentPerson = currentPerson.Next;
                }
            }
            else
            {
                Console.WriteLine("There is no such ticket");
            }
        }
        public void SearchByDestination(string dest)
        {
            Node<person> currentPers = perss.head;
            while (currentPers != null)
            {
                currentPers.Item.doYouHaveThisTicket(dest);
                currentPers = currentPers.Next;
            }
        }
        public void SellTicketByNumber(string personPassport, int num)
        {
            Node<person> currentPers = perss.head;
            while (currentPers != null)
            {
                if (currentPers.Item.passport == personPassport)
                {
                    currentPers.Item.doYouHaveThisTicket(num);
                }
                currentPers = currentPers.Next;

            }
        }
        public void Index ( int index )
        {
            perss[index].Item.ShowPersonInfo();

            
        }

    }

}
