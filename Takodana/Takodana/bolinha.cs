using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Takodana
{
	class bolinha
	{
		public Point centro;
		public int raio;
		public bolinha(int posX, int posY, int _raio)
		{
			centro.X = posX;
			centro.Y = posY;
			raio = _raio;
		}
		public int move(int posX)
		{
			centro.X = posX;
			return centro.X;
		}
	}
}
