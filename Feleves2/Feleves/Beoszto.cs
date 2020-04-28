using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
	static class Beoszto
	{
		private static bool Fk(IAutomatikusanBeoszthato[] tomb, int szint, bool[] E, int szabadPercek)
		{
			int percek = 0;
			for (int i = 0; i <= szint; i++)
			{
				if (E[i] == true)
				{
					percek += (int)(tomb[i] as Tevekenyseg).Idoigeny.TotalMinutes;
				}
			}
			return percek <= szabadPercek;
		}

		private static int OsszPrio(IAutomatikusanBeoszthato[] tomb, bool[] E)
		{
			int prio = 0;
			for (int i = 0; i < E.Length; i++)
			{
				if (E[i] == true)
				{
					prio += (tomb[i] as Tevekenyseg).Prioritas;
				}
			}
			return prio;
		}

		private static void Masol(bool[] ide, bool[] innen)
		{
			for (int i = 0; i < ide.Length; i++)
			{
				ide[i] = innen[i];
			}
		}

		private static void Backtrack(IAutomatikusanBeoszthato[] tomb, int szint, bool[] E, bool[] OPT, int szabadPercek)
		{
			for (int i = 0; i < 2; i++)
			{
				E[szint] = (i == 0);
				if (Fk(tomb, szint, E, szabadPercek))
				{
					if (szint == E.Length - 1)
					{
						if (OsszPrio(tomb, E) > OsszPrio(tomb, OPT))
						{
							Masol(OPT, E);
						}
					}
					else
					{
						Backtrack(tomb, szint + 1, E, OPT, szabadPercek);
					}
				}
			}
		}

		public static IAutomatikusanBeoszthato[] Beosztas(TevekenysegLista lista, DateTime nap)
		{
			IAutomatikusanBeoszthato[] tomb = lista.BeoszthatokTombje();
			IAutomatikusanBeoszthato[] vissza = new IAutomatikusanBeoszthato[0];

			if (tomb.Length > 0)
			{
				int szabadPercek = (int)lista.SzabadPercekSzama(nap);

				bool[] E = new bool[tomb.Length];
				bool[] OPT = new bool[tomb.Length];

				Backtrack(tomb, 0, E, OPT, szabadPercek);

				// beosztott tevékenységek feltöltése a kimeneti tömbbe
				int db = 0;
				foreach (var item in OPT)
				{
					if (item) db++;
				}

				vissza = new IAutomatikusanBeoszthato[db];

				db = 0;
				for (int i = 0; i < tomb.Length; i++)
				{
					if (OPT[i])
					{
						vissza[db++] = tomb[i];
					}
				}
			}

			return vissza;
		}
	}
}
