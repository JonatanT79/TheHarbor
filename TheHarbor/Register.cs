using System;
using System.Collections.Generic;

namespace TheHarbor
{
    class Register
    {
        Harbor harbor = new Harbor();
        public void AddPowerBoatOnArrival(Boat[] harbor, int currentDay)
        {
            PowerBoat powerBoat = new PowerBoat();
            powerBoat.DayOfArrival = currentDay;
            powerBoat.DayToLeave = currentDay + powerBoat.DaysInHarbor;
            RegisterBoat(harbor, powerBoat);
        }
        public void AddSailBoatOnArrival(Boat[] harbor, int currentDay)
        {
            SailBoat sailBoat = new SailBoat();
            sailBoat.DayOfArrival = currentDay;
            sailBoat.DayToLeave = currentDay + sailBoat.DaysInHarbor;
            RegisterBoat(harbor, sailBoat);
        }
        public void AddCargoShipOnArrival(Boat[] harbor, int currentDay)
        {
            CargoShip cargoShip = new CargoShip();
            cargoShip.DayOfArrival = currentDay;
            cargoShip.DayToLeave = currentDay + cargoShip.DaysInHarbor;
            RegisterBoat(harbor, cargoShip);
        }
        public void RegisterBoat(Boat[] harborList, Boat boat)
        {
            Reject reject = new Reject();
            int emptySpace = harbor.SearchForEmptyHarborSpace(harborList);

            if (emptySpace == -1)
            {
                reject.RejectBoatIfItDoesNotFitInHarbor(boat);
            }
            else if (harbor.CheckIfBoatFitsInHarbor(emptySpace, harborList, boat))
            {
                for (int i = 0; i < boat.HarborSpace; i++)
                {
                    harborList[emptySpace + i] = boat;
                }
            }
        }
    }
}
