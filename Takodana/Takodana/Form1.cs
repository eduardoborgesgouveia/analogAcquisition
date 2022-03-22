using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO.Ports;
using Science.Mathematics.VectorCalculus;
using Science.Mathematics;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Takodana
{
	public partial class Form1 : Form
	{
		#region Variaveis 
		#region variaveis comunicação
		//variaveis comunicação
		SerialPort serialPort;
		const int BaudRate = 115200;
		dataHandle dataHandle;
		#endregion

		#region Variaveis dos desenhos da tela
		//variaveis para garantir que o 'start' e o 'finish' vão estar na tela e algumas variaveis sobre a esfera na tela
		double alturaTela = 0;
		double larguraTela = 0;
		int posicaoStartLeft = 0;
		int posicaoStartTop = 0;
		int posicaofinishLineLeft = 0;
		int posicaofinishLineTop = 0;
		int gap = 60;
		int posicaofinishLineLeft2 = 0;
		int posicaofinishLineTop2 = 0;
		int alturaRetangulo = 110;
		int larguraRetangulo = 24;
		int posicaoBolX = 0;
		int posicaoBolY = 0;
		int raioEsfera = 20;
		int posicaoAtualBol = 0;
		int margemErroPixel = 10;
		int centroAlvo = 0;
		bolinha bol;

		System.Drawing.SolidBrush myBrush1 = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
		System.Drawing.SolidBrush myBrush2 = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
		#endregion

		#region variaveis da execução do experimento
		//variaveis da execução do experimento
		DateTime timeFirst;
		TimeSpan timeTotal;

		DateTime TempoInicio;
		TimeSpan TempoFinalTrial;
		double tempoTotalTrial = 0.0;

		double timeStand = 0;
		int trial = 0;
		bool flagToTakeTime = true;
		bool flagToTakeTime2 = false;

		string feedBack = "";
		double trialLento = 6.0;
		double trialRapido = 2.5;
		#endregion

		#region Variaveis para o procedimento
		//variaveis para o procedimento
		Thread aquisicao;
		bool startThreadAquisicao = false;
		bool flagToWait = false;
		double segundosEmEspera = 0.5;
		const int qtdeData = 50;
		double[] vetorData = new double[qtdeData];
		Mutex m;
		#endregion

		#region variaveis para plotagem dos dados através de thread
		//variaveis para plotagem dos dados através de thread
		Thread plotagemDados;
		bool startThreadPlotagem;
		#endregion

		#region variaveis para teste de integração da velocidade para conseguir o espaço
		//variaveis para teste de integração da velocidade para conseguir o espaço	
		double periodo = 0.001;
		double posicaoAnterior = 0;
		double posicaoVelocidade = 0;
		#endregion

		#region variaveis para salvar dados do procedimento
		//variaveis para salvar dados do procedimento
		dataSave fileHandle, fileTrigger, fileTriggerTrocarPeso, fileMediaMovel,fileTriggerInicio,fileDistanciaAlvo;
		string path = "C:/Users/Samsung/Documents/dataProjTakodanaVelocity - 3.0/";
		string name = "dataPotenciometro";
		string nameTrigger = "dataTrigger";
		string nameTriggerPeso = "dataTriggerPeso";
		string nameMediaMovel = "dataMediaMovel";
		string nameTriggerInicio = "dataInicio";
		string nameDistanciaAlvo = "dataDistanciaAlvo";
		bool flagToTriggerInicio = true;
		#endregion

		#region variavais para o limiar e peso
		//variavel para as diferentes etapas
		double peso = 1.0;//1.6 - treinamento (acho que significa 40% da força total da pessoa); 1.2 - adaptação (80% da força?); 1.6 - washout;
		double limiar = 0;
		#endregion

		#region Variaveis para calibração
		//variaveis para calibração
		Thread dataCalibracao;
		bool flagMax = false;
		const int qtdeDataCalibração = 1000;
		double[] vetorMax = new double[qtdeDataCalibração];
		bool flagToProcedimento = false;
		int gama = 0;
		double mediaMax = 0;
		#endregion

		#region variaveis para Média Movel
		const int janelaMedia = 8;
		int contJanelaMedia = 0;
		Queue<double> vetorMediaMovel = new Queue<double>();
		double valueMediaMovel = 0;
		double somaMediaMovel = 0;
		#endregion

		#endregion

		#region Form
		public Form1()
		{
			InitializeComponent();
			serialPort = new SerialPort();
			m = new Mutex();

			this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
			this.UpdateStyles();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			timerToRefreshPorts.Start();


			larguraTela = this.Width;
			alturaTela = this.Height;
			posicaoStartLeft = Convert.ToInt16(0.05 * larguraTela);
			posicaoStartTop = Convert.ToInt16(0.40 * alturaTela);
			posicaofinishLineLeft = Convert.ToInt16(0.9 * larguraTela);
			posicaofinishLineTop = Convert.ToInt16(0.40 * alturaTela);
			posicaofinishLineLeft2 = posicaofinishLineLeft + gap;
			posicaofinishLineTop2 = posicaofinishLineTop;
			posicaoBolX = posicaoStartLeft;
			posicaoBolY = Convert.ToInt16(0.46 * alturaTela);
			bol = new bolinha(posicaoBolX, posicaoBolY, raioEsfera);			
			limiar = 0.4 * larguraTela;
			calibrarToolStripMenuItem.Enabled = false;
			ProcedimentoToolStripMenuItem.Enabled = false;
			pararToolStripMenuItem.Enabled = false;

			centroAlvo = posicaofinishLineLeft2 - Math.Abs((posicaofinishLineLeft+larguraRetangulo-posicaofinishLineLeft2)/ 2);

		}
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			startThreadPlotagem = false;
			startThreadAquisicao = false;
			flagToWait = false;
			flagMax = false;
		}
		#endregion

		#region Comunicação Serial
		public void ComPorts()
		{
			int i = 0;
			bool isDifferent = false;

			//if the length is equal
			if (cb_ports.Items.Count == SerialPort.GetPortNames().Length)
			{
				foreach (string s in SerialPort.GetPortNames())
				{
					//but the strings are different
					if (!cb_ports.Items[i++].Equals(s))
					{
						isDifferent = true;
					}

				}
			}
			else
			{
				isDifferent = true;
			}

			//if nothing changed, nothing to do
			if (!isDifferent)
			{
				return;
			}

			//clear cb items and add new values
			cb_ports.Items.Clear();
			foreach (string s in SerialPort.GetPortNames())
			{
				cb_ports.Items.Add(s);
				//change selected index
				cb_ports.SelectedIndex = 0;
			}

		}

		private void timerToRefreshPorts_Tick(object sender, EventArgs e)
		{
			ComPorts();


		}
		void conectar(string portName)
		{
			if (conectarToolStripMenuItem1.Text == "Conectar")
			{

				dataHandle = new dataHandle(portName, BaudRate); //creates a new data handler to receive data
				dataHandle.abrirComunicacao(); //open serial port

				conectarToolStripMenuItem1.Text = "Desconectar"; //change text
				toolStripStatusLabelStatusConexao.Text = "Conectado"; //change text
				toolStripStatusLabelStatusConexao.Image = Properties.Resources.ok; //change image
				timerToRefreshPorts.Stop();
			}
			else
			{
				dataHandle.fecharComunicacao(); //close serial port

				conectarToolStripMenuItem1.Text = "Conectar"; //change text
				toolStripStatusLabelStatusConexao.Text = "Desconectado"; //change text
				toolStripStatusLabelStatusConexao.Image = Properties.Resources.nop; //change image
				timerToRefreshPorts.Start();
			}

		}
		private void conectarToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				string portName = cb_ports.Items[cb_ports.SelectedIndex].ToString();
				conectar(portName);
				calibrarToolStripMenuItem.Enabled = true;

			}
			catch
			{
				MessageBox.Show("Não foi possível estabelecer conexão", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}


		#endregion

		#region Calibração
		private void calibrarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			flagMax = true;
			timerToCalibration.Start();
			dataHandle.startRecebimentoDados();
			dataCalibracao = new Thread(dataReceiveCalibration);
			dataCalibracao.Priority = ThreadPriority.Normal;
			dataCalibracao.Start();
		}
		void dataReceiveCalibration()
		{
			gama = 0;
			while (flagMax)
			{
				dataHandle.lerDados();
				int valoresDisponiveis = dataHandle.dadosDisponiveisC1();
				if (valoresDisponiveis > 0)
				{
					for (int zz = 0; zz < valoresDisponiveis; zz++)
					{
						double DataBruto = dataHandle.receberDadosCanal1();
						vetorMax[gama] = DataBruto;
						gama++;
						if (gama == qtdeDataCalibração)
						{
							flagMax = false;
							mediaMax = media(vetorMax);
						}
					}
				}
			}
			dataHandle.stopRecebimentoDados();
			flagToProcedimento = true;
		}
		double media(double[] value)
		{
			double result = 0;
			double x = 0;
			for (int i = 0; i < value.Length; i++)
			{
				x = x + value[i];
			}
			result = x / value.Length;
			return result;
		}
		private void timerToCalibration_Tick(object sender, EventArgs e)
		{
			if (flagToProcedimento)
			{
				ProcedimentoToolStripMenuItem.Enabled = true;
				flagToProcedimento = false;
				calibrarToolStripMenuItem.Enabled = false;
			}
		}
		private void ProcedimentoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			timerToCalibration.Stop();
		}
		#endregion
	
		#region Procedimento
		//procedimento

		//botão inicar procedimento
		private void iniciarToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			startThreadPlotagem = true;
			startThreadAquisicao = true;
			flagToWait = true;

			dataHandle.startRecebimentoDados();
			aquisicao = new Thread(aquisicaoData);
			aquisicao.Priority = ThreadPriority.Normal;
			aquisicao.Start();

			plotagemDados = new Thread(plotagemDadosThread);
			plotagemDados.Priority = ThreadPriority.Lowest;
			plotagemDados.Start();

			timerToSeeData.Start();
			pararToolStripMenuItem.Enabled = true;
			iniciarToolStripMenuItem1.Enabled = false;
		}

		//thread para aquisição dos valores
		public void aquisicaoData()
		{
			while (startThreadAquisicao)
			{
				while (flagToWait)
				{
					m.WaitOne();
					dataHandle.lerDados();
					m.ReleaseMutex();
				}
			}
		}
		string score(int posicao)
		{
			
			if(posicao == posicaoStartLeft && flagToTriggerInicio)
			{
				fileTriggerInicio.escrever(fileHandle.contador.ToString());
				flagToTriggerInicio = false;
				TempoInicio = DateTime.Now;

			}
			if(posicao>= posicaofinishLineLeft + larguraRetangulo - margemErroPixel && posicao+raioEsfera <= posicaofinishLineLeft2+margemErroPixel)
			{
				trial++;
				toolStripStatusTrials.Text = "Trials: " + trial.ToString();
				flagToTriggerInicio = true;
				TempoFinalTrial = DateTime.Now.Subtract(TempoInicio);
				tempoTotalTrial= TempoFinalTrial.TotalSeconds;
				if (tempoTotalTrial > trialLento)
				{
					feedBack = "Lento!";
				}
				else if (tempoTotalTrial < trialRapido)
				{
					feedBack = "Muito Rápido!";
				}
				else
				{
					feedBack = "Perfeito!";
				}
				fileDistanciaAlvo.escrever(Convert.ToString(posicao - centroAlvo));
				fileTrigger.escrever(fileHandle.contador.ToString());
				esperar(segundosEmEspera);
				backToTheFuture();				
			}
			else if(posicao+raioEsfera> posicaofinishLineLeft2+margemErroPixel)
			{
				flagToTriggerInicio = true;
				feedBack = "Overshoot!";
				fileDistanciaAlvo.escrever(Convert.ToString(posicao - centroAlvo));
				fileTrigger.escrever(fileHandle.contador.ToString());
				esperar(segundosEmEspera);				
				backToTheFuture();
			}
			return feedBack;
		}
		void esperar(double segundos)
		{
			flagToWait = false;
			timeFirst = DateTime.Now;
			while(flagToWait==false)
			{
				timeTotal = DateTime.Now.Subtract(timeFirst);
				timeStand = timeTotal.TotalSeconds;
				if(timeStand>segundos)
				{
					dataHandle.limparSerial();
					flagToWait = true;
				}
			}
		}
		private void resetarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			backToTheFuture();
		}
		private void timerToSeeData_Tick(object sender, EventArgs e)
		{ 
			this.Refresh();
		}

		public double ajustarParaTela(double value)
		{
			if (value < posicaoStartLeft)
			{
				value = posicaoStartLeft;
			}
			if (value > larguraTela)
			{
				value = larguraTela;
			}
			return value;
		}
		public void backToTheFuture()
		{
			posicaoAnterior = posicaoBolX;
			posicaoVelocidade = posicaoBolX;
		}
		public void plotagemDadosThread()
		{
			fileHandle = new dataSave(path, name);
			fileTrigger = new dataSave(path, nameTrigger);
			fileMediaMovel = new dataSave(path, nameMediaMovel);
			fileTriggerTrocarPeso = new dataSave(path, nameTriggerPeso);
			fileTriggerInicio = new dataSave(path, nameTriggerInicio);
			fileDistanciaAlvo = new dataSave(path, nameDistanciaAlvo);
			while (startThreadPlotagem)
			{

				m.WaitOne();
				int dadosDisponiveis = dataHandle.dadosDisponiveisC1();
				if (dadosDisponiveis > 0)
				{
					for (int zz = 0; zz < dadosDisponiveis; zz++)
					{
						double DataBruto = dataHandle.receberDadosCanal1();
						

						contJanelaMedia++;
						if(contJanelaMedia<janelaMedia)
						{
							vetorMediaMovel.Enqueue(DataBruto);
							somaMediaMovel += DataBruto;
							valueMediaMovel = somaMediaMovel / contJanelaMedia;
						}
						else
						{
							somaMediaMovel -= vetorMediaMovel.Dequeue();
							somaMediaMovel += DataBruto;
							vetorMediaMovel.Enqueue(DataBruto);
							valueMediaMovel = somaMediaMovel / janelaMedia;
						}

						double velocidade = valueMediaMovel;
						posicaoVelocidade = (posicaoAnterior + (velocidade * periodo) / peso);
						posicaoAnterior = posicaoVelocidade;

						posicaoVelocidade = ajustarParaTela(posicaoVelocidade);
						posicaoAtualBol = bol.move((int)posicaoVelocidade);
						
						//double posicao = (((larguraTela - posicaoBolX) / mediaMax) * posicaoAtualBol + posicaoBolX);
						
					
						//variação da posição através da velocidade
						if (posicaoAtualBol >= limiar)
						{
							peso = 1.6;
							fileTriggerTrocarPeso.escrever(fileHandle.contador.ToString());
						}
						if (posicaoAtualBol < limiar)
						{
							peso = 0.6;
						}

						if (DataBruto == 0)
						{
							feedBack = score(posicaoAtualBol);
						}

						fileHandle.escrever(DataBruto.ToString());
						fileMediaMovel.escrever(valueMediaMovel.ToString());

						if (labelTeste.InvokeRequired)
						{
							pontoNaTela = new atribuirPontoNaTela(atribuirPonto);
							labelTeste.BeginInvoke(pontoNaTela, new object[] { valueMediaMovel, feedBack });
						}
					}

				}
				m.ReleaseMutex();
			}
			fileDistanciaAlvo.finalizar();
			fileTriggerTrocarPeso.finalizar();
			fileMediaMovel.finalizar();
			fileHandle.finalizar();
			fileTrigger.finalizar();
			fileTriggerInicio.finalizar();
		}

		delegate void atribuirPontoNaTela(double value, string feedBack);
		public void atribuirPonto(double value, string feedBack)
		{
			labelLimiar.Text = peso.ToString();
			labelTeste.Text = value.ToString("#.#");
			labelFeedBack.Text = feedBack;
		}
		atribuirPontoNaTela pontoNaTela;


		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.FillRectangle(myBrush2, new Rectangle(posicaoStartLeft, posicaoStartTop, larguraRetangulo, alturaRetangulo));
			e.Graphics.FillRectangle(myBrush2, new Rectangle(posicaofinishLineLeft, posicaofinishLineTop, larguraRetangulo, alturaRetangulo));
			e.Graphics.FillRectangle(myBrush2, new Rectangle(posicaofinishLineLeft2, posicaofinishLineTop2, larguraRetangulo, alturaRetangulo));
			e.Graphics.FillEllipse(myBrush1, bol.centro.X, bol.centro.Y, raioEsfera, raioEsfera);
		}
		private void pararToolStripMenuItem_Click(object sender, EventArgs e)
		{
			startThreadAquisicao = false;
			startThreadPlotagem = false;
			flagToWait = false;
			timerToSeeData.Stop();
			dataHandle.stopRecebimentoDados();
			pararToolStripMenuItem.Enabled = false;
			iniciarToolStripMenuItem1.Enabled = true;
		}
		#endregion

	}
}

