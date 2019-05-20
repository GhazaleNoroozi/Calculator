using System;

namespace Calc
{
    public abstract class Input
    {
        public string input;

        public Input(){
            input = Console.ReadLine();
            input = input.Replace(" ", "");
            input = input.Replace("\t", "");
        }
    }
}
