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
            //start the heist
            int left = this._index;
            int right = this._index +1;
            if(this._index == 4){
                right = 0;
            }
            while (this.pickedLocks < this.totalLocks)
            {
                //fill in the code to actually pick the locks and perform the heist here. 
                //When the Thief is picking the lock please add the following line
                //Console.WriteLine("Thief " + (this._index + 1) + " is picking locks");
                if (heldLockpicks == 0){
                    lockpicks.Get(left,right);
                    heldLockpicks = 2;
                }
                if(heldLockpicks == 2){
                    Console.WriteLine("Thief " + (this._index + 1) + " is picking locks");
                    lockpicks.Put(left,right);
                    pickedLocks++;
                }


            }

            //display that this Thief has picked the required amount of locks
            Console.WriteLine("Thief " + (this._index + 1) + " has finished picking locks");
        }
    }
}
