using System.Globalization;
using System.Text;

namespace NET03_01_01
{
    internal class FormatNameRevenueDecimalPhone : IFormatStrategy
    {
        public string GetFormattedString(Customer customer)
        {
            return $"{customer.Name}, {customer.Revenue.ToString("N", new CultureInfo("en-US"))}, {customer.ContactPhone}";
        }

        public string PromptString()
        {
            return "Customer record: ";
        }
    }
}