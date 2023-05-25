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
            User Bob = new User("Bob", 42);
            Console.WriteLine($"This is {Bob.Name}. His secret number is {Bob.Number}");

            WorkShift myShift = new WorkShift(Bob);
            Console.WriteLine("{0}  {1}", myShift.ShiftNote, myShift.CheckInTime);
            myShift.CheckOut();
            Console.WriteLine(myShift.CheckOutTime);
            //WorkShift FixYoShift = new WorkShift("I don't give a shift!");
            //Console.WriteLine(FixYoShift.ShiftNote);
        }
    }
}