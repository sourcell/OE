using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    delegate void ValtozasFigyelo(Tevekenyseg t);

    interface IAutomatikusanBeoszthato
    {
        event ValtozasFigyelo Figyelo;
        TevekenysegLista Lista { get; }
        bool Elvegezve { get; set; }
    }
}
