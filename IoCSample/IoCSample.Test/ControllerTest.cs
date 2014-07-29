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
            FakeSignUpService signUpService = new FakeSignUpService();
            SignUpController controller = new SignUpController(signUpService);

            controller.Post(new SignUpForm
            {
                Email = "email@me.com",
                Password = "secret"
            });

            signUpService.VerifyWasCalled("email@me.com", "secret");
        }
    }
}
