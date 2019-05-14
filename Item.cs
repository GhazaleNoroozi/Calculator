﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class Item
    {
        public readonly bool IsValue;
        public readonly double Value;
        public readonly Token Token;

        public Item(double value)
        {
            this.IsValue = true;
            this.Value = value;
        }

        public Item(Token token)
        {
            this.IsValue = false;
            this.Token = token;
        }
    }
}