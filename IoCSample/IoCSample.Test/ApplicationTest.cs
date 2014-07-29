using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IoCSample.Test
{
    [TestClass]
    public class ApplicationTest
    {
        [TestMethod]
        public void CanInitialize()
        {
            Application application = new Application();
            application.Init();
        }
    }
}
