﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public abstract class Operator: Token
    {

        public abstract double Compute(Expression first, Expression second);

    }
}