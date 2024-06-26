﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallbreaker
{
	internal class clsKulicka
	{
		// Plátno
		Graphics mobjPlatno;
	
		// Souřadnice kuličky
		int mintKulickaX, mintKulickaY;
		int mintKulickaPosunX, mintKulickaPosunY;
		int mintKulickaPolomer;
		Brush mobjBrush;

		// Boolean pro zastavení hry
		public bool tmrStop = false;

		//-----------------------------------------
		// Konstruktor
		//-----------------------------------------
		public clsKulicka (int intKulickaX, int intKulickaY, int intKulickaPosun, int intKulickaPolomer, Graphics objPlatno)
		{
			mintKulickaX = intKulickaX;
			mintKulickaY = intKulickaY;
			mintKulickaPosunX = intKulickaPosun;
			mintKulickaPosunY = intKulickaPosun;
			mintKulickaPolomer = intKulickaPolomer;
			mobjBrush = Brushes.Green;

			mobjPlatno = objPlatno;
		}

		/// <summary>
		/// Nastavení barvy štětce kuličky
		/// </summary>
		public Brush StetecKulicky
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

				lobjObrys = new Rectangle (mintKulickaX, mintKulickaY, mintKulickaPolomer, mintKulickaPolomer);
				
				return lobjObrys;
			}
		}

		//-----------------------------------------
		// Vykreslení kuličky
		//-----------------------------------------
		public void Vykreslit()
		{
			mobjPlatno.FillEllipse (mobjBrush, mintKulickaX, mintKulickaY, mintKulickaPolomer, mintKulickaPolomer);
		}

		//-----------------------------------------
		// Změna směru po nárazu
		//-----------------------------------------
		public void ZmenPohyb ()
		{
			mintKulickaPosunY = mintKulickaPosunY * (-1);
		}

		//-----------------------------------------
		// Posun kuličky
		//-----------------------------------------
		public void Posunout ()
		{
			mintKulickaX = mintKulickaX + mintKulickaPosunX;
			mintKulickaY = mintKulickaY + mintKulickaPosunY;

			if ((mintKulickaY + mintKulickaPolomer) > mobjPlatno.VisibleClipBounds.Height)
			{
				mintKulickaPosunY = mintKulickaPosunY * (-1);
				tmrStop = true;
			}

			if ((mintKulickaX + mintKulickaPolomer) > mobjPlatno.VisibleClipBounds.Width)
			{
				mintKulickaPosunX = mintKulickaPosunX * (-1);
			}

			if (mintKulickaY < 0)
			{
				mintKulickaPosunY = mintKulickaPosunY * (-1);
			}

			if (mintKulickaX < 0)
			{
				mintKulickaPosunX = mintKulickaPosunX * (-1);
			}
		}
	}
}
