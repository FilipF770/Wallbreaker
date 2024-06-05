using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wallbreaker
{
	public partial class Form1 : Form
	{
		// Bitmapa na kreslení
		Bitmap mobjBtmp;
		Graphics mobjPlatnoNaPozadi;

		// Grafika na PictureBoxu
		Graphics mobjPredniPlatno;

		// Kulicka
		clsKulicka mobjKulicka;

		// Cihly
		clsCihla [] mobjCihly;
		const int mintPocetCihel = 40;
		const int mintPrvniCihlyX = 10, mintPrvniCihlyY = 10, mintPrvniCihlyMezera = 5;
		const int mintSirkaCihly = 50, mintVyskaCihly = 20;

		// Deska
		clsDeska mobjDeska;

		// Mačkám šipky
		public bool mblMackam;

		// Výhra
		//bool mblWin;

		// Konstruktor
		public Form1 ()
		{
			InitializeComponent ();
		}

		


		/// <summary>
		/// Nahrání formu do paměti
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load (object sender, EventArgs e)
		{
			int lintCihlaX, lintCihlaY;
			
			// Vytvoření grafiky z PictureBoxu
			mobjPredniPlatno = pbPlatno.CreateGraphics ();

			// Vytvoření kompatibilní bitmapy a grafiky
			mobjBtmp = new Bitmap (pbPlatno.Width, pbPlatno.Height);
			mobjPlatnoNaPozadi = Graphics.FromImage (mobjBtmp);

			// Vytvořit kuličku
			mobjKulicka = new clsKulicka (50, 200, 2, 10, mobjPlatnoNaPozadi);
			mobjKulicka.StetecKulicky = Brushes.Red;

			// Vytvoření cihel
			mobjCihly = new clsCihla [mintPocetCihel]; // Vytvoření pole (array)

			// Vytvoření jednotlivých cihel
			lintCihlaX = mintPrvniCihlyX;
			lintCihlaY = mintPrvniCihlyY;

			for (int i = 0; i < mintPocetCihel; i++)
			{
				// Vytvoření cihly
				mobjCihly [i] = new clsCihla (lintCihlaX, lintCihlaY, mintSirkaCihly, mintVyskaCihly, mobjPlatnoNaPozadi);

				// Posun po ose X
				lintCihlaX = lintCihlaX + mintSirkaCihly + mintPrvniCihlyMezera;

				// Test na další řadu
				if ((lintCihlaX + mintSirkaCihly + mintPrvniCihlyMezera)> pbPlatno.Width)
				{
					lintCihlaX = mintPrvniCihlyX;
					lintCihlaY = lintCihlaY + mintVyskaCihly + mintPrvniCihlyMezera;
				}
			}

			// Vytvoření desky
			mobjDeska = new clsDeska (240, 400, 90, 10, 5, mobjPlatnoNaPozadi);

			// Nastavení Timeru pro překreslení
			tmrRedraw.Interval = 5;
			tmrRedraw.Enabled = true;
			//mblWin = false;
		}





		/// <summary>
		/// Překreslení obrazu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tmrRedraw_Tick (object sender, EventArgs e)
		{
			// Lokální proměnná pro viditelnost cihel
			bool lblSameVisible = false;
		
			// Vymazat
			mobjPlatnoNaPozadi.Clear (Color.White);

			// Nakresli kolečko
			mobjKulicka.Vykreslit ();

			// Nakresli desku
			mobjDeska.Vykreslit ();

			// Pokud mačkám klávesu, plošina se posune
			if (mblMackam == true)
			{
				mobjDeska.Posun ();
			}



			// Vykreslit cihly
			for (int i = 0; i < mintPocetCihel; i++)
			{
				// Test kolize s kuličkou
				if (true == TestKolizeCihlaKulicka (mobjKulicka.rectObrys, mobjCihly [i].rectObrys))
				{
					// Cihla není vidět
					mobjCihly [i].blVisible = false;

					// Změna pohybu kuličky
					mobjKulicka.ZmenPohyb ();

				}

				// Test na viditelnost všech cihel
				if (mobjCihly [i].blVisible == true)
				{
					lblSameVisible = true;
				}

				// Vykreslení cihel
				mobjCihly [i].Vykreslit ();
			}
			
			if (lblSameVisible == false)
			{
				KonecHryVyhra ();
			}

			// Posun kuličky
			mobjKulicka.Posunout ();

			// Test kolize desky s kuličkou
			if (TestKolizeDeskaKulicka (mobjKulicka.rectObrys, mobjDeska.rectObrys) == true)
			{
				mobjKulicka.ZmenPohyb ();
			}
			
			
			// Nakopírování obrázku na PictureBox
			mobjPredniPlatno.DrawImage (mobjBtmp, 0, 0);

			// Zastavení hry (prohra)
			if (mobjKulicka.tmrStop == true)
			{
				tmrRedraw.Enabled = false;
				KonecHryProhra ();
				
			}
		}

		

		/// <summary>
		/// Test kolize cihly a kuličky
		/// </summary>
		/// <returns></returns>
		private bool TestKolizeCihlaKulicka (Rectangle objRectangleKulicka, Rectangle objRectangleCihla)
		{
			Rectangle lobjPrekryv;

			// Výpočet překryvu
			lobjPrekryv = Rectangle.Intersect (objRectangleKulicka, objRectangleCihla);

			// Test zda existuje překryvný obdélník
			if (lobjPrekryv.Width == 0 && lobjPrekryv.Height == 0)
			{
				return false;
			}
			
			// Objekty se pekrývají
			return true;
		}

		/// <summary>
		/// Test kolize kuličky a desky
		/// </summary>
		/// <param name="objRectangleKulicka"></param>
		/// <param name="objRectangleDeska"></param>
		/// <returns></returns>
		private bool TestKolizeDeskaKulicka (Rectangle objRectangleKulicka, Rectangle objRectangleDeska)
		{
			Rectangle lobjPrekryv;

			// Výpočet překryvu
			lobjPrekryv = Rectangle.Intersect (objRectangleKulicka, objRectangleDeska);

			// Test, jestli existuje překryvný obdélník
			if (lobjPrekryv.Width == 0 && lobjPrekryv.Height == 0)
			{
				return false;
			}

			// Objekty se překrývají
			return true;
		}

		/// <summary>
		/// Zmáčknutí klávesy
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_KeyDown (object sender, KeyEventArgs e)
		{
			try
			{
				switch (e.KeyCode)
				{
					case Keys.Left:
						mobjDeska.Doleva ();

						// Zabrání desce odjet vlevo
						if (mobjDeska.pintDeskaX < 0)
						{
							mblMackam = false;
						}
						else
						{
							mblMackam = true;
						}

						break;

					case Keys.Right:
						mobjDeska.Doprava ();

						// Zabrání desce odjet vpravo
						if (mobjDeska.pintDeskaX + mobjDeska.pintDeskaSirka > mobjPredniPlatno.VisibleClipBounds.Width)
						{
							mblMackam = false;
						}
						else
						{
							mblMackam = true;
						}
						break;
				}
			}

			catch (Exception ex) 
			{
				mblMackam = false;
			}
		}

		/// <summary>
		/// Pustím klávesu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Form1_KeyUp (object sender, KeyEventArgs e)
		{
			mblMackam = false;
		}

		/// <summary>
		/// Prohra
		/// </summary>
		public void KonecHryProhra()
		{
			MessageBox.Show ("Konec hry! Prohra.");
		}

		/// <summary>
		/// Výhra
		/// </summary>
		public void KonecHryVyhra ()
		{
			MessageBox.Show ("Konec hry! Výhra.");
			tmrRedraw.Enabled = false;
		}
	}
}
