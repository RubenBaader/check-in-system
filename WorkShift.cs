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
        public User ShiftUser { get; set; }
        public string ShiftNote { get; set; }

        public WorkShift(User shiftUser, string shiftNote = "Check in for work" )
        {
            CheckInTime = DateTime.Now;
            ShiftUser = shiftUser;
            ShiftNote = shiftNote;
        }
        public void CheckOut()
        {
            CheckOutTime = DateTime.Now;
        }

    }
}
