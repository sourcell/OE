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
    }
}