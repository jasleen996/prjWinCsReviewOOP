using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsReviewOOP
{
    public class clsStudent
    {
        // ----  fields or private variables to store the values of the properties
        private string vNumber;
        private string vName;
        private clsDate vBdate;
        private Single vGrade;
        // No vAge because we do not store a value that is calculated and variable withing the time



        // ------- PROPERTIES ---- Public access methods for the properties
        public string Name
        {
            get  // access for reading
            {
                return vName ;
            }
            set  // access for writing
            {
                vName = value;
            }
        }

        public string Number
        {
            get  // access for reading
            {
                return vNumber;
            }
            set  // access for writing
            {
                vNumber = value;
            }
        }
        public clsDate Birthdate
        {
            get  // access for reading
            {
                return vBdate ;
            }
            set  // access for writing
            {
                vBdate = value;
            }
        }

        public Single Grade
        {
            get  // access for reading
            {   return vGrade ; }
              // access for writing NOT allowed, Read-Only           
        }

        public int Age
        {
            get  // access for reading
            {
                return (DateTime.Today.Year - Birthdate.Year);
            }
            // access for writing NOT allowed, Read-Only 
            
        }


        // ------------ CONSTRUCTORS -----------

        public clsStudent()
        {
            Number = Name = "Not defined";
            Birthdate = new clsDate();
            vGrade = -1;
        }

        public clsStudent(string number,string name, int day, int month, int year, Single grade)
        {
            Number = number;
            Name = name;
            Birthdate = new clsDate(day , month , year );
            vGrade = grade;
        }

        public clsStudent(string number, string name, clsDate birthdate, Single grade)
        {
            Number = number;
            Name = name;
            Birthdate = birthdate;
            vGrade = grade;
        }


        // ------- METHODS  ----------
        public void Register(string name, int day, int month, int year)
        {
            Name = name;
            Birthdate.Initialize(day, month, year);
            vGrade = -1;
        }

        public bool ToGrade(Single value)
        {
            if(value >= 0 && value <= 100)
            {
                vGrade = value;
                return true;
            }
            else { return false; }
        }


        public string Display()
        {
            string info ="Number: " + Number + "\nName : " + Name + "\nBirthDate : " + Birthdate.ToLetter();
            info += "\nGrade : " + Grade + " /100 \nAge : " + Age + " years \n";
            return info;
        }
    }
}
