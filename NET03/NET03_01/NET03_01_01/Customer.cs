using System;
using System.Collections.Generic;
using System.Text;

namespace NET03_01_01
{
    class Customer
    {
        private string name;
        private string contactPhone;
        private decimal revenue;

        public string Name { get => name; set => name = value; }
        public string ContactPhone { get => contactPhone; set => contactPhone = value; }
        public decimal Revenue { get => revenue; set => revenue = value; }
    }
}
