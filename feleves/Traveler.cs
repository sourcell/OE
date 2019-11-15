using System;

namespace feleves
{
    class Traveler
    {
        public int tripNum;
        public Trip[] trips;

        public Traveler(int tripNum)
        {
            this.tripNum = tripNum;
            this.trips = new Trip[tripNum];
        }

        public string FindOverlaps(Traveler other)
        {
            string output = "";

            for (int i = 0; i < trips.Length; i++)
            {
                string city = trips[i].city;
                for (int j = 0; j < other.tripNum; j++)
                {
                    if (trips[i].city == other.trips[j].city)
                    {
                        if ((other.trips[j].from >= trips[i].from && other.trips[j].from <= trips[i].to)
                        || (other.trips[j].to >= trips[i].from && other.trips[j].to <= trips[i].to))
                        {
                            output += city + "\n";
                        }
                    }
                }
            }

            return output;
        }
    
        public int NumLines(string lines)
        {
            return lines.Split('\n').Length - 1;
        }
    }
}