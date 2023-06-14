using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UCL_Programmering_Eksamen
{
    internal class TerminalUI
    {
        //  Allows the user to interact with the program        
        public TerminalUI() 
        {
            //test list for users
            //for (int i = 0; i < 7; i++)
            //{
            //    User user = new User($"bob{i}", i);
            //    UserList.Add(user);
            //    WorkShift shift = new WorkShift(user);
            //    workShiftManager.workShifts.Add(shift);
            //}

            //workShiftManager.SaveWorkshifts("test.csv");
            workShiftManager.LoadWorkShifts(Path);
            foreach (WorkShift ws in workShiftManager.workShifts)
            {
                UserList.Add(ws.User);
            }

            Console.WriteLine("UI initialized. Welcome!"); 
        }

        private string Path = Directory.GetCurrentDirectory() + "\\Data.csv";
        private WorkShiftManager workShiftManager = new WorkShiftManager();
        private List<User> UserList = new List<User>();
        private User CurrentUser = new User();
        private static readonly Tuple<int, int> MenuStart = Tuple.Create(0, 1);
        private static readonly int MenuWidth = Console.WindowWidth;
        public void Run()
        {
            bool IsRunning = true;

            while (IsRunning)
            {
                Console.Clear();
                string Name = (CurrentUser.Number == -1) ? "stranger" : CurrentUser.Name;
                Console.WriteLine($"Hello {Name}!");
                DisplayMenu();
                string Input = GetInput();

                switch (Input)
                {
                    case "0":
                        LogIn();
                        break;
                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        EditUser();
                        break;
                    case "3":
                        CheckIn();
                        break;
                    case "4":
                        CheckOut();
                        break;
                    case "6":
                        ListWorkshifts();
                        break;
                    case "7":
                        EditWorkShift();
                        break;
                    case "8":
                        ListActiveUsers();
                        break;
                    case "9":
                        SearchActiveUsers();
                        break;
                    case "q":
                        ClearLine();
                        Console.WriteLine("Saving....");
                        // Add try/catch to log errors if saving fails
                        workShiftManager.SaveWorkshifts(Path);
                        Console.WriteLine("Goodbye!");
                        IsRunning= false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private static void DisplayMenu()
        {
            Console.SetCursorPosition( MenuStart.Item1, MenuStart.Item2 );
            Console.WriteLine("Menu:");
            Console.WriteLine("0: Log In");
            Console.WriteLine("1: Create User");
            Console.WriteLine("2: Edit User");
            Console.WriteLine("3: Check In");
            Console.WriteLine("4: Check Out");
            Console.WriteLine("6: List Workshifts");
            Console.WriteLine("7: Edit Workshifts");
            Console.WriteLine("8: List Active Users");
            Console.WriteLine("9: Search Active Users");
            Console.WriteLine("q: quit");
            Console.WriteLine();
            Console.WriteLine("Pick an Option:");
            
        }

        private void LogIn()
        {
            Console.WriteLine("Enter Username");
            string userName = GetInput();

            foreach (User user in this.UserList)
            {
                if (user.Name == userName)
                {
                    this.CurrentUser = user;
                    Console.WriteLine("Welcome, {0}", CurrentUser.Name);
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("ERROR: User not found");
        }
        private void CreateUser()
        {
            int num = new Random().Next(9000);
            Console.WriteLine("Enter Username");
            User user = new User(GetInput(), num);
            Console.WriteLine(user.ToString());
            this.UserList.Add(user);
            this.CurrentUser = user;
            Console.ReadKey();
        }
        private bool ValidateUser()
        {
            if (this.CurrentUser.Number == -1)
            {
                Console.WriteLine("You are not logged in");
                return false;
            }
            else
                return true;
        }
        private void EditUser()
        {
            if (!ValidateUser())
            {
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.Write(
                "1: Edit name \n" +
                "2: Edit number \n");

            switch(GetInput())
            {
                case "1":
                    Console.WriteLine("Write your new name:");
                    this.CurrentUser.Edit(GetInput());
                    Console.WriteLine("Success! Your name is updated to {0}", CurrentUser.Name);
                    Console.WriteLine("press any key to exit");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Write your new number:");
                    try
                    {
                        this.CurrentUser.Edit(int.Parse(GetInput() ));
                        Console.WriteLine("Success! Your number is updated to {0}", CurrentUser.Number);
                        Console.WriteLine("press any key to exit");
                        Console.ReadKey();
                    }
                    catch
                    {
                        Console.WriteLine("Not a number!");
                        Console.ReadKey();
                        return;
                    }
                    break;
            }

            //Console.WriteLine("Enter user details");
            
            
            Console.WriteLine(this.CurrentUser.ToString());
            Console.ReadKey();
        }
        private void CheckIn()
        {
            if (!ValidateUser())
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Welcome, {CurrentUser.Name}! Please add your shift note:");
            string input = GetInput();

            this.workShiftManager.Add(new WorkShift(CurrentUser, input));
            Console.WriteLine(workShiftManager.workShifts.Last().ToString());
            Console.ReadKey();
        }
        private void CheckOut()
        {
            if (!ValidateUser())
            {
                Console.ReadKey();
                return;
            }
            //find shift
            //search for username + last shift checked in
            List<WorkShift> tempList = this.workShiftManager.workShifts;
            //get shiftlist
            for (int i = tempList.Count() - 1; i >= 0; i--)
            {
                if((tempList[i].User.Name == CurrentUser.Name) && (!tempList[i].CheckOutTime.HasValue))
                {
                    tempList[i].CheckOut();
                    Console.WriteLine("{0}, you check out at {1}!", tempList[i].User.Name, tempList[i].CheckOutTime);
                    return;
                }
            }
            Console.WriteLine("No shift found!");
        }
        private void ListWorkshifts()
        {
            Console.WriteLine("Input Password");
            if (GetInput() != "1234")
            {
                Console.WriteLine("Wrong password!");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            workShiftManager.PrintAll();
            //Console.ReadKey();
            Console.ReadLine();
        }
        private void EditWorkShift ()
        {
            //password protection
            Console.WriteLine("Input Password");
            if (GetInput() != "1234")
            {
                Console.WriteLine("Wrong password!");
                Console.ReadKey();
                return;
            }

            //get workshift by searching
            Console.WriteLine("Enter a search term");
            List<WorkShift> editList = this.workShiftManager.Search(GetInput());
            Console.Clear();
            int i = 0;
            //print found list
            foreach (WorkShift item in editList)
            {
                Console.WriteLine(
                    $"{i}. \n" +
                    $"{item}"
                    );
                i++;
            }

            Console.WriteLine("Choose the shift to edit:");
            
            //parse input
            int itemNum;
            try
            {
                itemNum = int.Parse(GetInput());
                if (itemNum <= 0 || itemNum > editList.Count())
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Not a valid number!");
                return;
            }

            //edit note
            Console.Clear();
            Console.WriteLine($"Old note: {editList[itemNum - 1].Note}");
            Console.WriteLine("Write your new note:");
            editList[itemNum].Edit(GetInput());

            //confirm edit
            Console.Clear();
            Console.WriteLine("Note updated!");
            Console.WriteLine(editList[itemNum].ToString());
            Console.ReadKey();
        }
        private void ListActiveUsers()
        {
            // password protected
            Console.WriteLine("Input Password");
            if (GetInput() != "1234")
            {
                Console.WriteLine("Wrong password!");
                Console.ReadKey();
                return;
            }

            //find all users who are checked in but not checked out
            for (int i = this.workShiftManager.workShifts.Count() - 1; i >= 0; i--)
            {
                if (!this.workShiftManager.workShifts[i].CheckOutTime.HasValue)
                    Console.WriteLine(this.workShiftManager.workShifts[i].User.Name);
            }
            Console.ReadLine();
        }
        private void SearchActiveUsers()
        {
            //search for user by name
            //active user for this purpose = use who checked in but not out
            //search only for users, who have already arrived => already checked in
            //  => search in current workshifts!

            // password protected
            Console.WriteLine("Input Password");
            if (GetInput() != "1234"){
                Console.WriteLine("Wrong password!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter search term");
            string searchTerm = GetInput();
            //find all users who are checked in but not checked out
            for (int i = this.workShiftManager.workShifts.Count() - 1; i >= 0; i--)
            {
                if ((this.workShiftManager.workShifts[i].User.ToString().Contains(searchTerm)) && (!this.workShiftManager.workShifts[i].CheckOutTime.HasValue))
                    Console.WriteLine(this.workShiftManager.workShifts[i].User.Name);
            }

        }

        
        private static string GetInput()
        {
            ClearLine();
            return Console.ReadLine();
        }
        private static void ClearLine() 
        {
            Console.WriteLine(new String(' ', MenuWidth));
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        }
    }
}
