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

		// Souřadnice kuličky
		int mintKulickaX, mintKulickaY;
		
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
			// Vytvoření grafiky z PictureBoxu
			mobjPredniPlatno = pbPlatno.CreateGraphics ();

			// Vytvoření kompatibilní bitmapy a grafiky
			mobjBtmp = new Bitmap (pbPlatno.Width, pbPlatno.Height);
			mobjPlatnoNaPozadi = Graphics.FromImage (mobjBtmp);

			// Nastavení kuličky
			mintKulickaX = mintKulickaY = 10;

			// Nastavení Timeru pro překreslení
			tmrRedraw.Interval = 500;
			tmrRedraw.Enabled = true;
		}

		private void btTest_Click (object sender, EventArgs e)
		{
			
		}

		/// <summary>
		/// Překreslení obrazu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tmrRedraw_Tick (object sender, EventArgs e)
		{
			// Nakreslení kolečka
			mobjPlatnoNaPozadi.FillEllipse (Brushes.Green, mintKulickaX, mintKulickaY, 30, 30);

			// Posun kuličky
			mintKulickaX = mintKulickaX + 5;
			mintKulickaY = mintKulickaY + 5;

			// Nakopírování obrázku na PictureBox
			mobjPredniPlatno.DrawImage (mobjBtmp, 0, 0);
		}
	}
}
