using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wallbreaker
{
	internal class clsDeska
	{
		// Plátno
		Graphics mobjPlatno;

		// Souřadnice desky
		int mintDeskaX, mintDeskaY;
		int mintDeskaSirka, mintDeskaVyska;
		Brush mobjBrush;

		// Pohyb desky doleva a doprava
		bool mblDoleva, mblDoprava;

		//-----------------------------------------
		// Konstruktor
		//-----------------------------------------
		public clsDeska(int intDeskaX, int intDeskaY, int intDeskaSirka, int intDeskaVyska, Graphics objPlatno)
		{ 
			mintDeskaX = intDeskaX;
			mintDeskaY = intDeskaY;
			mintDeskaSirka = intDeskaSirka;
			mintDeskaVyska = intDeskaVyska;
			mobjBrush = Brushes.Green;

			mobjPlatno = objPlatno;
		}

		/// <summary>
		/// Nastavení barvy štětce desky
		/// </summary>
		public Brush StetecDesky
		{
			get
			{
				return mobjBrush;
			}
			set
			{
				mobjBrush = value;
			}
		}

		/// <summary>
		/// Vrací obrysový objekt
		/// </summary>
		public Rectangle rectObrys
		{
			get
			{
				Rectangle lobjObrys;

				lobjObrys = new Rectangle (mintDeskaX, mintDeskaY, mintDeskaSirka, mintDeskaVyska);

				return lobjObrys;
			}
		}

		/// <summary>
		/// Pohybuje se deska?
		/// </summary>

		//-----------------------------------------
		// Vykreslení desky
		//-----------------------------------------
		public void Vykreslit ()
		{
			mobjPlatno.FillRectangle (mobjBrush, mintDeskaX, mintDeskaY, mintDeskaSirka, mintDeskaVyska);
		}

	}
}
