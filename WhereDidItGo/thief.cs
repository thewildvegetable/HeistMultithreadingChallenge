using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WhereDidItGo
{
    class Thief
    {
        Lockpicks lockpicks;        //the available locpicks
        private readonly int _index;        //which crew member am I?
        int pickedLocks = 0;        //number of locks picked by this crew member
        int totalLocks = 10;

        public Thief(int i, Lockpicks picks)
        {
            //initialize variables
            this.lockpicks = picks;
            this._index = i;

            //start the heist
            new Thread(new ThreadStart(Heist)).Start();
        }

        //Break into the vault
        public void Heist()
        {
            int heldLockpicks = 0;      //lockpicks in hand

            // assigning which lockpicks will be taken by which thief based on ID
            int leftHand = _index;
            int rightHand;

            if (_index == 4)
            {
                rightHand = 0;
            }
            else
            {
                rightHand = _index + 1;
            }


            //start the heist
            while (this.pickedLocks < this.totalLocks)
            {
                //fill in the code to actually pick the locks and perform the heist here. 
                //When the Thief is picking the lock please add the following line

                this.lockpicks.Get(leftHand, rightHand);
                // thief now has lockpicks
                Console.WriteLine("Thief " + (this._index + 1) + " is picking locks");
                heldLockpicks = 2; // update number of held lockpicks
                this.pickedLocks++;
                Thread.Sleep(200); // sleep to allow other threads to handle work

                this.lockpicks.Put(leftHand, rightHand);
                heldLockpicks = 0;
                Thread.Sleep(200);






            }

            //display that this Thief has picked the required amount of locks
            Console.WriteLine("Thief " + (this._index + 1) + " has finished picking locks");
        }
    }
}
