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
        public int CurrentDay { get; set; } = 1;

        List<Boat> RejectedBoats = new List<Boat>();

        public void RegisterIncomingBoats()
        {
            Boat[] harborList = new Boat[25];
            Random rnd = new Random();
            const int POWERBOAT_INDEX = 1, SAILBOAT_INDEX = 2, CARGOSHIP_INDEX = 3, BOATS_PER_DAY = 5;
            ConsoleKey key;
            do
            {
                for (int i = 0; i < BOATS_PER_DAY; i++)
                {
                    //rnd
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

                MakeBoatsToLeaveWhenItsTime(harborList, CurrentDay);
                PrintAllBoatsInHarbor(harborList);
                Console.WriteLine("");
                Console.WriteLine("Summary:");
                Console.WriteLine($"Day {CurrentDay++}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Amount of empty spaces: {GetTheNumberOfEmptySpaces(harborList)}");
                ShowAllRejectedBoats();
                key = Console.ReadKey().Key;
            }
            while (key == ConsoleKey.Enter);
        }
        public void MakeBoatsToLeaveWhenItsTime(Boat[] harbor, int currentDay)
        {
            for (int i = 0; i < harbor.Length; i++)
            {
                Boat boat = harbor[i];

                if (boat != null)
                {
                    if (boat.DayToLeave == currentDay)
                    {
                        harbor[i] = null;
                    }
                }
            }
        }
        public void AddPowerBoatOnArrival(Boat[] harbor)
        {
            PowerBoat powerBoat = new PowerBoat();
            powerBoat.DayOfArrival = CurrentDay;
            powerBoat.DayToLeave = CurrentDay + powerBoat.DaysInHarbor;
            RegisterBoat(harbor, powerBoat);
        }
        public void AddSailBoatOnArrival(Boat[] harbor)
        {
            SailBoat sailBoat = new SailBoat();
            sailBoat.DayOfArrival = CurrentDay;
            sailBoat.DayToLeave = CurrentDay + sailBoat.DaysInHarbor;
            RegisterBoat(harbor, sailBoat);
        }
        public void AddCargoShipOnArrival(Boat[] harbor)
        {
            CargoShip cargoShip = new CargoShip();
            cargoShip.DayOfArrival = CurrentDay;
            cargoShip.DayToLeave = CurrentDay + cargoShip.DaysInHarbor;
            RegisterBoat(harbor, cargoShip);
        }
        public void RegisterBoat(Boat[] harbor, Boat boat)
        {
            int emptySpace = SearchForEmptyHarborSpace(harbor);

            if (emptySpace == -1)
            {
                RejectBoatIfItDoesNotFitInHarbor(boat);
            }
            else if (CheckIfBoatFitsInTheEmptySpace(emptySpace, harbor, boat))
            {
                for (int i = 0; i < boat.HarborSpace; i++)
                {
                    harbor[emptySpace + i] = boat;
                }
            }
        }
        public void RejectBoatIfItDoesNotFitInHarbor(Boat boat)
        {
            RejectedBoats.Add(boat);
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
                    RejectBoatIfItDoesNotFitInHarbor(boat);
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
            Console.WriteLine($"{"Plats",-8} {"Typ",-15} {"Id",-15} {"Maxhastighet",-15} {"Övrigt",-15}");
            int space = 1;

            foreach (var item in harbor)
            {
                if (item == null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{space,-8} {"Ledig"}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{space,-8} {item.Type,-15} {item.Id,-15} {item.MaxSpeed,-15} {item.UniqueAbility,-15}");
                }
                space++;
            }
        }
    }
}
//TODO:
//Fix to keep searching for emptyspaces if boat does not fit where a boat left
//Fix if boat does not fit in the spaces where a boat left