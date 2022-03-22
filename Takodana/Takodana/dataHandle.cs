using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;

namespace Takodana
{
	class dataHandle
	{
		//variaveis dos pacotes
		byte vC1 = 0x45; //Identificador Canal 1
		byte vST = 0x24; //Start 
		byte vET = 0x0A; //End
		byte[] temp = new byte[1];
		byte LSB;
		byte MSB;
		double[] valor = new double[1];

		SerialPort portaSerial;
		const int tamanho = 10000;
		bufferCircular canal1Data = new bufferCircular(tamanho);


		public dataHandle(string portName, int baudRate)
		{
			portaSerial = new SerialPort();
			portaSerial.PortName = portName;
			portaSerial.BaudRate = baudRate;
		}
		public void limparSerial()
		{
			if (portaSerial.IsOpen)
			{
				portaSerial.DiscardOutBuffer();
				portaSerial.DiscardInBuffer();
			}
		}
		public void abrirComunicacao()
		{
			if (!portaSerial.IsOpen)
			{
				portaSerial.Open();
				portaSerial.DiscardOutBuffer();
				portaSerial.DiscardInBuffer();
			}

		}
		public void fecharComunicacao()
		{
			if (portaSerial.IsOpen)
			{
				portaSerial.Close();
			}
		}
		public void startRecebimentoDados()
		{
			if (portaSerial.IsOpen)
			{
				portaSerial.WriteLine("e");
			}
		}
		public void stopRecebimentoDados()
		{
			if (portaSerial.IsOpen)
			{
				portaSerial.WriteLine("s");
			}
		}

		public void lerDados()
		{
			if (portaSerial.IsOpen)
			{
				int N = portaSerial.BytesToRead;
				if (N >= 1)
				{
					portaSerial.Read(temp, 0, 1);
					if (temp[0] == vST)
					{
						portaSerial.Read(temp, 0, 1);
						if (temp[0] == vC1)
						{
							receiveC1();
						}
					}
				}
			}
		}


		public int dadosDisponiveisC1()
		{
			return canal1Data.contAmostra;
		}
		private void receiveC1()
		{
			double[] data = new double[1];
			portaSerial.Read(temp, 0, 1);
			MSB = temp[0];
			portaSerial.Read(temp, 0, 1);
			LSB = temp[0];
			data[0] = (MSB << 8 | LSB);
			portaSerial.Read(temp, 0, 1);
			if (temp[0] == vET)
			{
				canal1Data.push(data);
			}

		}
		//provavelmente dispensável visto que minha calibração não está dando certo
		public void cleanData()
		{
			portaSerial.DiscardInBuffer();
			portaSerial.DiscardOutBuffer();
			byte[] discarte = new byte[1];
			int teste = portaSerial.BytesToRead;
			while(teste>0)
			{
				portaSerial.Read(discarte, 0, 1);
			}
			canal1Data.esvaziarBuffer();
		}
		public double receberDadosCanal1()
		{
			canal1Data.pop(ref valor);
			return valor[0];
		}
	}
}
