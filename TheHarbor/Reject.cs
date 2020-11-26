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
    }
}
