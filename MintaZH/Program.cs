using System;

namespace MintaZH
{
    class Program
    {
        static void Main(string[] args)
        {
            string adatsor = @"Marc-André ter Stegen#kapus#0*Neto#kapus#0*Nélson Semedo#védő#2*Gerard Piqué#védő#3*Jean-Clair Todibo#védő#0*Clément Lenglet#védő#0*Moussa Wagué#védő#1*Jordi Alba#védő#2*Sergi Roberto#védő#1*Samuel Umtiti#védő#0*Junior Firpo#védő#0*Ivan Rakitić#középpályás#4*Sergio Busquets#középpályás#5*Arthur#középpályás#3*Carles Aleñá#középpályás#0*Frenkie de Jong#középpályás#0*Arturo Vidal#középpályás#4*Luis Suárez#támadó#5*Lionel Messi#támadó#8*Ousmane Dembélé#támadó#2*Antoine Griezmann#támadó#5*Ansu Fati#támadó#0";

            string[] nevek = null;
            int[] golok = null;
            string[] posztok = null;
            TombGenerator(adatsor, ref nevek, ref golok, ref posztok);

            if(Kapus(posztok) == true)
            {
                Console.WriteLine("Van a csapatnak kapusa.");
            }
            else
            {
                Console.WriteLine("Nincs a csapatnak kapusa.");
            }
            
            Console.WriteLine("Gólkirály indexe: {0}", GolKiraly(golok));
            Console.WriteLine("Védők száma: {0}", VedokSzama(posztok));

            //védők
            Console.WriteLine("\nVédők nevei:");
            foreach(string vedo in VedokNevei(nevek, posztok))
            {
                Console.WriteLine(vedo);
            }

            // toplista
            Console.WriteLine("\nTop 3 góllövő:");
            foreach(string top in TopGollovok(nevek, golok))
            {
                Console.WriteLine(top);
            }

            Console.WriteLine("\nGólkirály góljainak száma mínusz átlagosan szerzett gól: {0}", Golerosseg(golok));
            Console.WriteLine("Legtöbb gólt szerzett védő indexe: {0}", GolerosVedo(golok, posztok));

            Console.ReadLine();
        }

        static void TombGenerator(string adatsor, ref string[] nevek, ref int[] golok, ref string[] posztok)
        {
            string[] jatekosok = adatsor.Split("*");
            nevek = new string[jatekosok.Length];
            golok = new int[jatekosok.Length];
            posztok = new string[jatekosok.Length];

            for(int i = 0; i < jatekosok.Length; i++)
            {
                string[] adatok = jatekosok[i].Split("#");
                nevek[i] = adatok[0];
                golok[i] = int.Parse(adatok[2]);
                posztok[i] = adatok[1];
            }
        }

        static bool Kapus(string [] posztok)
        {
            foreach(string elem in posztok)
            {
                if(elem == "kapus")
                {
                    return true;
                }
            }
            return false;
        }

        static int GolKiraly(int [] golok)
        {
            int maxindex = 0;
            for(int i = 1; i < golok.Length; i++)
            {
                if(golok[i] > golok[maxindex])
                {
                    maxindex = i;
                }
            }
            return maxindex;
        }

        static int VedokSzama(string [] posztok)
        {
            int db = 0;
            foreach(string elem in posztok)
            {
                if(elem == "védő")
                {
                    db++;
                }
            }
            return db;
        }

        static string[] VedokNevei(string[] nevek, string[] posztok)
        {
            string[] vedok = new string[VedokSzama(posztok)];
            int idx = -1;
            for(int i = 0; i < posztok.Length; i++)
            {
                if(posztok[i] == "védő")
                {
                    idx++;
                    vedok[idx] = nevek[i];
                }
            }
            return vedok;
        }

        static string[] TopGollovok(string [] nevek, int [] golok)
        {
            string[] toplista = new string[3];

            // másolás lokális tömbökbe
            int[] _golok = new int[golok.Length];
            string[] _nevek = new string[nevek.Length];

            for(int i = 0; i < golok.Length; i++)
            {
                _golok[i] = golok[i];
                _nevek[i] = nevek[i];
            }

            // rendezés csökkenő sorrendbe
            for(int i = 1; i < _golok.Length; i++)
            {
                int j = i-1;
                int gol_seged = _golok[i];
                string nev_seged = _nevek[i];

                while(j >= 0 && _golok[j] < gol_seged)
                {
                    _golok[j+1] = _golok[j];
                    _nevek[j+1] = _nevek[j];
                    j--;
                }
                _golok[j+1] = gol_seged;
                _nevek[j+1] = nev_seged;
            }

            // toplista feltöltése
            for(int i = 0; i < 3; i++)
            {
                toplista[i] = _nevek[i] + " (" + _golok[i] + ")";
            }

            return toplista;
        }

        static double Golerosseg(int [] golok)
        {
            int max = 0;
            int sum = 0;

            foreach(int gol in golok)
            {
                if(gol > max)
                {
                    max = gol;
                }
                sum += gol;
            }

            return max - (double)sum / golok.Length;
        }

        static int GolerosVedo(int [] golok, string [] posztok)
        {
            int idx = 0;
            for(int i = 0; i < posztok.Length; i++)
            {
                if(posztok[i] == "védő" && golok[i] > golok[idx])
                {
                    idx = i;
                }
            }
            return idx;
        }
    }
}
