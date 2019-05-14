using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Calc
{
    public class PreFixExpression : NumericExpression
    {

        public Operator Operator { get; private set; }
        public NumericExpression First { get; private set; }
        public NumericExpression Second { get; private set; }

        private PreFixExpression(Operator op, NumericExpression first, NumericExpression second)
        {   
            this.Operator = op;
            this.First = first;
            this.Second = second;
        }

        private PreFixExpression create()
        {
            Operator o = (Operator) items.Pop().Token;
            NumericExpression f;
            NumericExpression s;

            if(items.Peek().IsValue)
                f = new NumericExpression(items.Pop().Value);
            else
                f = create();
            
            if(items.Peek().IsValue)
                s = new NumericExpression(items.Pop().Value);
            else
                s = create();

            PreFixExpression p = new PreFixExpression(o, f, s);
            // Console.WriteLine(p.First.GetValue() + "" + p.Operator.Type + "" + p.Second.GetValue());
            return p;
        }
        
        public PreFixExpression(Stack<Item> list)
        {   
            this.items = list;
            PreFixExpression temp = create();
            this.Operator = temp.Operator;
            this.First = temp.First;
            this.Second = temp.Second;
        }
        public override double GetValue()
        {
            var listedItems = this.items.ToList();
            if (this.items.Count == 1)
                return listedItems.First().Value;

            return this.Operator.Compute(this.First, this.Second);
        }
    }
}
