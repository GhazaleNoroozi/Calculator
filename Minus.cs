using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class Minus : Operator
    {
        public Minus()
        {
            this.Type = TokenType.Minus;
        }

        public override double Compute(Expression first, Expression second)
        {
            return first.GetValue() - second.GetValue();

        }
    }
}
