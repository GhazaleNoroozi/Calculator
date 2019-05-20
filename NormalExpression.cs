using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calc
{
    public class NormalExpression : Expression
    {
        public static new NormalExpression Parse(string input)
        { 
            var exp = new NormalExpression();
            bool isPrevOperator = true;
            int index = 0;
            string[] strings = Regex.Split(input, @"[-+*/()]");
            foreach (char item in input)
            {
                
                switch (item)
                {
                    case '+':
                        exp.items.Push(new Item(new Plus()));
                        isPrevOperator = true;
                        break;
                    case '-':
                        exp.items.Push(new Item(new Minus()));
                        isPrevOperator = true;
                        break;
                    case '*':
                        exp.items.Push(new Item(new Multiplicator()));
                        isPrevOperator = true;
                        break;
                    case '/':
                        exp.items.Push(new Item(new Divisor()));
                        isPrevOperator = true;
                        break;
                    case ')':
                        exp.items.Push(new Item(new OpenningParentheses()));
                        isPrevOperator = true;
                        break;
                    case '(':
                        exp.items.Push(new Item(new ClosingParentheses()));
                        isPrevOperator = true;
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '.':
                        if(isPrevOperator){
                            for(; index < strings.Length; index++)
                                if(strings[index].Length != 0)
                                    break;
                            var valid = double.TryParse(strings[index], out var doub);
                            if(valid){
                                exp.items.Push(new Item(doub));
                            }
                            index++;
                        }
                        isPrevOperator = false;
                        break;
                }
            }
            return exp;
        }

        public override double GetValue()
        {
            return this.ToPreFixed().GetValue();
        }


        private int position(Item i)
        {
            if(i.Token is OpenningParentheses)
                return 0;
            if(i.Token is Plus)
                return 12;
            if(i.Token is Minus)
                return 12;
            if(i.Token is Multiplicator)
                return 13;
            if(i.Token is Divisor)
                return 13;
            return 5;
        }

        private bool Predecessor(Item firstOperator, Item secondOperator)
        {
            return (position(firstOperator) < position(secondOperator)) ? true : false;
        }

        
        public PreFixExpression ToPreFixed()
        {
            Stack<Item> preFixedItems = new Stack<Item>();
            Item top;
            Stack<Item> oprerator = new Stack<Item>();
            while(items.Count!=0)
            {   
                Item i = items.Pop();
                if (i.IsValue)
                {
                    preFixedItems.Push(i);
                }
                else if (i.Token is OpenningParentheses)
                {
                    oprerator.Push(i);
                }
                else if (i.Token is ClosingParentheses)
                {
                    top = oprerator.Pop();
                    while (!(top.Token is OpenningParentheses))
                    {
                        preFixedItems.Push(top);
                        top = oprerator.Pop();
                    }
                }
                else
                {
                    if (oprerator.Count != 0 && Predecessor(i, oprerator.Peek()))
                    {  
                        preFixedItems.Push( oprerator.Pop());
                        while (oprerator.Count != 0 && Predecessor(i, oprerator.Peek()))
                        {   
                            top = oprerator.Pop();
                            preFixedItems.Push(top);

                        }
                        oprerator.Push(i);
                    }
                    else
                    {
                        oprerator.Push(i);
                    }
                }
            }
            while (oprerator.Count > 0)
            {
                top = oprerator.Pop();
                preFixedItems.Push(top);
            }

            return new PreFixExpression(preFixedItems);
        }

    }
}