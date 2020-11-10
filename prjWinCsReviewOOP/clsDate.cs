using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinCsReviewOOP
{
    public class clsDate
    {
        // private fields or real variables that will store the values of the properties
        private int vDay;
        private int vMonth;
        private int vYear;

        // Declaration of constructors
        public clsDate()
        {
            vDay = 1;
            vMonth = 1;
            vYear = 1;

        }

        public clsDate(int Day, int Month, int Year)
        {
            this.Day = Day ;
            this.Month = Month ;
            this.Year = Year;
            
        }

        public clsDate(int day, int month)
        {
            Day = day;
            Month = month;
            Year = DateTime .Today .Year;

        }

        // Public access methods for the properties
        public int Day
        {
            get  // access for reading
            {
                return vDay;
            }
            set  // access for writing
            {
                vDay =(value>=1 && value <=31)? value : DateTime.Today.Day ;
            }
        }

        public int Month
        {
            get  // access for reading
            {
                return vMonth;
            }
            set  // access for writing
            {
                vMonth = (value >= 1 && value <= 12) ? value : DateTime.Today.Month;
            }
        }

        public int Year
        {
            get  // access for reading
            {
                return vYear;
            }
            set  // access for writing
            {
                vYear = (value >= 1 && value <= 9999) ? value : DateTime.Today.Year;
            }
        }

        // Public methods

        public void Initialize(int aDay, int aMonth, int aYear)
        {
            Day = aDay;
            Month = aMonth;
            Year = aYear;
        }

        public string ToNumber()
        {
            return Day + "/" + Month + "/" + Year;
        }

        public string ToLetter()
        {
            string info = "";
            string[] tabDaysNames = {"Sunday ", "Monday ", "Tuesday ", "Wednesday ", "Thursday ", "Friday ", "Saturday " };
            string[] tabMonthsNames = { "January ", "February ", "March ", "April ", "May ", "Juin ", "July ", "August ",
                "September ", "October ", "November ", "December " };


            DateTime mydate = new DateTime(Year, Month, Day);
            int indxWeekDay = Convert.ToInt32(mydate.DayOfWeek);

            //switch(indxWeekDay)
            //{
            //    case 0:
            //        info = "Sunday " ; break;
            //    case 1:
            //        info = "Monday "; break;
            //    case 2:
            //        info = "Tuesday "; break;
            //    case 3:
            //        info = "Wednesday "; break;
            //    case 4:
            //        info = "Thursday "; break;
            //    case 5:
            //        info = "Friday "; break;
            //    case 6:
            //        info = "Saturday "; break;
            //}

            //info += Day + " of ";

            //switch (Month)
            //{
            //    case 1:
            //        info += "January "; break;
            //    case 2:
            //        info += "February "; break;
            //    case 3:
            //        info += "March "; break;
            //    case 4:
            //        info += "April "; break;
            //    case 5:
            //        info += "May "; break;
            //    case 6:
            //        info += "Juin "; break;
            //    case 7:
            //        info += "July "; break;
            //    case 8:
            //        info += "August "; break;
            //    case 9:
            //        info += "September "; break;
            //    case 10:
            //        info += "October "; break;
            //    case 11:
            //        info += "November "; break;
            //    case 12:
            //        info += "December "; break;

            //}

            //info += Year;

            info = tabDaysNames[indxWeekDay] + Day + " of " + tabMonthsNames[Month - 1] + Year;

           return info;
        }

    }
}
