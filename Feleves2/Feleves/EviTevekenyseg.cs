using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class EviTevekenyseg : RendszeresTevekenyseg
    {
        public EviTevekenyseg(string cim, TimeSpan idoigeny, int prioritas, DateTime kezdoDatum) : base(cim, idoigeny, prioritas, kezdoDatum)
        {

        }

        public override bool LeszEEzATevekenysegAznap(DateTime datum)
        {
            return KezdoDatum.DayOfYear == datum.DayOfYear && KezdoDatum <= datum;
        }
    }
}
