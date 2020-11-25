﻿using System;

namespace TheHarbor
{
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
}
//Hamn med 25 platser
//Trycka på enter så går man över till nästa dag och hamnen refreshas