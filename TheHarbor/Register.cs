using System;
using System.Collections.Generic;

namespace TheHarbor
{
    class Register
    {
        Harbor harbor = new Harbor();
        Reject reject = new Reject();

        public void AddPowerBoatOnArrival(Boat[] harborList, List<Boat> rejectedBoats, int currentDay)
        {
            PowerBoat powerBoat = new PowerBoat();
            powerBoat.DayOfArrival = currentDay;
            powerBoat.DayToLeave = currentDay + powerBoat.DaysInHarbor;
            RegisterBoat(harborList, rejectedBoats, powerBoat);
        }
        public void AddSailBoatOnArrival(Boat[] harborList, List<Boat> rejectedBoats, int currentDay)
        {
            SailBoat sailBoat = new SailBoat();
            sailBoat.DayOfArrival = currentDay;
            sailBoat.DayToLeave = currentDay + sailBoat.DaysInHarbor;
            RegisterBoat(harborList, rejectedBoats, sailBoat);
        }
        public void AddCargoShipOnArrival(Boat[] harborList, List<Boat> rejectedBoats, int currentDay)
        {
            CargoShip cargoShip = new CargoShip();
            cargoShip.DayOfArrival = currentDay;
            cargoShip.DayToLeave = currentDay + cargoShip.DaysInHarbor;
            RegisterBoat(harborList, rejectedBoats, cargoShip);
        }
        private void RegisterBoat(Boat[] harborList, List<Boat> rejectedBoats, Boat boat)
        {
            int emptySpace = harbor.SearchForEmptyHarborSpace(harborList);

            if (emptySpace == -1)
            {
                reject.RejectBoatIfItDoesNotFitInHarbor(boat, ref rejectedBoats);
            }
            else if (harbor.CheckIfBoatFitsInHarbor(harborList, rejectedBoats, boat, ref emptySpace))
            {
                for (int i = 0; i < boat.HarborSpace; i++)
                {
                    harborList[emptySpace + i] = boat;
                }
            }
        }
    }
}
