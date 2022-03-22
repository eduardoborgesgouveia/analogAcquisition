using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Takodana
{
	public partial class Form2 : Form
	{
		int cont = 0;
		dataHandle dataHandle;


		double valorRecebido = 0.0;
		const int qtdeData = 100;
		double[] vetorMax = new double[qtdeData];
		double[] vetorMin = new double[qtdeData];
		int i = 0;
		int j = 0;

		Thread receberDados;
		bool flagMax = false;
		bool flagMin = false;
		bool flagComplete = false;

		public Form2()
		{
			InitializeComponent();
		}
		private void Form2_Load(object sender, EventArgs e)
		{
			panelForcaMaxima.Hide();
			panelForcaMinima.Hide();
			timer.Start();
		}

		double media(double[] value)
		{
			double result = 0;
			double x = 0;
			for(int i=0;i<value.Length;i++)
			{
				x = x + value[i];
			}
			result = x / value.Length;

			return result;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if(flagComplete)
			{
				panelForcaMaxima.Hide();
				panelForcaMinima.Hide();
				panelInicial.Show();
			}
		}
		void dataReceive()
		{
			i = 0;
			while (flagMax)
			{
				if (i == qtdeData-1)
				{
					flagMax = false;
					flagComplete = true;
					dataHandle.stopRecebimentoDados();
				}
				//colocar aqui algo pra interagir com a barrinha
				dataHandle.lerDados();
				valorRecebido = dataHandle.receberDadosCanal1();
				vetorMax[i] = valorRecebido;
				i++;
			}
			j = 0;
			while (flagMin)
			{
				if (j == qtdeData-1)
				{
					flagMin = false;
					flagComplete = true;
					dataHandle.stopRecebimentoDados();
				}
				//colocar aqui algo pra interagir com a barrinha
				dataHandle.lerDados();
				valorRecebido = dataHandle.receberDadosCanal1();
				vetorMin[j] = valorRecebido;
				j++;
			}
		}

		private void btForcaMin_Click(object sender, EventArgs e)
		{
			panelInicial.Hide();
			panelForcaMaxima.Hide();
			panelForcaMinima.Show();
			flagMax = false;
			flagMin = true;
			flagComplete = false;
			dataHandle.abrirComunicacao();
			dataHandle.startRecebimentoDados();
			receberDados = new Thread(dataReceive);
			receberDados.Priority = ThreadPriority.Normal;
			receberDados.Start();
		}

		private void btForcaMax_Click(object sender, EventArgs e)
		{
			panelInicial.Hide();
			panelForcaMinima.Hide();
			panelForcaMaxima.Show();
			flagMax = true;
			flagMin = false;
			flagComplete = false;
			dataHandle.startRecebimentoDados();
			receberDados = new Thread(dataReceive);
			receberDados.Priority = ThreadPriority.Normal;
			receberDados.Start();
		}

		private void Form2_FormClosed(object sender, FormClosedEventArgs e)
		{
			flagMax = false;
			flagMin = false;
		}
	}
}
