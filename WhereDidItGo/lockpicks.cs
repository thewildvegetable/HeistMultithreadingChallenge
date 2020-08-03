using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WhereDidItGo
{
    class Lockpicks
    {
        public bool[] lockpicks;    //the available lockpicks
        public static Mutex mutex = new Mutex();

        public Lockpicks()
        {
            //initialize available lockpicks
            this.lockpicks = new bool[] { false, false, false, false, false };      //false = lockpick is not in use, true = lockpick is in use
        }

        //grab 2 nearest lockpicks
        public void Get(int left, int right)
        {
            //fill in the code here to pick up the 2 lockpicks next to a thief if they are available. Hint: make sure the variables you are accessing can't be accessed by another thread while you are editing them

            //Use Mutex
            mutex.WaitOne();

            if(!lockpicks[left] && !lockpicks[right])
            {
                //Since both are free, take them.
                lockpicks[left] = true;
                lockpicks[right] = true;
                mutex.ReleaseMutex();
            }
            else
            {
                mutex.ReleaseMutex(); //StackOverflow, too many recursive Gets.
                Thread.Sleep(100);
                Get(left, right);
            }
        }

        //put down lockpicks
        public void Put(int left, int right)
        {
            //fill in the code here to put down the 2 lockpicks that were used by a thief so others can use them.  Hint: make sure the variables you are accessing can't be accessed by another thread while you are editing them

            //Use Mutex
            mutex.WaitOne();
            lockpicks[left] = false;
            lockpicks[right] = false;
            mutex.ReleaseMutex();
        }
    }
}
