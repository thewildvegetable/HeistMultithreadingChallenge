using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WhereDidItGo
{
    class Program
    {
        private static Mutex mute = new Mutex();

        static void Main(string[] args)
        {
            //Initialize the lockpicks
            Lockpicks lockpicks = new Lockpicks();

            //start the Thief threads
            new Thief(0, lockpicks);
            new Thief(1, lockpicks);
            new Thief(2, lockpicks);
            new Thief(3, lockpicks);
            new Thief(4, lockpicks);
        }
    }
}
