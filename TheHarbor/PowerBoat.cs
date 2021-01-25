namespace TheHarbor
{
    class PowerBoat : Boat
    {
        public PowerBoat()
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
