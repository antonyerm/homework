using System;
using System.Collections.Generic;
using System.Text;

namespace NET03_01_01
{
    internal class TextOutput
    {
        static private IFormatStrategy bufferFiller;

        internal string GetTextOutput(Customer customer)
        {
            var buffer = new StringBuilder();
            buffer.Append(bufferFiller.PromptString());
            buffer.Append(bufferFiller.GetFormattedString(customer));
            return buffer.ToString();
        }

        internal void SetOutputStrategy(FormatType formatType)
        {
            switch (formatType)
            {
                case FormatType.NameRevenueDecimalPhone:
                    TextOutput.bufferFiller = new FormatNameRevenueDecimalPhone();
                    break;
                case FormatType.Phone:
                    TextOutput.bufferFiller = new FormatPhone();
                    break;
                case FormatType.NameRevenueDecimal:
                    TextOutput.bufferFiller = new FormatNameRevenueDecimal();
                    break;
                case FormatType.Name:
                    TextOutput.bufferFiller = new FormatName();
                    break;
                case FormatType.RevenueRounded:
                    TextOutput.bufferFiller = new FormatRevenueRounded();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(formatType), formatType, null);
                    break;
            }
        }
    }
}
