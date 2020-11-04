namespace NET03_02_03
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class SubscriberB
    {
        public void CountdownReact(object sender, EventArgs e)
        {
            Console.WriteLine($"Class: {this}. Method: CountdownReact. Me too! I also heard that Class: {sender} says the counter just reached zero!");
        }
    }
}
