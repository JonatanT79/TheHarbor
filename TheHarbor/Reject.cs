using System;
using System.Collections.Generic;
using System.Text;

namespace TheHarbor
{
    class Reject
    {
        List<Boat> RejectedBoats = new List<Boat>();

        public void RejectBoatIfItDoesNotFitInHarbor(Boat boat)
        {
            RejectedBoats.Add(boat);
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
    }
}
