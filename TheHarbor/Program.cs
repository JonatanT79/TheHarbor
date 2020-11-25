using System;
using System.Collections.Generic;

namespace TheHarbor
{
    class Program
    {
        static void Main(string[] args)
        {

            PowerBoat powerBoat = new PowerBoat();
            SailBoat sailBoat = new SailBoat();
            CargoShip cargoShip = new CargoShip();
            Harbor harbor = new Harbor();
            harbor.RegisterIncomingBoats();

            Console.WriteLine(powerBoat.Id);
            Console.WriteLine(sailBoat.Id);
            Console.WriteLine(cargoShip.Id);
        }
    }
    class Harbor
    {
        public void RegisterIncomingBoats()
        {
            Boat[] harborList = new Boat[25];

            Random rnd = new Random();
            const int POWERBOAT_INDEX = 1, SAILBOAT_INDEX = 2, CARGOSHIP_INDEX = 3;

            for (int i = 0; i < 5; i++)
            {
                int boatIndex = rnd.Next(1, 4);
                if (boatIndex == POWERBOAT_INDEX)
                {
                    PowerBoat motorBoat = new PowerBoat();
                    //check in array for null
                }
                else if (boatIndex == SAILBOAT_INDEX)
                {
                    SailBoat sailBoat = new SailBoat();
                }
                else if (boatIndex == CARGOSHIP_INDEX)
                {
                    CargoShip cargoShip = new CargoShip();
                }
            }
        }

    }
}
//Hamn med 25 platser
//Trycka på enter så går man över till nästa dag och hamnen refreshas