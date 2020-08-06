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

        public Lockpicks()
        {
            //initialize available lockpicks
            this.lockpicks = new bool[] { false, false, false, false, false };      //false = lockpick is not in use, true = lockpick is in use
        }

        //grab 2 nearest lockpicks
        public void Get(int left, int right)
        {
            //lock on array using syncroot to ensure only one thread has access to an array's collection
            lock (lockpicks.SyncRoot)
            {
                if (! (lockpicks[left] && lockpicks[right]) )
                {
                    lockpicks[left] = true;
                    lockpicks[right] = true;
                    Thread.Sleep(200);

                }
            }

        }

        //put down lockpicks
        public void Put(int left, int right)
        {
          
            //lock on array using syncroot to ensure only one thread has access to an array's collection
            lock (lockpicks.SyncRoot)
            {
                if( (lockpicks[left] && lockpicks[right] ) )
                {
                    lockpicks[left] = false;
                    lockpicks[right] = false;
                    Thread.Sleep(200);

                }

            }
        }
    }
}
