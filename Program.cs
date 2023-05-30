namespace UCL_Programmering_Eksamen
{
    internal class Program
    {
        //Program purpose:
        // Create a simple system to check in and out at the workplace

        // Desired features:
        //  Create User
        //  Edit User
        //  Check In (includes timestamp)
        //      Purpose of visit
        //  Edit visitation note
        //  Check out (optional)
        //  Search Visitors
        //  Store data: {Min : in memory, Mod : in file, Max : in DB}
        static void Main()
        {
            TerminalUI UI = new TerminalUI();
            UI.Run();
            //User Bob = new User("Bob", 42);
            //User Martin = new User("Martin", 6969);

            //WorkShift myShift = new WorkShift(Bob);
            //WorkShift newShift = new WorkShift(Bob, "Just workin'");
            //WorkShift anotherShift = new WorkShift(Martin, "Love workin'");
            ////Console.WriteLine("{0}  {1}", myShift.ShiftNote, myShift.CheckInTime);
            //myShift.CheckOut();

            //WorkShiftManager workShiftManager = new WorkShiftManager();
            //workShiftManager.Add(myShift);
            //workShiftManager.Add(newShift);
            //workShiftManager.Add(anotherShift);
            //workShiftManager.PrintAll();
            //Console.WriteLine(workShiftManager.ToString(workShiftManager.Search("Bob")));
        }
    }
}