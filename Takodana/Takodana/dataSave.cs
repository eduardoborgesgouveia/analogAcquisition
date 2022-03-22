using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Takodana
{
	class dataSave
	{
		private StreamWriter file;
		private int cont = 0;
		private string path = null;
		private string nome = null;
		private DateTime timestampInicio;
		private TimeSpan timeTotal;
		private double freqAm = 0.0;
		private string timeName = null;
		public dataSave(string _path, string _nome)
		{
			timeName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss", CultureInfo.InvariantCulture);
			timestampInicio = DateTime.Now;
			nome = _nome + timeName + ".txt";
			path = _path + nome;
			file = new StreamWriter(path, false);
		}
		public void escrever(string value)
		{
			file.WriteLine(value.Replace(@",", "."));
			cont++;
		}
		public void finalizar()
		{
			freqAm = calcularFreq();
			file.WriteLine("Frequência de amostragem: " + freqAm.ToString("#.###").Replace(@",", "."));
			file.Close();
		}
		private double calcularFreq()
		{
			double result = 0;
			timeTotal = DateTime.Now.Subtract(timestampInicio);
			string tempo = timeTotal.TotalSeconds.ToString();
			freqAm = cont / Convert.ToDouble(tempo);
			result = freqAm;
			return result;
		}
		public int contador
		{
			get { return cont; }
		}
	}
}
