using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WhereDidItGo
{
    class Lockpicks
    {
        Mutex bagOfLocks = new Mutex();                 //mutex to control access to the lookpicks
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

            bagOfLocks.WaitOne();                       //waits until lockpicks is clear to let next theif in
            if(lockpicks[left] || lockpicks[right])     //checks if picks are available, if not leave mutex and check again
            {
                bagOfLocks.ReleaseMutex();              //releases theif from mutex
                Thread.Sleep(1);                        //needed to avoid throwing exception for mutex
                this.Get(left, right);
            }
            else
            {
                                                        //removes availability of picks
                lockpicks[left] = true;
                lockpicks[right] = true;
                bagOfLocks.ReleaseMutex();              //releases theif from mutex
            }

        }

        //put down lockpicks
        public void Put(int left, int right)
        {
            //fill in the code here to put down the 2 lockpicks that were used by a thief so others can use them.  Hint: make sure the variables you are accessing can't be accessed by another thread while you are editing them
            
            bagOfLocks.WaitOne();                       //waits until lockpicks is clear to let next theif in
            lockpicks[left] = false;                    //sets availability of picks
            lockpicks[right] = false;
            bagOfLocks.ReleaseMutex();                  //releases theif from mutex

        }
    }
}
