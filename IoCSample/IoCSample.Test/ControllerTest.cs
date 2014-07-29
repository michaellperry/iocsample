using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoCSample.Services;
using IoCSample.Framework;

namespace IoCSample.Test
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void PostCallsService()
        {
            DatabaseConnection connection = new DatabaseConnection("connectionstring");
            SignUpController controller = new SignUpController(new SignUpService(connection));
            controller.Post(new SignUpForm
            {
                Email = "email@me.com",
                Password = "secret"
            });
        }
    }
}
