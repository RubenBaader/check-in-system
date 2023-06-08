﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL_Programmering_Eksamen
{
    internal class WorkShiftManager
    {
        public List<WorkShift> workShifts;

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

        public void SaveWorkshifts(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (WorkShift shift in workShifts)
                {
                    writer.WriteLine(
                        $"{shift.User.Name}," +
                        $"{shift.User.Number}," +
                        $"{shift.CheckInTime}," +
                        $"{(shift.CheckOutTime.HasValue ? shift.CheckOutTime : "Nan") }," +
                        $"{shift.Note}"
                        );
                }
            }
        }
        //not implemented -- time constraints
        public List<WorkShift> LoadWorkShifts(string filePath)
        {
            List<WorkShift> objects = new List<WorkShift>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read data rows
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    WorkShift obj = new WorkShift(values[0], values[1], values[2], values[3], values[4]);

                    objects.Add(obj);
                }
            }

            return objects;
        }
    }

}
