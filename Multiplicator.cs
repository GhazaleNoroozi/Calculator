using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class Multiplicator : Operator
    {
        public Multiplicator()
        {
            this.Type = TokenType.Multiplicator;
        }

        public override double Compute(Expression first, Expression second)
        {
            return first.GetValue() * second.GetValue();
        }
    }
}
