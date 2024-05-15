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
			mobjKulicka = new clsKulicka (50, 50, 2, 10, mobjPlatnoNaPozadi);
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

			// Nastavení Timeru pro překreslení
			tmrRedraw.Interval = 5;
			tmrRedraw.Enabled = true;
		}

		

		/// <summary>
		/// Překreslení obrazu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tmrRedraw_Tick (object sender, EventArgs e)
		{
			// Vymazat
			mobjPlatnoNaPozadi.Clear (Color.White);

			// Nakresli kolečko
			mobjKulicka.Vykreslit ();

			// Vykreslit cihly
			for (int i = 0; i < mintPocetCihel; i++)
			{
				mobjCihly [i].Vykreslit ();
			}
			
			// Posun kuličky
			mobjKulicka.Posunout ();
			
			// Nakopírování obrázku na PictureBox
			mobjPredniPlatno.DrawImage (mobjBtmp, 0, 0);
		}
	}
}
