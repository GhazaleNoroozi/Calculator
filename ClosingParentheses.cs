using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class ClosingParentheses : Token
    {
        public ClosingParentheses()
        {
            this.Type = TokenType.ClosingParentheses;
        }
    }
}
