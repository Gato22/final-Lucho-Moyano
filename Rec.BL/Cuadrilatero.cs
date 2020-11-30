using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rec.BL
{
    public class Cuadrilatero
    {
        private double lado1;

        public double Lado1
        {
            get { return lado1; }
            set { lado1 = value; }
        }
        private double lado2;

        public double Lado2
        {
            get { return lado2; }
            set { lado2 = value; }
        }
        
        public double GetPerimetro()
        {
           return Lado1 * 2+Lado2 * 2;
        }
        public double GetArea()
        {
            return Lado1 * Lado2;
        }

        public double getarea2()
        {
            return Lado1 * Lado1;
        }

    }
}
