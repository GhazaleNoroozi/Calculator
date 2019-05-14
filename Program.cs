using System;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!\nOperations you can use: * / - + ()");
            ValidInput input = new ValidInput();
            if(input.isValid)
                Console.WriteLine("result:\n" + (NormalExpression.Parse(input.input)).ToPreFixed().GetValue());
            else
                Console.WriteLine("invalidInput");
        }

    }
}
