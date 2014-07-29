using IoCSample.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCSample.Test
{
    public class FakeSignUpService : ISignUpService
    {
        private bool _signedUp;
        private string _email;
        private string _password;

        public bool SignUp(string email, string password)
        {
            _signedUp = true;
            _email = email;
            _password = password;

            return true;
        }

        public void VerifyWasCalled(string expectedEmail, string expectedPassword)
        {
            Assert.IsTrue(_signedUp, "SignUp was not called");
            Assert.AreEqual(expectedEmail, _email);
            Assert.AreEqual(expectedPassword, _password);
        }
    }
}
