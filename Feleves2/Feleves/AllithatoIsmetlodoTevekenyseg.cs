using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class AllithatoIsmetlodoTevekenyseg : RendszeresTevekenyseg
    {
        public TimeSpan Ismetlodes { get; }

        public AllithatoIsmetlodoTevekenyseg(string cim, TimeSpan idoigeny, int prioritas, DateTime kezdoDatum, TimeSpan ismetlodes) : base(cim, idoigeny, prioritas, kezdoDatum)
        {
            Ismetlodes = ismetlodes;
        }

        public override bool LeszEEzATevekenysegAznap(DateTime datum)
        {
            DateTime test = KezdoDatum;

            while (test < datum)
            {
                test = test.Add(Ismetlodes);
            }

            return test == datum;
        }
    }
}
