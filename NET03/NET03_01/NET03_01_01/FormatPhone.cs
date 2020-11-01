namespace NET03_01_01
{
    internal class FormatPhone : IFormatStrategy
    {
        public string GetFormattedString(Customer customer)
        {
            return $"{customer.ContactPhone}";
        }

        public string PromptString()
        {
            return "Customer record: ";
        }
    }
}