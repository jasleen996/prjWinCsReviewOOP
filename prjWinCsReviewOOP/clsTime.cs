using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinCsReviewOOP
{
    public class clsTime
    {
        // Declaration of the fields
       private int vHour; //  0
       private int vMinute;// 0
       private int vSecond;// 0
        
        // public access methods(or functions) to properties
        public int Hour
        {
            get  // access for reading
            {
                return vHour;
            }
            set  // access for writing
            {
                vHour = (value >= 0 && value <= 23) ? value : 0;
            }
        }

        public int Minute
        {
            get  // access for reading
            {
                return vMinute;
            }
            set  // access for writing
            {
                vMinute = (value >= 0 && value <=59)? value : 0 ;
            }
        }

        public int Second
        {
            get  // access for reading
            {
                return vSecond;
            }
            set  // access for writing
            {
                vSecond = (value >= 0 && value <= 59) ? value : 0;
            }
        }

        // Declaration of public methods
        public void Adjust(int aHour, int aMinute, int aSecond)
        {
            Hour = aHour;
            Minute = aMinute ;
            Second = aSecond ;
        }

        public string DisplayUniversal()
        {
            return Hour + ":" + Minute + ":" + Second;
        }
        public string DisplayStandard()
        {
            //if(Hour < 12)
            //{
            //    return Hour + ":" + Minute + ":" + Second + " AM";
            //}
            //else if (Hour > 12)
            //{
            //    return (Hour - 12) + ":" + Minute + ":" + Second + " PM";
            //}
            //else if (Hour == 12)
            //{
            //    return Hour + ":" + Minute + ":" + Second + " PM";
            //}
            //return "";

            return ((Hour > 12) ? (Hour - 12) : Hour) + ":" + Minute + ":" + Second + ((Hour > 12) ? " PM" : " AM");
        }

    }
}
