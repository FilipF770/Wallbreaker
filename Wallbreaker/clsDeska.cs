﻿using System;
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
		public int pintDeskaX, pintDeskaSirka;

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
			pintDeskaSirka = mintDeskaSirka = intDeskaSirka;
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

		/// <summary>
		/// Pohyb doleva
		/// </summary>
		public void Doleva()
		{
			if (mintDeskaPosun > 0)
			{
				mintDeskaPosun = mintDeskaPosun * (-1);
			}
		}

		/// <summary>
		/// Pohyb doprava
		/// </summary>
		public void Doprava ()
		{
			if (mintDeskaPosun < 0)
			{
				mintDeskaPosun = mintDeskaPosun * (-1);
			}
		}
		
	}
}
