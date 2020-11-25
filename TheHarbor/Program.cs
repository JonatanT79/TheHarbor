using System;

namespace TheHarbor
{
    class Program
    {
        static void Main(string[] args)
        {
            MotorBoat motorBoat = new MotorBoat();
            SailBoat sailBoat = new SailBoat();
            CargoShip cargoShip = new CargoShip();
        }
    }
    abstract class Boat
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int HarborSpace { get; set; }
        public int DaysInHarbor { get; set; }
        public double MaxSpeed { get; set; }
        public string UniqueAbility { get; set; }
        public string GenerateRandomId()
        {
            Random rnd = new Random();
            string Id = "";

            for (int i = 0; i < 3; i++)
            {
                int ascii = rnd.Next(65, 91);
                Id += (char)ascii;
            }

            return Id;
        }
    }
    class MotorBoat : Boat
    {
        public MotorBoat()
        {
            Id = "M-" + GenerateRandomId();
            Type = "Motorbåt";
            HarborSpace = 1;
            DaysInHarbor = 3;
            MaxSpeed = 60;
            UniqueAbility = "Antal hästkrafter (10-1000 hk)";
        }
    }
    class SailBoat : Boat
    {
        public SailBoat()
        {
            Id = "S-" + GenerateRandomId();
            Type = "Segelbåt";
            HarborSpace = 2;
            DaysInHarbor = 4;
            MaxSpeed = 12;
            UniqueAbility = "Båtlängd (10-60 fot)";
        }
    }
    class CargoShip : Boat
    {
        public CargoShip()
        {
            Id = "L-" + GenerateRandomId();
            Type = "Lastfartyg";
            HarborSpace = 4;
            DaysInHarbor = 6;
            MaxSpeed = 20;
            UniqueAbility = "Last, antal containers på fartyget just nu: 0-500";
        }
    }
}
//Hamn med 25 platser
//Trycka på enter så går man över till nästa dag och hamnen refreshas