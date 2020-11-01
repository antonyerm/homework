using System;

namespace NET03_01_01
{
    internal class FormatRevenueRounded : IFormatStrategy
    {
        public string GetFormattedString(Customer customer)
        {
            var revenueRounded = Math.Round(customer.Revenue);
            return $"{revenueRounded}";
        }

        public string PromptString()
        {
            return "Customer record: ";
        }
    }
}