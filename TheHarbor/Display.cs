using System;
using System.Collections.Generic;
using System.Text;

namespace TheHarbor
{
    class Display
    {
        public void DisplayAllInformation(Boat[] harborList, List<Boat> rejectedBoats, int currentDay)
        {
            Harbor harbor = new Harbor();
            Reject reject = new Reject();
            PrintAllBoatsInHarbor(harborList);
            Console.WriteLine("");
            Console.WriteLine("Summary:");
            Console.WriteLine($"Day {currentDay}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Amount of empty spaces: { harbor.GetNumberOfEmptySpacesInHarbor(harborList) }");
            ShowAllRejectedBoats(rejectedBoats);
        }
        private void PrintAllBoatsInHarbor(Boat[] harbor)
        {
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
        private void ShowAllRejectedBoats(List<Boat> rejectedBoats)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"All rejected boats (count:{rejectedBoats.Count})");

            foreach (var item in rejectedBoats)
            {
                Console.WriteLine(item.Id);
            }

            Console.ResetColor();
        }

    }
}
