using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoApp;
using Moq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace UnitTests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void CreateValidSample()
        {
            
            Mock<IRepository> _repo = new Mock<IRepository>();
            Controller controller = new((Repository)_repo.Object);
            _repo.Setup(t => t.AddNewSample(It.IsAny<Sample>())).Returns(true);
            List<String> sampleInfo = new List<string> { "1", "Valid sample", "TestRock", "GoodRock", "10", "UWO", "Oshkosh",
                                                          "WI", "USA", "10.2", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.AreEqual(controller.CreateNewSample(sampleInfo, image).GetType(), typeof(Sample));
        }
    }
}
