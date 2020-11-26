using System;
using System.Collections.Generic;
using System.Linq;

namespace TheHarbor
{
    class Harbor
    {
        public int CurrentDay { get; set; } = 1;

        Reject reject = new Reject();

        public void RegisterIncomingBoats()
        {
            Register register = new Register();
            Random rnd = new Random();
            const int POWERBOAT_INDEX = 1, SAILBOAT_INDEX = 2, CARGOSHIP_INDEX = 3, BOATS_PER_DAY = 5;
            ConsoleKey key;
            Boat[] harborList = new Boat[25];
            List<Boat> rejectedBoats = new List<Boat>();

            do
            {
                for (int i = 0; i < BOATS_PER_DAY; i++)
                {
                    int boatIndex = rnd.Next(1, 4);

                    if (boatIndex == POWERBOAT_INDEX)
                    {
                        register.AddPowerBoatOnArrival(harborList, rejectedBoats, CurrentDay);
                    }
                    else if (boatIndex == SAILBOAT_INDEX)
                    {
                        register.AddSailBoatOnArrival(harborList, rejectedBoats, CurrentDay);
                    }
                    else if (boatIndex == CARGOSHIP_INDEX)
                    {
                        register.AddCargoShipOnArrival(harborList, rejectedBoats, CurrentDay);
                    }
                }

                MakeBoatsToLeaveWhenItsTime(harborList, CurrentDay);
                PrintAllBoatsInHarbor(harborList);
                Console.WriteLine("");
                Console.WriteLine("Summary:");
                Console.WriteLine($"Day {CurrentDay++}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Amount of empty spaces: {GetTheNumberOfEmptySpaces(harborList)}");
                reject.ShowAllRejectedBoats(rejectedBoats);
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
        public int SearchForEmptyHarborSpace(Boat[] harbor, int searchIndex = 0)
        {
            int harborSpace = 0;
            Boat findSpace = harbor.Where(h => h == null).FirstOrDefault();

            if (searchIndex == 0)
            {
                harborSpace = Array.IndexOf(harbor, findSpace);
            }
            else
            {
                harborSpace = Array.IndexOf(harbor, findSpace, searchIndex);
            }

            return harborSpace;
        }
        public bool CheckIfBoatFitsInHarbor(Boat[] harborList, List<Boat> rejectedBoats, Boat boat, ref int emptySpace)
        {
            for (int i = 0; i < boat.HarborSpace; i++)
            {
                int harborSpaceIndex = emptySpace + i;

                if (harborSpaceIndex >= 25)
                {
                    reject.RejectBoatIfItDoesNotFitInHarbor(boat, ref rejectedBoats);
                    return false;
                }

                if (harborList[harborSpaceIndex] != null)
                {
                    emptySpace = SearchForEmptyHarborSpace(harborList, harborSpaceIndex);

                    if (emptySpace < 25)
                    {
                        i = -1;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
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
//Fix emptyspaces