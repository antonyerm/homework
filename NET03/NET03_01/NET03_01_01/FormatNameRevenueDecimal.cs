using System.Globalization;

namespace NET03_01_01
{
    internal class FormatNameRevenueDecimal : IFormatStrategy
    {
        public string GetFormattedString(Customer customer)
        {
            return $"{customer.Name}, {customer.Revenue.ToString("N", new CultureInfo("en-US"))}";
        }

        public string PromptString()
        {
            return "Customer record: ";
        }
    }
}