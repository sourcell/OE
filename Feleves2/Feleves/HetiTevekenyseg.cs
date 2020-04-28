using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class HetiTevekenyseg : RendszeresTevekenyseg
    {
        //public TimeSpan Ismetlodes { get; }

        public HetiTevekenyseg(string cim, TimeSpan idoigeny, int prioritas, DateTime kezdoDatum) : base(cim, idoigeny, prioritas, kezdoDatum)
        {
            //Ismetlodes = new TimeSpan(7, 0, 0, 0);
        }

        public override bool LeszEEzATevekenysegAznap(DateTime datum)
        {
            return KezdoDatum.DayOfWeek == datum.DayOfWeek && KezdoDatum <= datum;
        }
    }
}
