using System;

namespace Calc
{
    public class NumericExpression : Expression
    {
        public bool isValue;
        public double value;

        public NumericExpression(double value){
            isValue = true;
            this.value = value;
        }

        public NumericExpression(){
            isValue = false;
        }
        public override double GetValue(){
            return value; 
        }

        public static new Expression Parse(string input) { return null; }
    }
}
