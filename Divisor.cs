﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class Divisor : Operator
    {
        public Divisor()
        {
            this.Type = TokenType.Divisor;

        }

        public override double Compute(Expression first, Expression second)
        {
            return first.GetValue() / second.GetValue();

        }
    }
}