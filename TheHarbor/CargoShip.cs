namespace TheHarbor
{
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
