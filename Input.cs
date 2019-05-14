using System;

namespace Calc
{
    public abstract class Input
    {
        public string input;

        public Input(){
            input = Console.ReadLine();
        }
    }
}
