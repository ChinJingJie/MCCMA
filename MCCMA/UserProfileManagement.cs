using System;
namespace MCCMA
{
    public class UserProfileManagement
    {
        /// <summary>
        /// _name, _dob, _phoneno are private field variable
        /// mylogin and menu are to link methods from the other class
        /// </summary>
        public static Login  mylogin = new Login();
        public static MainMenu menu = new MainMenu();
        public static int count = 0;
        private string _name;
        private string _dob;
        private int _phoneno;

        /// <summary>
        /// The constructor is set default where the values are empty
        /// </summary>
        public UserProfileManagement() : this("","", "", "", 0)
        {
        }

        /// <summary>
        /// The UserProfileManagemnt constructor pass the value of username and password, name, dob, mobile
        /// </summary>
        public UserProfileManagement(string username, string password, string name, string dob, int mobile)
        {
            mylogin.Username = username;
            mylogin.Password = password;
            _name = name;
            _dob = dob;
            _phoneno = mobile;
        }

        /// <summary>
        /// The property set private value of Name to public.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// The property set private value of DoB to public.
        /// </summary>
        public string DoB
        {
            get { return _dob; }
            set { _dob = value; }
        }

        /// <summary>
        /// The property set private value of PhoneNo to public.
        /// </summary>
        public int PhoneNo
        {
            get { return _phoneno; }
            set { _phoneno = value; }
        }

        /// <summary>
        /// The is a void method that prints the text that will popup when user choose to edit their login details.
        /// </summary>
        public void EditLogin()
        {
            Console.WriteLine("Please enter new Username and Password");
            Console.Write("New Username: ");
            mylogin.Username = Console.ReadLine();
            Console.Write("New Password: ");
            mylogin.Password = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Done. New accout details will be: ");
            Console.WriteLine("Username:{0}", mylogin.Username);
            Console.WriteLine("Password:{0}", mylogin.Password);
            Console.WriteLine("");
        }

        /// <summary>
        /// The is a void method that collect profile information from the user.
        /// </summary>
        public void ProfileInfo()
        {
            Console.Write("Enter Your Name: ");
            Name = Console.ReadLine();
            Console.Write("Enter Your Date of Birth: ");
            DoB = Console.ReadLine();
            Console.Write("Enter Your Phone Number: ");
            PhoneNo = int.Parse(Console.ReadLine());
            Console.WriteLine("");
        }

        /// <summary>
        /// The is a void method that prints the profile information collected.
        /// </summary>
        public void PrintProfileInfo()
        {
            Console.WriteLine("My Profile Details");
            Console.WriteLine("--------------------------");
            Console.WriteLine("UserName: " + mylogin.Username);
            Console.WriteLine("Password: " + mylogin.Password);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Date of Birth: " + DoB);
            Console.WriteLine("Phone Number: " + PhoneNo);
            Console.WriteLine("--------------------------");
            Console.WriteLine("");
        }

        /// <summary>
        /// The is a void method that navigates user from user profile management modules to its functions.
        /// </summary>
        public void ProfileNav()
        {
            Console.WriteLine("Welcome, " + mylogin.Username);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("|*     User Profile Management    *|");
            Console.WriteLine("|* Please select a function below *|");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("|*   1.Add Profile Information    *|");
            Console.WriteLine("|*   2.Edit Profile Information   *|");
            Console.WriteLine("|*   3.Edit Login Details         *|");
            Console.WriteLine("|*   4.Back to Main Menu          *|");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("");
            Console.Write("Function Number: ");
            string profilefunc = Console.ReadLine();
            Console.WriteLine("");

            if (profilefunc == "1")
            {
                ProfileInfo();
                count = 1;
                Console.WriteLine("");
                PrintProfileInfo();
                ProfileNav();
            }
            else if (profilefunc == "2")
            {
                if(count == 0)
                {
                    Console.WriteLine("Please create a profile first!");
                    ProfileNav();
                }
                else
                {
                    ProfileInfo();
                    count = 1;
                    Console.WriteLine("");
                    PrintProfileInfo();
                    ProfileNav();
                }
            }
            else if (profilefunc == "3")
            {
                EditLogin();
                ProfileNav();
            }
            else if (profilefunc == "4")
            {
                Console.WriteLine(menu.Menu());
            }
            else
            {
                Console.WriteLine("Please enter valid function number.");
                ProfileNav();
            }

        }
    }
}
