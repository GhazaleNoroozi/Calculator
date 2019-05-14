using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Calc
{
    class Validity  
    {
        public static bool areCharachtersValid(string str){
             return Regex.Match(str,@"^[\-*+/().0-9]*$").Success;
        }

        public static bool areParathesesValid(string str){
            Stack<char> brackets = new Stack<char>();
            try{
                foreach (char c in str){
                    if (c == '(')
                        brackets.Push(c);
                    else if (c == ')')
                            brackets.Pop();
                    else
                        continue;
                }
            }catch{
                return false;
            }
            return brackets.Count == 0 ? true : false;
        }

        public static bool areOperationsValid(string str){
            bool val = false;
            try{
                for(int i = 0; i < str.Length; i ++){
                    if(str[i] == '*' | str[i] == '/' | str[i] == '+' | str[i] == '-'){
                        if(isNumber(str[i - 1]) & isNumber(str[i + 1]))
                            val = true;
                        if(isNumber(str[i - 1]) & str[i+1] == '(')
                            val = true;
                        if(str[i - 1] == ')' & isNumber(str[i + 1]))
                            val = true;
                    }
                }
            }catch{
                val = false;
            }
            return val;
        }

        private static bool isNumber(char c){
            return Regex.Match(c.ToString(),@"^[0-9]$").Success;
        }
    }
}