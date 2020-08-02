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
            while (this.pickedLocks < this.totalLocks)
            {
                //fill in the code to actually pick the locks and perform the heist here. 
                int leftVar = 0;
                int rightVar = 0;
                if (this._index - 1 < 0)
                {
                    leftVar = 4;
                }
                rightVar = this._index;

                lockpicks.Get(leftVar, rightVar);
                //When the Thief is picking the lock please add the following line
                Console.WriteLine("Thief " + (this._index + 1) + " is picking locks");
                Thread.Sleep(500);
                lockpicks.Put(leftVar, rightVar);
                Thread.Sleep(500);
                this.pickedLocks++;
            }

            //display that this Thief has picked the required amount of locks
            Console.WriteLine("Thief " + (this._index + 1) + " has finished picking locks");
        }
    }
}
