using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senior_Project
{
    class Race
    {
        private string myName;                      //name of the race
        private string[] myStats=new string[3];     //array of stats to be changed
        private int[] myStatChanges = new int[3];   //array of changes to stats in corresponding array

        //constructor
        public Race(string name="", string stat1="", int statChange1=0, string stat2 = "", int statChange2 = 0, string stat3 = "", int statChange3 = 0)
        {
            //assign string parameters to member variables
            myName = name;
            myStats[0] = stat1;
            myStats[1] = stat2;
            myStats[2] = stat3;

            //assign integer parameters to member variables
            myStatChanges[0] = statChange1;
            myStatChanges[1] = statChange2;
            myStatChanges[2] = statChange3;
        }

        //property for the name of the race
        public string Name
        {
            //mutator
            set
            {
                myName = value;
            }
            //accessor
            get
            {
                return myName;
            }
        }

        //property for the first stat being changed
        public string Stat1
        {
            //mutator
            set
            {
                myStats[0] = value;
            }
            //accessor
            get
            {
                return myStats[0];
            }
        }

        //property for the second stat being changed
        public string Stat2
        {
            //mutator
            set
            {
                myStats[1] = value;
            }
            //accessor
            get
            {
                return myStats[1];
            }
        }

        //property for the third stat being changed
        public string Stat3
        {
            //mutator
            set
            {
                myStats[2] = value;
            }
            //accessor
            get
            {
                return myStats[2];
            }
        }

        //property for the first stat change
        public int StatChange1
        {
            //mutator
            set
            {
                myStatChanges[0] = value;
            }
            //accessor
            get
            {
                return myStatChanges[0];
            }
        }

        //property for the second stat change
        public int StatChange2
        {
            //mutator
            set
            {
                myStatChanges[1] = value;
            }
            //accessor
            get
            {
                return myStatChanges[1];
            }
        }

        //property for the third stat change
        public int StatChange3
        {
            //mutator
            set
            {
                myStatChanges[2] = value;
            }
            //accessor
            get
            {
                return myStatChanges[2];
            }
        }
    }
}
