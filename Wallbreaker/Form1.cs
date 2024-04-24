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

			// Vytvořit kuličku
			mobjKulicka = new clsKulicka (50, 50, 2, 10, mobjPlatnoNaPozadi);

			// Nastavení Timeru pro překreslení
			tmrRedraw.Interval = 5;
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
			// Vymazat
			mobjPlatnoNaPozadi.Clear (Color.White);

			// Nakresli kolečko
			mobjKulicka.Vykreslit ();
			
			// Posun kuličky
			mobjKulicka.Posunout ();
			
			// Nakopírování obrázku na PictureBox
			mobjPredniPlatno.DrawImage (mobjBtmp, 0, 0);
		}
	}
}
