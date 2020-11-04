namespace NET03_02_03
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class SubscriberC
    {
        public void CountdownReact(object sender, EventArgs e)
        {
            Console.WriteLine($"Class: {this}. Method: CountdownReact. It ain't funny, guys. It ain't no joke that Class: {sender} has his counter around 0 again!");
        }
    }
}
