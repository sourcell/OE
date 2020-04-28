using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    static class Beolvaso
    {
        public static void ListabaToltes(string fajl, TevekenysegLista lista)
        {
            StreamReader reader = new StreamReader(fajl);
            string sor;

            while ((sor = reader.ReadLine()) != null)
            {
                string[] adatok = sor.Split(' ');

                string tipus = adatok[0];
                string cim = adatok[1];
                int orak = int.Parse(adatok[2].Split(':')[0]);
                int percek = int.Parse(adatok[2].Split(':')[1]);
                TimeSpan idoigeny = new TimeSpan(orak, percek, 0);

                int prioritas = int.Parse(adatok[3]);

                if (tipus == "heti" || tipus == "napi" || tipus == "evi" || tipus == "allithato")
                {
                    int kezdoEv = int.Parse(adatok[4].Split('.')[0]);
                    int kezdoHonap = int.Parse(adatok[4].Split('.')[1]);
                    int kezdoNap = int.Parse(adatok[4].Split('.')[2]);
                    DateTime kezdoDatum = new DateTime(kezdoEv, kezdoHonap, kezdoNap);

                    if (tipus == "heti")
                    {
                        lista.Beszur(new HetiTevekenyseg(cim, idoigeny, prioritas, kezdoDatum));
                    }
                    
                    if (tipus == "napi")
                    {
                        lista.Beszur(new NapiTevekenyseg(cim, idoigeny, prioritas, kezdoDatum));
                    }

                    if (tipus == "evi")
                    {
                        lista.Beszur(new EviTevekenyseg(cim, idoigeny, prioritas, kezdoDatum));
                    }

                    if (tipus == "allithato")
                    {
                        TimeSpan ismetlodes = TimeSpan.FromDays(int.Parse(adatok[5]));
                        lista.Beszur(new AllithatoIsmetlodoTevekenyseg(cim, idoigeny, prioritas, kezdoDatum, ismetlodes));
                    }
                }
                else if (tipus == "egyszeri")
                {
                    EgyszeriTevekenyseg t = new EgyszeriTevekenyseg(cim, idoigeny, prioritas, lista);
                    t.Figyelo += ElvegezveTorlo;
                    t.Figyelo += ElvegezveErtesito;
                    lista.Beszur(t);
                }
            }

            reader.Close();
        }

        static void ElvegezveErtesito(Tevekenyseg t)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tevékenység elvégezve: " + t.Cim);
            Console.ResetColor();
        }

        static void ElvegezveTorlo(Tevekenyseg t)
        {
            (t as IAutomatikusanBeoszthato).Lista.Torol(t);
        }
    }
}
