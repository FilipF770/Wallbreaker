﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallbreaker
{
	internal class clsCihla
	{
		// Plátno
		Graphics mobjPlatno;

		// Souřadnice cihly
		int mintCihlaX, mintCihlaY;
		int mintCihlaSirka, mintCihlaVyska;
		Brush mobjBrush;

		// Je cihla vidět?
		bool mblIsVisible;

		//-----------------------------------------
		// Konstruktor
		//-----------------------------------------
		public clsCihla (int intCihlaX, int intCihlaY, int intCihlaSirka, int intCihlaVyska, Graphics objPlatno)
		{
			mintCihlaX = intCihlaX;
			mintCihlaY = intCihlaY;
			mintCihlaSirka = intCihlaSirka;
			mintCihlaVyska = intCihlaVyska;
			mobjBrush = Brushes.Black;
			mblIsVisible = true;

			mobjPlatno = objPlatno;
		}

		/// <summary>
		/// Nastavení barvy štětce cihly
		/// </summary>
		public Brush StetecCihly
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

		//-----------------------------------------
		// Vykreslení Cihly
		//-----------------------------------------
		public void Vykreslit ()
		{
			// Test na viditelnost cihly
			if (mblIsVisible == false)
			{
				return;
			}
		
			mobjPlatno.FillRectangle (mobjBrush, mintCihlaX, mintCihlaY, mintCihlaSirka, mintCihlaVyska);
		}
	}
}
