namespace NET03_02_03
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    class Countdown
    {
        private int counter;

        public event EventHandler CounterReachedZeroEventHandler;

        //public int Counter { get => counter; set => counter = value; }
        public Countdown(int timeoutMs)
        {
            this.counter = timeoutMs;
        }

        public void Start()
        {
            while (counter > 0)
            {
                Thread.Sleep(100);
                counter--;
            }

            Console.WriteLine($"I am class {this}. Method: Start here. Please be informed that the Counter just reached Zero.");
            OnCounterReachedZero(EventArgs.Empty);
        }

        protected virtual void OnCounterReachedZero(EventArgs empty)
        {
            CounterReachedZeroEventHandler?.Invoke(this, empty);
        }
    }
}
