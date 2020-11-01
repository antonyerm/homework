using System;
using System.Collections.Generic;
using System.Text;

namespace NET03_01_01
{
    internal interface IFormatStrategy
    {
        public abstract string GetFormattedString(Customer customer);
        public abstract string PromptString();
    }
}
