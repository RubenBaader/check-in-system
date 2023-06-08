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
            //Due to time constraints, the UI currently handles all high level logic
            TerminalUI UI = new TerminalUI();
            UI.Run();
        }
    }
}