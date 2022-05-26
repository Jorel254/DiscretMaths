
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCD.Models
{
    internal class Polynomial
    {
        public double Value { get; set; }
        public int ValuePow { get; set; }
        public TypeValuePolynomial Type { get; set; }
        public Polynomial(double value, TypeValuePolynomial type, int valuePow)
        {
            Value = value;
            Type = type;
            ValuePow = valuePow;
        }
    }
}
