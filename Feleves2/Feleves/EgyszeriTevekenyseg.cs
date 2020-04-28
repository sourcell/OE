using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class EgyszeriTevekenyseg : Tevekenyseg, IAutomatikusanBeoszthato
    {
        public event ValtozasFigyelo Figyelo;

        public TevekenysegLista Lista { get; }

        bool elvegezve = false;
        public bool Elvegezve {
            get { return elvegezve; }
            set
            {
                elvegezve = value;
                Figyelo?.Invoke(this);
            }
        }

        
        public EgyszeriTevekenyseg(string cim, TimeSpan idoigeny, int prioritas, TevekenysegLista lista) : base(cim, idoigeny, prioritas)
        {
            Lista = lista;
        }
    }
}
