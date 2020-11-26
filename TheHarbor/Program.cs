using System;

namespace TheHarbor
{
    class Program
    {
        static void Main(string[] args)
        {
            Harbor harbor = new Harbor();
            harbor.RegisterIncomingBoats();
        }
    }
}
//TODO:
//Fix to keep searching for emptyspaces if boat does not fit where a boat left
//Fix if boat does not fit in the spaces where a boat left