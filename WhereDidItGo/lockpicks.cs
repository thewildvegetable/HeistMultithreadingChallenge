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
            //fill in the code here to pick up the 2 lockpicks next to a thief if they are available. Hint: make sure the variables you are accessing can't be accessed by another thread while you are editing them
            lock (this)
            {
                //if either the left or right lockpick is in use, wait for it to be available
                while (this.lockpicks[left] || this.lockpicks[right])
                {
                    Monitor.Wait(this);
                }

                //grab the lockpicks
                this.lockpicks[left] = true;
                this.lockpicks[right] = true;
            }
        }

        //put down lockpicks
        public void Put(int left, int right)
        {
            //fill in the code here to put down the 2 lockpicks that were used by a thief so others can use them.  Hint: make sure the variables you are accessing can't be accessed by another thread while you are editing them
            lock (this)
            {
                //put the lockpicks down
                this.lockpicks[left] = false;
                this.lockpicks[right] = false;

                //alert all thieves waiting for lockpicks
                Monitor.PulseAll(this);
            }
        }
    }
}
