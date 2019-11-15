using System;

namespace feleves
{
    class Traveler
    {
        public int tripNum;
        public Trip[] trips;

        public Traveler(string[] dataset, bool isFirst)
        {
            int i;
            if (isFirst)
            {
                i = 0;
            }
            else
            {
                i = int.Parse(dataset[0]) + 1;
            }

            this.tripNum = int.Parse(dataset[i++]);
            this.trips = new Trip[tripNum];

            int j = 0;
            while (i < dataset.Length && dataset[i].Length > 1)
            {
                string[] data = dataset[i].Split(' ');
                int from = int.Parse(data[0]);
                int to = int.Parse(data[1]);
                string city = data[2];

                trips[j++] = new Trip(from, to, city);
                i++;
            }
        }

        public string FindOverlaps(Traveler other)
        {
            string output = "";
            int overlaps = 0;

            for (int i = 0; i < trips.Length; i++)
            {
                string city = trips[i].city;
                for (int j = 0; j < other.tripNum; j++)
                {
                    if (trips[i].city == other.trips[j].city)
                    {
                        if ((other.trips[j].from >= trips[i].from && other.trips[j].from <= trips[i].to)
                        || (other.trips[j].to >= trips[i].from && other.trips[j].to <= trips[i].to)
                        || (other.trips[j].from <= trips[i].from && other.trips[j].to >= trips[i].to))
                        {
                            output += city + Environment.NewLine;
                            overlaps++;
                        }
                    }
                }
            }

            return overlaps + Environment.NewLine + output;
        }
    }
}