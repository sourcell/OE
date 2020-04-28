using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class TevekenysegLista
    {
        class Elem
        {
            public Tevekenyseg Tartalom { get; set; }
            public Elem Kovetkezo;
        }

        Elem fej;

        public void Beszur(Tevekenyseg tartalom)
        {
            // új elem inicializásása
            Elem uj = new Elem();
            uj.Tartalom = tartalom;

            // rendezett beszúrás
            Elem e = null;
            Elem p = fej;

            while (p != null && p.Tartalom.Prioritas.CompareTo(uj.Tartalom.Prioritas) < 0)
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (e == null)
            {
                uj.Kovetkezo = fej;
                fej = uj;
            }
            else
            {
                uj.Kovetkezo = p;
                e.Kovetkezo = uj;
            }
        }

        public void Listaz()
        {
            Elem p = fej;

            while (p != null)
            {
                Console.WriteLine(p.Tartalom.Cim + " (" + p.Tartalom.Prioritas + ")");
                p = p.Kovetkezo;
            }
        }

        public void Torol(Tevekenyseg tartalom)
        {
            Elem e = null;
            Elem p = fej;

            while (p != null && !p.Tartalom.Equals(tartalom))
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (p != null)
            {
                if (e == null)
                {
                    fej = p.Kovetkezo;
                }
                else
                {
                    e.Kovetkezo = p.Kovetkezo;
                }
            }
            else
            {
                throw new NemTalaltElemException();
            }
        }

        public IAutomatikusanBeoszthato[] BeoszthatokTombje()
        {
            // tömb méretének meghatározása
            int db  = 0;
            Elem p = fej;
            while (p != null)
            {
                if (p.Tartalom is IAutomatikusanBeoszthato)
                {
                    db++;
                }
                p = p.Kovetkezo;
            }

            // tömbbe másolás
            IAutomatikusanBeoszthato[] vissza = new IAutomatikusanBeoszthato[db];

            int i = 0;
            p = fej;
            while (p != null)
            {
                if (p.Tartalom is IAutomatikusanBeoszthato)
                {
                    vissza[i++] = p.Tartalom as IAutomatikusanBeoszthato;
                }
                p = p.Kovetkezo;
            }

            return vissza;
        }

        public double SzabadPercekSzama(DateTime nap)
        {
            TimeSpan ido = new TimeSpan();

            Elem p = fej;

            while (p != null)
            {
                if (p.Tartalom is RendszeresTevekenyseg && (p.Tartalom as RendszeresTevekenyseg).LeszEEzATevekenysegAznap(nap))
                {
                    ido += p.Tartalom.Idoigeny;
                }
                p = p.Kovetkezo;
            }

            return 300 - ido.TotalMinutes;
        }

        public Tevekenyseg[] AdottNapiTevekenysegek(DateTime nap)
        {
            Elem p = fej;

            // számolás
            int db = 0;
            while (p != null)
            {
                if (p.Tartalom is RendszeresTevekenyseg && (p.Tartalom as RendszeresTevekenyseg).LeszEEzATevekenysegAznap(nap))
                {
                    db++;
                }
                p = p.Kovetkezo;
            }

            // kimeneti tömbbe töltés
            Tevekenyseg[] vissza = new Tevekenyseg[db];
            p = fej;
            db = 0;

            while (p != null)
            {
                if (p.Tartalom is RendszeresTevekenyseg && (p.Tartalom as RendszeresTevekenyseg).LeszEEzATevekenysegAznap(nap))
                {
                    vissza[db++] = p.Tartalom;
                }
                p = p.Kovetkezo;
            }

            return vissza;
        }

        public void Elvegezve(string tevekenysegCim)
        {
            Elem p = fej;
            while (p != null && p.Tartalom.Cim != tevekenysegCim)
            {
                p = p.Kovetkezo;
            }
            if (p != null)
            {
                (p.Tartalom as EgyszeriTevekenyseg).Elvegezve = true;
            }
            else
            {
                throw new NemTalaltElemException();
            }
        }
    }

    class NemTalaltElemException : Exception
    {
        public NemTalaltElemException() : base() { }
    }
}
