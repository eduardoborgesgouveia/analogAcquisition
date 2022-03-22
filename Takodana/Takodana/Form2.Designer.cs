namespace Takodana
{
	partial class Form2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.btForcaMax = new System.Windows.Forms.Button();
			this.panelInicial = new System.Windows.Forms.Panel();
			this.btForcaMin = new System.Windows.Forms.Button();
			this.panelForcaMaxima = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.panelForcaMinima = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.panelInicial.SuspendLayout();
			this.panelForcaMaxima.SuspendLayout();
			this.panelForcaMinima.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(60, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Calibração";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(35, 100);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(277, 23);
			this.progressBar.Step = 1;
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar.TabIndex = 1;
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// btForcaMax
			// 
			this.btForcaMax.Location = new System.Drawing.Point(41, 47);
			this.btForcaMax.Name = "btForcaMax";
			this.btForcaMax.Size = new System.Drawing.Size(148, 33);
			this.btForcaMax.TabIndex = 2;
			this.btForcaMax.Text = "Força Máxima";
			this.btForcaMax.UseVisualStyleBackColor = true;
			this.btForcaMax.Click += new System.EventHandler(this.btForcaMax_Click);
			// 
			// panelInicial
			// 
			this.panelInicial.Controls.Add(this.btForcaMin);
			this.panelInicial.Controls.Add(this.btForcaMax);
			this.panelInicial.Controls.Add(this.label1);
			this.panelInicial.Location = new System.Drawing.Point(97, 31);
			this.panelInicial.Name = "panelInicial";
			this.panelInicial.Size = new System.Drawing.Size(237, 137);
			this.panelInicial.TabIndex = 3;
			// 
			// btForcaMin
			// 
			this.btForcaMin.Location = new System.Drawing.Point(41, 86);
			this.btForcaMin.Name = "btForcaMin";
			this.btForcaMin.Size = new System.Drawing.Size(148, 34);
			this.btForcaMin.TabIndex = 3;
			this.btForcaMin.Text = "Força Mínima";
			this.btForcaMin.UseVisualStyleBackColor = true;
			this.btForcaMin.Click += new System.EventHandler(this.btForcaMin_Click);
			// 
			// panelForcaMaxima
			// 
			this.panelForcaMaxima.Controls.Add(this.panelForcaMinima);
			this.panelForcaMaxima.Controls.Add(this.label2);
			this.panelForcaMaxima.Controls.Add(this.progressBar);
			this.panelForcaMaxima.Location = new System.Drawing.Point(41, 42);
			this.panelForcaMaxima.Name = "panelForcaMaxima";
			this.panelForcaMaxima.Size = new System.Drawing.Size(346, 162);
			this.panelForcaMaxima.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(102, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(143, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Força Máxima";
			// 
			// panelForcaMinima
			// 
			this.panelForcaMinima.Controls.Add(this.label3);
			this.panelForcaMinima.Controls.Add(this.progressBar1);
			this.panelForcaMinima.Location = new System.Drawing.Point(8, 8);
			this.panelForcaMinima.Name = "panelForcaMinima";
			this.panelForcaMinima.Size = new System.Drawing.Size(346, 162);
			this.panelForcaMinima.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(102, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "Força Mínima";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(35, 100);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(277, 23);
			this.progressBar1.Step = 1;
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 1;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(442, 224);
			this.Controls.Add(this.panelForcaMaxima);
			this.Controls.Add(this.panelInicial);
			this.Name = "Form2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Calibração";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
			this.Load += new System.EventHandler(this.Form2_Load);
			this.panelInicial.ResumeLayout(false);
			this.panelInicial.PerformLayout();
			this.panelForcaMaxima.ResumeLayout(false);
			this.panelForcaMaxima.PerformLayout();
			this.panelForcaMinima.ResumeLayout(false);
			this.panelForcaMinima.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Button btForcaMax;
		private System.Windows.Forms.Panel panelInicial;
		private System.Windows.Forms.Button btForcaMin;
		private System.Windows.Forms.Panel panelForcaMaxima;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panelForcaMinima;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ProgressBar progressBar1;
	}
}