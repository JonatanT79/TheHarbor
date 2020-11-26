using System;
using System.Collections.Generic;
using System.Text;

namespace TheHarbor
{
    class Reject
    {
        public void RejectBoatIfItDoesNotFitInHarbor(Boat boat, ref List<Boat> rejectedBoats)
        {
            rejectedBoats.Add(boat);
        }
        public void ShowAllRejectedBoats(List<Boat> rejectedBoats)
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
