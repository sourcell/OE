using System;
using System.IO;


namespace feleves
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("UTAZO.BE");
            string[] content = file.ReadToEnd().Split("\n");
            file.Close();

            // utazo 1
            Traveler traveler_1 = new Traveler(int.Parse(content[0]));
            for (int i = 1; i <= traveler_1.tripNum; i++)
            {
                string[] data = content[i].Split(' ');
                int from = int.Parse(data[0]);
                int to = int.Parse(data[1]);
                string city = data[2];

                traveler_1.trips[i-1] = new Trip(from, to, city);
            }

            // utazo 2
            Traveler traveler_2 = new Traveler(int.Parse(content[traveler_1.tripNum+1]));
            for (int i = traveler_1.tripNum + 2; i < traveler_1.tripNum + traveler_2.tripNum + 2; i++)
            {
                string[] data = content[i].Split(' ');
                int from = int.Parse(data[0]);
                int to = int.Parse(data[1]);
                string city = data[2];

                traveler_2.trips[i - (traveler_1.tripNum+2)] = new Trip(from, to, city);
            }

            // find overlaps
            string output = traveler_1.FindOverlaps(traveler_2);
            output = traveler_1.NumLines(output) + "\n" + output;

            StreamWriter kimenet = new StreamWriter("UTAZO.KI");
            kimenet.Write(output.Trim());
            kimenet.Close();
        }
    }
}
