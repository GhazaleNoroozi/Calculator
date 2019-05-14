using System;

namespace Calc
{
    class ValidInput  : Input
    {
        public bool isValid;

        public ValidInput():base(){
             isValid = Validity.areParathesesValid(input) & Validity.areOperationsValid(input) & Validity.areCharachtersValid(input);
        }
    }
}
