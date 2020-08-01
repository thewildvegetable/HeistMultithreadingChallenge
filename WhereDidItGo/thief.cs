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

                //determines the two nearest lockpicks
                int left = this._index - 1;
                if(left < 0)
                {
                    left = 4;
                }
                int right = this._index;

                //thief goes to get nearest picks
                lockpicks.Get(left,right);
                //When the Thief is picking the lock please add the following line
                Console.WriteLine("Thief " + (this._index + 1) + " is picking locks");
                //time needed to get picks and open the lock
                Thread.Sleep(500);
                //thief returns the picks 
                lockpicks.Put(left, right);
                //time needed to return the picks
                Thread.Sleep(100);
                this.pickedLocks++;

            }

            //display that this Thief has picked the required amount of locks
            Console.WriteLine("Thief " + (this._index + 1) + " has finished picking locks");
        }
    }
}
