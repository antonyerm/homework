namespace NET03_01_01
{
    internal class FormatName : IFormatStrategy
    {
        public string GetFormattedString(Customer customer)
        {
            return $"{customer.Name}";
        }

        public string PromptString()
        {
            return "Customer record: ";
        }
    }
}