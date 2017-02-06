using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieDb.Controllers;
using MovieDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDb.Controllers.Tests
{
    [TestClass()]
    public class ManageControllerTests
    {
        [TestMethod()]
        public void HasPhoneNumberLogicTest()
        {
            ApplicationUser user = new ApplicationUser();
            user.PhoneNumber = "phone_number";
            ManageController cont = new ManageController();
            bool result = cont.HasPhoneNumberLogic(user);
            Assert.IsTrue(result, "Result is not as expected. Result is: " + result);
        }

        [TestMethod()]
        public void HasPhoneNumberLogicNegativeTest()
        {
            ApplicationUser user = new ApplicationUser();
            user.PhoneNumber = null;
            ManageController cont = new ManageController();
            bool result = cont.HasPhoneNumberLogic(user);
            Assert.IsFalse(result, "Result is not as expected. Result is: " + result);
        }

        [TestMethod()]
        public void HasPasswordLogicTest()
        {
            ApplicationUser user = new ApplicationUser();
            user.PasswordHash = "password_hash";
            ManageController cont = new ManageController();
            bool result = cont.HasPasswordLogic(user);
            Assert.IsTrue(result, "Result is not as expected. Result is: " + result);
        }

        [TestMethod()]
        public void HasPasswordLogicNegativeTest()
        {
            ApplicationUser user = new ApplicationUser();
            user.PasswordHash = null;
            ManageController cont = new ManageController();
            bool result = cont.HasPasswordLogic(user);
            Assert.IsFalse(result, "Result is not as expected. Result is: " + result);
        }
    }
}