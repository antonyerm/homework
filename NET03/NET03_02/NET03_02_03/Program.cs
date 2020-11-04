// Task 3
// Develop a Countdown class, which implements the capability after the appointed time (waiting time is provided by the user) to transmit 
// a message to any subscriber who subscribes to the event. You can use the Thread.Sleep method to create a wait effect. 
// Provide the possibility of subscribing to an event in several classes. Use the console application for testing.


namespace NET03_02_03
{
    using System;

    /// <summary>
    /// Entry class of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry method of the program.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03, 02 Task. Problem 3. Events handling and raising.\n");

            Console.Write("Please enter how many seconds we should wait for the event: ");
            var timeout = Console.ReadLine();
            var timeoutIn100Ms = (int)(double.Parse(timeout) * 10);

            var countDown = new Countdown(timeoutIn100Ms);
            var subscriberA = new SubscriberA();
            var subscriberB = new SubscriberB();
            var subscriberC = new SubscriberC();

            countDown.CounterReachedZeroEventHandler += subscriberA.CountdownReact;
            countDown.CounterReachedZeroEventHandler += subscriberB.CountdownReact;
            countDown.CounterReachedZeroEventHandler += subscriberC.CountdownReact;



            countDown.Start();
        }
    }
}
