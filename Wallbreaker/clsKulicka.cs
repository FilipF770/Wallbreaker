using System;
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

		//-----------------------------------------
		// Vykreslení kuličky
		//-----------------------------------------
		public void Vykreslit()
		{
			mobjPlatno.FillEllipse (mobjBrush, mintKulickaX, mintKulickaY, mintKulickaPolomer, mintKulickaPolomer);
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
