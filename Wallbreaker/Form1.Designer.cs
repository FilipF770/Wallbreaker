﻿namespace Wallbreaker
{
	partial class Form1
	{
		/// <summary>
		/// Vyžaduje se proměnná návrháře.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Uvolněte všechny používané prostředky.
		/// </summary>
		/// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Kód generovaný Návrhářem Windows Form

		/// <summary>
		/// Metoda vyžadovaná pro podporu Návrháře - neupravovat
		/// obsah této metody v editoru kódu.
		/// </summary>
		private void InitializeComponent ()
		{
			this.components = new System.ComponentModel.Container();
			this.pbPlatno = new System.Windows.Forms.PictureBox();
			this.btTest = new System.Windows.Forms.Button();
			this.tmrRedraw = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pbPlatno)).BeginInit();
			this.SuspendLayout();
			// 
			// pbPlatno
			// 
			this.pbPlatno.BackColor = System.Drawing.Color.White;
			this.pbPlatno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pbPlatno.Location = new System.Drawing.Point(12, 12);
			this.pbPlatno.Name = "pbPlatno";
			this.pbPlatno.Size = new System.Drawing.Size(525, 426);
			this.pbPlatno.TabIndex = 0;
			this.pbPlatno.TabStop = false;
			// 
			// btTest
			// 
			this.btTest.Location = new System.Drawing.Point(584, 12);
			this.btTest.Name = "btTest";
			this.btTest.Size = new System.Drawing.Size(85, 27);
			this.btTest.TabIndex = 1;
			this.btTest.Text = "button1";
			this.btTest.UseVisualStyleBackColor = true;
			this.btTest.Click += new System.EventHandler(this.btTest_Click);
			// 
			// tmrRedraw
			// 
			this.tmrRedraw.Tick += new System.EventHandler(this.tmrRedraw_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btTest);
			this.Controls.Add(this.pbPlatno);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Wall Breaker";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbPlatno)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pbPlatno;
		private System.Windows.Forms.Button btTest;
		private System.Windows.Forms.Timer tmrRedraw;
	}
}

