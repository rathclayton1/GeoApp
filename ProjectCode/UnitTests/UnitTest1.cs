using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoApp;
using Moq;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddValidSample()
        {
            MySqlConnection _conn = new MySqlConnection("HELLO");
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(t => t.AddNewSample(It.IsAny<Sample>())).Returns(true);
            Repository _repo = new(_conn);
            Controller _controller = new(_repo);
            List<String> sampleInfo = new List<string> { "1", "Valid sample", "TestRock", "GoodRock", "10", "UWO", "Oshkosh",
                                                         "WI", "USA", "10.2", "11.1",  };
            Byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            //_controller.CreateNewSample(sampleInfo,image);
            Assert.IsInstanceOfType(_controller.CreateNewSample(sampleInfo, image), typeof(Sample));
            //System.Diagnostics.Debug.WriteLine(_controller.CreateNewSample(sampleInfo, image).GetType()/*, typeof(Sample)*/);
        }
    }
}
