using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class Plus : Operator
    {
        public Plus()
        {
            this.Type = TokenType.Plus;
        }

        public override double Compute(Expression first, Expression second)
        {
            return first.GetValue() + second.GetValue();

        }
    }
}
