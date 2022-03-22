namespace Takodana
{
	partial class Form1
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelStatusConexao = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusTrials = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.comunicacaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.portaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cb_ports = new System.Windows.Forms.ToolStripComboBox();
			this.conectarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.calibrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ProcedimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iniciarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.pararToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timerToRefreshPorts = new System.Windows.Forms.Timer(this.components);
			this.labelTeste = new System.Windows.Forms.Label();
			this.timerToSeeData = new System.Windows.Forms.Timer(this.components);
			this.timerToCalibration = new System.Windows.Forms.Timer(this.components);
			this.labelLimiar = new System.Windows.Forms.Label();
			this.labelFeedBack = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatusConexao,
            this.toolStripStatusTrials});
			this.statusStrip1.Location = new System.Drawing.Point(0, 456);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(880, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabelStatusConexao
			// 
			this.toolStripStatusLabelStatusConexao.BackColor = System.Drawing.Color.Transparent;
			this.toolStripStatusLabelStatusConexao.Image = global::Takodana.Properties.Resources.nop;
			this.toolStripStatusLabelStatusConexao.Name = "toolStripStatusLabelStatusConexao";
			this.toolStripStatusLabelStatusConexao.Size = new System.Drawing.Size(136, 17);
			this.toolStripStatusLabelStatusConexao.Text = "Status: Desconectado";
			// 
			// toolStripStatusTrials
			// 
			this.toolStripStatusTrials.BackColor = System.Drawing.Color.Transparent;
			this.toolStripStatusTrials.Name = "toolStripStatusTrials";
			this.toolStripStatusTrials.Size = new System.Drawing.Size(46, 17);
			this.toolStripStatusTrials.Text = "Trials: 0";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comunicacaoToolStripMenuItem,
            this.calibrarToolStripMenuItem,
            this.ProcedimentoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(880, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// comunicacaoToolStripMenuItem
			// 
			this.comunicacaoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portaToolStripMenuItem,
            this.conectarToolStripMenuItem1});
			this.comunicacaoToolStripMenuItem.Name = "comunicacaoToolStripMenuItem";
			this.comunicacaoToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
			this.comunicacaoToolStripMenuItem.Text = "Comunicação";
			// 
			// portaToolStripMenuItem
			// 
			this.portaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cb_ports});
			this.portaToolStripMenuItem.Name = "portaToolStripMenuItem";
			this.portaToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.portaToolStripMenuItem.Text = "Porta";
			// 
			// cb_ports
			// 
			this.cb_ports.Name = "cb_ports";
			this.cb_ports.Size = new System.Drawing.Size(121, 23);
			// 
			// conectarToolStripMenuItem1
			// 
			this.conectarToolStripMenuItem1.Name = "conectarToolStripMenuItem1";
			this.conectarToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
			this.conectarToolStripMenuItem1.Text = "Conectar";
			this.conectarToolStripMenuItem1.Click += new System.EventHandler(this.conectarToolStripMenuItem1_Click);
			// 
			// calibrarToolStripMenuItem
			// 
			this.calibrarToolStripMenuItem.Name = "calibrarToolStripMenuItem";
			this.calibrarToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.calibrarToolStripMenuItem.Text = "Calibrar";
			this.calibrarToolStripMenuItem.Click += new System.EventHandler(this.calibrarToolStripMenuItem_Click);
			// 
			// ProcedimentoToolStripMenuItem
			// 
			this.ProcedimentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarToolStripMenuItem1,
            this.pararToolStripMenuItem,
            this.resetarToolStripMenuItem});
			this.ProcedimentoToolStripMenuItem.Name = "ProcedimentoToolStripMenuItem";
			this.ProcedimentoToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.ProcedimentoToolStripMenuItem.Text = "Procedimento";
			this.ProcedimentoToolStripMenuItem.Click += new System.EventHandler(this.ProcedimentoToolStripMenuItem_Click);
			// 
			// iniciarToolStripMenuItem1
			// 
			this.iniciarToolStripMenuItem1.Name = "iniciarToolStripMenuItem1";
			this.iniciarToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.iniciarToolStripMenuItem1.Text = "Iniciar";
			this.iniciarToolStripMenuItem1.Click += new System.EventHandler(this.iniciarToolStripMenuItem1_Click);
			// 
			// pararToolStripMenuItem
			// 
			this.pararToolStripMenuItem.Name = "pararToolStripMenuItem";
			this.pararToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.pararToolStripMenuItem.Text = "Parar";
			this.pararToolStripMenuItem.Click += new System.EventHandler(this.pararToolStripMenuItem_Click);
			// 
			// resetarToolStripMenuItem
			// 
			this.resetarToolStripMenuItem.Name = "resetarToolStripMenuItem";
			this.resetarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.resetarToolStripMenuItem.Text = "Resetar";
			this.resetarToolStripMenuItem.Click += new System.EventHandler(this.resetarToolStripMenuItem_Click);
			// 
			// timerToRefreshPorts
			// 
			this.timerToRefreshPorts.Interval = 1000;
			this.timerToRefreshPorts.Tick += new System.EventHandler(this.timerToRefreshPorts_Tick);
			// 
			// labelTeste
			// 
			this.labelTeste.AutoSize = true;
			this.labelTeste.BackColor = System.Drawing.Color.Transparent;
			this.labelTeste.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.labelTeste.Location = new System.Drawing.Point(395, 153);
			this.labelTeste.Name = "labelTeste";
			this.labelTeste.Size = new System.Drawing.Size(35, 13);
			this.labelTeste.TabIndex = 4;
			this.labelTeste.Text = "label1";
			// 
			// timerToSeeData
			// 
			this.timerToSeeData.Interval = 1;
			this.timerToSeeData.Tick += new System.EventHandler(this.timerToSeeData_Tick);
			// 
			// timerToCalibration
			// 
			this.timerToCalibration.Tick += new System.EventHandler(this.timerToCalibration_Tick);
			// 
			// labelLimiar
			// 
			this.labelLimiar.AutoSize = true;
			this.labelLimiar.BackColor = System.Drawing.Color.Transparent;
			this.labelLimiar.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.labelLimiar.Location = new System.Drawing.Point(633, 153);
			this.labelLimiar.Name = "labelLimiar";
			this.labelLimiar.Size = new System.Drawing.Size(35, 13);
			this.labelLimiar.TabIndex = 5;
			this.labelLimiar.Text = "label1";
			// 
			// labelFeedBack
			// 
			this.labelFeedBack.AutoSize = true;
			this.labelFeedBack.BackColor = System.Drawing.Color.Transparent;
			this.labelFeedBack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFeedBack.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.labelFeedBack.Location = new System.Drawing.Point(771, 66);
			this.labelFeedBack.Name = "labelFeedBack";
			this.labelFeedBack.Size = new System.Drawing.Size(86, 19);
			this.labelFeedBack.TabIndex = 6;
			this.labelFeedBack.Text = "FeedBack";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(880, 478);
			this.Controls.Add(this.labelFeedBack);
			this.Controls.Add(this.labelLimiar);
			this.Controls.Add(this.labelTeste);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem comunicacaoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem portaToolStripMenuItem;
		private System.Windows.Forms.ToolStripComboBox cb_ports;
		private System.Windows.Forms.ToolStripMenuItem conectarToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem ProcedimentoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iniciarToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem pararToolStripMenuItem;
		private System.Windows.Forms.Timer timerToRefreshPorts;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatusConexao;
		private System.Windows.Forms.Label labelTeste;
		private System.Windows.Forms.Timer timerToSeeData;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTrials;
		private System.Windows.Forms.Timer timerToCalibration;
		private System.Windows.Forms.Label labelLimiar;
		private System.Windows.Forms.ToolStripMenuItem calibrarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetarToolStripMenuItem;
		private System.Windows.Forms.Label labelFeedBack;
	}
}

