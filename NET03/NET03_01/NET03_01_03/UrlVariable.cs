using System;
using System.Collections.Generic;
using System.Text;

namespace NET03_01_03
{
    /// <summary>
    /// Contains individual URL variable.
    /// </summary>
    internal class UrlVariable
    {
        public UrlVariable(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Value: {Value}";
        }
    }
}
