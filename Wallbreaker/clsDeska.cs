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

		// Souřadnice pro vnější použití
		public int pintDeskaX;

		// Pohyb desky
		int mintDeskaPosun;

		// Přístup k formu
		Form1 mobjForm;
		

		//-----------------------------------------
		// Konstruktor
		//-----------------------------------------
		public clsDeska(int intDeskaX, int intDeskaY, int intDeskaSirka, int intDeskaVyska, int intDeskaPosun, Graphics objPlatno)
		{ 
			mintDeskaX = intDeskaX;
			mintDeskaY = intDeskaY;
			mintDeskaSirka = intDeskaSirka;
			mintDeskaVyska = intDeskaVyska;
			mintDeskaPosun = intDeskaPosun;
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

		/// <summary>
		/// Změna souřadnic plošiny
		/// </summary>
		public void Posun ()
		{
			mintDeskaX = mintDeskaX + mintDeskaPosun;
			pintDeskaX = mintDeskaX;
		}

		public void Doleva()
		{
			if (mintDeskaPosun > 0)
			{
				mintDeskaPosun = mintDeskaPosun * (-1);
			}

			

		}

		public void Doprava ()
		{
			if (mintDeskaPosun < 0)
			{
				mintDeskaPosun = mintDeskaPosun * (-1);
			}
		}
		/// <summary>
		/// Přístup k souřadnicím pro zbytek programu
		/// </summary>
		/*public int X
		{
			get
			{
				return mintDeskaX;
			}
			set
			{
				mintDeskaX = value;
			}
		}

		public int Y
		{
			get
			{
				return mintDeskaY;
			}
			set
			{
				mintDeskaY = value;
			}
		}

		public int Sirka
		{
			get
			{
				return mintDeskaSirka;
			}
			set
			{
				mintDeskaSirka = value;
			}
		}

		public int Vyska
		{
			get
			{
				return mintDeskaVyska;
			}
			set
			{
				mintDeskaVyska = value;
			}
		}*/
	}
}
