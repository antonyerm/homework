namespace NET03_02_03
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class SubscriberA
    {
        public void CountdownReact(object sender, EventArgs e)
        {
            Console.WriteLine($"Class: {this}. Method: CountdownReact. Class {sender} says the counter just reached zero!");
        }
    }
}
