using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL_Programmering_Eksamen
{
    internal class WorkShiftManager
    {
        private List<WorkShift> workShifts;

        public WorkShiftManager() 
        { 
            workShifts = new List<WorkShift>();
        }

        public void Add(WorkShift workShift)
        {
            workShifts.Add(workShift);
        }
        public void PrintAll()
        {
            foreach (WorkShift workShift in workShifts)
            {
                Console.WriteLine(workShift.ToString());
            }
        }
        public List<WorkShift> Search(string input) 
        {
            List<WorkShift> result = new List<WorkShift>();
            foreach (WorkShift workShift in workShifts)
            {
                if (workShift.ToString().Contains(input))
                {
                    result.Add(workShift);
                }
            }
            return result;
            //return workShifts.Where().ToList();
        }
        public string ToString(List<WorkShift> list) 
        {
            string result = string.Empty;
            foreach (WorkShift workShift in list)
            {
                result += workShift.ToString();
            }
            return result;
        }
    }
}
