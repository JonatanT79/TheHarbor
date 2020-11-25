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
        public void RegisterIncomingBoats()
        {
            Boat[] harborList = new Boat[25];
            Random rnd = new Random();
            const int POWERBOAT_INDEX = 1, SAILBOAT_INDEX = 2, CARGOSHIP_INDEX = 3;
            ConsoleKey key = ConsoleKey.Enter;

            do
            {
                for (int i = 0; i < 5; i++)
                {
                    int boatIndex = rnd.Next(1, 4);

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

            for (int p = 0; p < boat.HarborSpace; p++)
            {
                harbor[emptySpace + p] = boat;
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
                if (harbor[emptySpace + i] != null)
                {
                    return false;
                }
            }

            return true;
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
//Fix if harbor is already full (25 spaces)
//Fix when harbor has 23 spaces taken and there is a boat who takes 4 spaces (cannot fit the boat and avvisa den)