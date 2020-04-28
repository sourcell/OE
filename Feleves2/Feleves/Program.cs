using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class Program
    {
        static void Main(string[] args)
        {

            TevekenysegLista lista = new TevekenysegLista();


            // bemeneti fájl beolvasása és feltöltése rendezett láncolt listába
            try
            {
                Beolvaso.ListabaToltes("input.txt", lista);
                lista.Listaz();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A fájlbeolvasás sikertelen!\nEllenőrizze, hogy létezik-e az input.txt, illetve hogy az adatok megfelelőek-e benne!");
                Console.ResetColor();
            }


            while (true)
            {
                //egy adott nap bekérése a felhasználótól
                DateTime nap = DateTime.Today;
                try
                {
                    Console.Write("Dátum (YYYY.M.D): ");
                    string datum = Console.ReadLine();
                    string[] splitted = datum.Split('.');
                    nap = new DateTime(int.Parse(splitted[0]), int.Parse(splitted[1]), int.Parse(splitted[2]));
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A megadott dátum formátuma nem megfelelő! Az alapértelmezett nap a mai.");
                    Console.ResetColor();
                    Console.ReadLine();
                }


                // adott napi tevékenységek megjelenítése
                Console.WriteLine("Tevékenységek ezen a napon:");
                Tevekenyseg[] adottNapiak = lista.AdottNapiTevekenysegek(nap);

                foreach (var item in adottNapiak)
                {
                    Console.WriteLine(item.Cim);
                }


                // egyszeri tevékenységek beosztása az adott napra
                IAutomatikusanBeoszthato[] beosztas = Beoszto.Beosztas(lista, nap);

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var item in beosztas)
                {
                    
                    Console.WriteLine((item as EgyszeriTevekenyseg).Cim);
                }
                Console.ResetColor();
                Console.WriteLine();


                // feladatok elvégzésének ellenőrzése
                Console.Write("Adja meg szóközzel elválasztva az elvégzett ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("automatikusan beosztható ");
                Console.ResetColor();
                Console.WriteLine("tevékenységeket!");

                string[] bemenetek = Console.ReadLine().Split(' ');

                try
                {
                    foreach (var item in bemenetek)
                    {
                        lista.Elvegezve(item);
                    }
                }
                catch (NemTalaltElemException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nincs ilyen című tevékenység!");
                    Console.ResetColor();
                }


                Console.WriteLine();
            }
        }


    }
}
