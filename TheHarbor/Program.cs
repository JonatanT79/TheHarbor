using System;
using System.Collections.Generic;
using System.Linq;

namespace TheHarbor
{
    class Program
    {
        static void Main(string[] args)
        {
            Harbor harbor = new Harbor();
            harbor.RegisterIncomingBoats();
        }
    }
    class Harbor
    {
        List<Boat> RejectedBoats = new List<Boat>();
        public void RegisterIncomingBoats()
        {
            Boat[] harborList = new Boat[25];
            Random rnd = new Random();
            const int POWERBOAT_INDEX = 1, SAILBOAT_INDEX = 2, CARGOSHIP_INDEX = 3, BOATS_PER_DAY = 5;
            int days = 0;
            ConsoleKey key;
            do
            {
                for (int i = 0; i < BOATS_PER_DAY; i++)
                {
                    //rnd
                    int boatIndex = 3;

                    if (boatIndex == POWERBOAT_INDEX)
                    {
                        AddPowerBoatOnArrival(harborList);
                    }
                    else if (boatIndex == SAILBOAT_INDEX)
                    {
                        AddSailBoatOnArrival(harborList);
                    }
                    else if (boatIndex == CARGOSHIP_INDEX)
                    {
                        AddCargoShipOnArrival(harborList);
                    }
                }

                PrintAllBoatsInHarbor(harborList);
                Console.WriteLine("");
                Console.WriteLine("Summary:");
                Console.WriteLine($"Day {++days}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Amount of empty spaces: {GetTheNumberOfEmptySpaces(harborList)}");
                ShowAllRejectedBoats();
                key = Console.ReadKey().Key;
            }
            while (key == ConsoleKey.Enter);
        }
        public void AddPowerBoatOnArrival(Boat[] harbor)
        {
            PowerBoat powerBoat = new PowerBoat();
            RegisterBoat(harbor, powerBoat);
        }
        public void AddSailBoatOnArrival(Boat[] harbor)
        {
            SailBoat sailBoat = new SailBoat();
            RegisterBoat(harbor, sailBoat);
        }
        public void AddCargoShipOnArrival(Boat[] harbor)
        {
            CargoShip cargoShip = new CargoShip();
            RegisterBoat(harbor, cargoShip);
        }
        public void RegisterBoat(Boat[] harbor, Boat boat)
        {
            int emptySpace = SearchForEmptyHarborSpace(harbor);

            if (CheckIfBoatFitsInTheEmptySpace(emptySpace, harbor, boat))
            {
                for (int i = 0; i < boat.HarborSpace; i++)
                {
                    harbor[emptySpace + i] = boat;
                }
            }
        }
        public int SearchForEmptyHarborSpace(Boat[] harbor)
        {
            Boat findSpace = harbor.Where(h => h == null).FirstOrDefault();
            int harborSpace = Array.IndexOf(harbor, findSpace);
            return harborSpace;
        }
        public bool CheckIfBoatFitsInTheEmptySpace(int emptySpace, Boat[] harbor, Boat boat)
        {
            for (int i = 0; i < boat.HarborSpace; i++)
            {
                int harborSpaceIndex = emptySpace + i;

                if (harborSpaceIndex >= 25)
                {
                    RejectedBoats.Add(boat);
                    return false;
                }

                if (harbor[harborSpaceIndex] != null)
                {
                    //om det är en segelbåt och ENDAST en plats != null, ge emptyspace ett nytt värde innan det läggs till i rejected
                    //lägg till i rejectedboats
                    return false;
                }
            }

            return true;
        }
        public void ShowAllRejectedBoats()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"All rejected boats (count:{RejectedBoats.Count})");

            foreach (var item in RejectedBoats)
            {
                Console.WriteLine(item.Id);
            }

            Console.ResetColor();
        }
        public int GetTheNumberOfEmptySpaces(Boat[] harbor)
        {
            var emptySpacesCount = harbor.Where(e => e == null).Count();
            return emptySpacesCount;
        }
        public void PrintAllBoatsInHarbor(Boat[] harbor)
        {
            //Group by id and print how many spaces they take
            Console.Clear();
            var query = from e in harbor
                        where e != null
                        select e;

            foreach (var item in query)
            {
                Console.WriteLine(item.Id);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(query.Count());
            Console.ResetColor();
        }
    }
}
//TODO:
//Fix when boat leaves