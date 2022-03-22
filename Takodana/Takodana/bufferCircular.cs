using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takodana
{
	class bufferCircular
	{
		double[] buffer;
		public int tamBuffer;
		public int contAmostra;
		int PWR, PRD;
		public bufferCircular(int tamanho)
		{
			tamBuffer = tamanho;
			buffer = new double[tamanho];
			PWR = 0; PRD = 0; contAmostra = 0;
		}
		public bool push(double[] valor)
		{
			bool resposta = true;
			buffer[PWR] = valor[0];
			if (contAmostra >= tamBuffer - 1)
			{
				resposta = false;
			}
			else
			{
				contAmostra++;
			}
			PWR++;
			if (PWR >= tamBuffer - 1)
				PWR = 0;
			return resposta;
		}
		public bool pop(ref double[] valor)
		{
			if (contAmostra == 0)
				return false;
			else
			{
				valor[0] = buffer[PRD];
				contAmostra--;
				PRD++;
			}
			if (PRD >= tamBuffer - 1)
			{
				PRD = 0;
			}
			return true;
		}
		//provavelmente nem é assim que se esvazia um buffer
		public void esvaziarBuffer()
		{
			PWR = 0;
		}
	}
}
