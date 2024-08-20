using System;
namespace MCCMA
{
    public class Login
    {
        /// <summary>
        /// _username, _password are private field variable
        /// newprofile is to link method from the other class
        /// </summary>
        public static UserProfileManagement newprofile = new UserProfileManagement();
        private string _username;
        private string _password;

        /// <summary>
        /// The constructor is set default where the values are empty
        /// </summary>
        public Login() : this("", "")
        {
        }

        /// <summary>
        /// The Login constructor pass the value of username and password
        /// </summary>
        public Login(string username, string password)
        {
            _username = username;
            _password = password;
        }

        /// <summary>
        /// The property set private value of Username to public.
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// The property set private value of password to public.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// The is a void method that prints the text that will popup when user login for the first time.
        /// </summary>
        public void FirstLogin()
        {
            Console.WriteLine("Enter Your Username and Password");
            Console.Write("Username: ");
            string Username = Console.ReadLine();
            Console.Write("Password: ");
            string Password = Console.ReadLine();

            if (Username != "temp" | Password != "password")
            {
                Console.WriteLine("");
                Console.WriteLine("Wrong Username or Passsword Input");
                FirstLogin();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Successful");
                Console.WriteLine("");
                newprofile.EditLogin();
            }
        }

    }
}