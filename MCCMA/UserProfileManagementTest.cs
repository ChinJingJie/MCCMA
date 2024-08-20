using System;
using NUnit.Framework;

namespace MCCMA
{
    [TestFixture()]
    public class UserProfileManagementTest
    {
        [Test()]
        public void EditLoginDetailsTest()
        {
            Login login = new Login("temp", "password");

            Assert.AreEqual("temp", login.Username);

            login.Username = "newuser";

            Assert.AreEqual("newuser", login.Username);
        }

        [Test()]
        public void CreateProfileTest()
        {
            UserProfileManagement user = new UserProfileManagement("", "", "", "", 0);
            //use phone no to test whether the profile is crated or not
            Assert.AreEqual(0, user.PhoneNo);

            user = new UserProfileManagement("user", "key123", "Jimmy", "1/1/1999", 0112345678);
            Assert.AreEqual(0112345678, user.PhoneNo);
        }

        [Test()]
        public void EditProfileTest()
        {
            UserProfileManagement user = new UserProfileManagement("user", "key123", "Jimmy", "1/1/1999", 0112345678);
            Assert.AreEqual("Jimmy", user.Name);
            //change the name 
            user.Name = "Casy";
            Assert.AreEqual("Casy", user.Name);
        }
    }
}
