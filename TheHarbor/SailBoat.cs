namespace TheHarbor
{
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
}
