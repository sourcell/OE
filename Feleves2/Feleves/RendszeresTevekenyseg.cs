using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    abstract class RendszeresTevekenyseg : Tevekenyseg
    {
        public DateTime KezdoDatum { get; }

        public RendszeresTevekenyseg(string cim, TimeSpan idoigeny, int prioritas, DateTime kezdoDatum) : base(cim, idoigeny, prioritas)
        {
            KezdoDatum = kezdoDatum;
        }

        public abstract bool LeszEEzATevekenysegAznap(DateTime datum);
    }
}
