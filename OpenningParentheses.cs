using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class OpenningParentheses : Token
    {
        public OpenningParentheses()
        {
            this.Type = TokenType.OpenningParentheses;
        }
    }
}
