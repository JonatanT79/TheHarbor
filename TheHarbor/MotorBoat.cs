namespace TheHarbor
{
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
}
//Hamn med 25 platser
//Trycka på enter så går man över till nästa dag och hamnen refreshas