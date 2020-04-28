using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    //enum Prio
    //{
    //    alacsony = 1, kozepes, magas
    //}

    abstract class Tevekenyseg
    {
        public string Cim { get; }
        public TimeSpan Idoigeny { get; }
        public int Prioritas { get; }

        public Tevekenyseg(string cim, TimeSpan idoigeny, int prioritas)
        {
            Cim = cim;
            Idoigeny = idoigeny < TimeSpan.FromMinutes(5) ? TimeSpan.FromMinutes(5) : idoigeny;
            Prioritas = prioritas < 1 ? 1 : prioritas;
        }
    }
}
