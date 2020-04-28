using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class NapiTevekenyseg : RendszeresTevekenyseg
    {
        //public TimeSpan Ismetlodes { get; }

        public NapiTevekenyseg(string cim, TimeSpan idoigeny, int prioritas, DateTime kezdoDatum) : base(cim, idoigeny, prioritas, kezdoDatum)
        {
            //Ismetlodes = new TimeSpan(1, 0, 0, 0);
        }

        public override bool LeszEEzATevekenysegAznap(DateTime datum)
        {
            return true;
        }
    }
}
