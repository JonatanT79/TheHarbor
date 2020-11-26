using System;

namespace TheHarbor
{
    abstract class Boat
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int HarborSpace { get; set; }
        public int DaysInHarbor { get; set; }
        public int DayOfArrival { get; set; }
        public int DayToLeave { get; set; }
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
}
