using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public abstract class Expression
    {
        public Stack<Item> items = new Stack<Item>();

        public abstract double GetValue();

        public static Expression Parse(string input) { return null; }
    }

}