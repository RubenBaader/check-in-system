using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL_Programmering_Eksamen
{
    internal class WorkShift
    {
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public User User { get; set; }
        public string Note { get; set; }

        public WorkShift(User user, string note = "Check in for work" )
        {
            CheckInTime = DateTime.Now;
            User = user;
            Note = note;
        }
        //construct from csv
        public WorkShift(string userName, string userNum, string checkInTime, string checkOutTime, string note )
        {
            User = new User(userName, int.Parse(userNum));
            
            //try catch vs look for flag value: abstraction vs efficiency

            CheckInTime = DateTime.Parse(checkInTime);
            //CheckOutTime = DateTime.Parse(checkOutTime);
            if (DateTime.TryParse(checkOutTime, out DateTime value))
            {
                CheckOutTime = value;
            }

            Note = note;
        }
        public void Edit(string note)
        {
            this.Note = note;
        }
        public void CheckOut()
        {
            CheckOutTime = DateTime.Now;
        }
        public override string ToString()
        {
            string str = 
                $"{User} \n" +
                $"Check In: {CheckInTime} \n" +
                (CheckOutTime.HasValue ? $"Check Out: {CheckOutTime} \n" : null) +
                $"Note: {Note} \n";
            return str;
        }
    }
}
