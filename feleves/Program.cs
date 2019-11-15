using System;
using System.IO;


namespace feleves
{
    class Program
    {
        static void Main(string[] args)
        {
            // reading input data
            string[] dataset = File.ReadAllLines("UTAZO.BE");


            Traveler traveler_1 = new Traveler(dataset, true);
            Traveler traveler_2 = new Traveler(dataset, false);


            // find overlaps
            string output = traveler_1.FindOverlaps(traveler_2);
            

            // writing output data
            File.WriteAllText("UTAZO.KI", output.Trim());
        }
    }
}
