using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoApp;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUnitTests
{
    [TestClass]
    public class ControllerTests
    {

        [TestMethod]
        public void Get_Valid_Sample_By_Id_Sample()
        {
            MySqlConnection _conn = new MySqlConnection("HELLO");
            Repository _repo = new Repository(_conn);
            var controller = new Controller(_repo);
            int id = 1;
            Sample sample = new Sample();
            Assert.AreEqual(sample, controller.GetSampleById(id));
        }

        [TestMethod]
        public void Get_Invalid_Sample_By_Id_Throws()
        {
            MySqlConnection _conn = new MySqlConnection("HELLO");
            Repository _repo = new Repository(_conn);
            var controller = new Controller(_repo);
            int id = -1;
            Assert.ThrowsException<System.ArgumentException>(() => controller.GetSampleById(id));
        }

        [TestMethod]
        public void Create_New_Valid_Sample_True()
        {
            MySqlConnection _conn = new MySqlConnection("HELLO");
            Repository _repo = new Repository(_conn);
            var controller = new Controller(_repo);
            List<String> sampleInfo = new List<string> { "1", "Valid sample", "TestRock", "GoodRock", "10", "UWO", "Oshkosh", 
                                                         "WI", "USA", "10.2", "11.1",  };
            Assert.IsTrue(controller.CreateNewSample(sampleInfo));
        }

        [TestMethod]
        public void Create_New_Invalid_Sample_False()
        {
            MySqlConnection _conn = new MySqlConnection("HELLO");
            Repository _repo = new Repository(_conn);
            var controller = new Controller(_repo);
            List<String> sampleInfo = new List<string> { "1", "INVALID sampleEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE", 
                                                         "TestRock", "GoodRock", "10", "UWO", "Oshkosh", "WI", "USA", "10.2", "11.1",  };
            Assert.IsFalse(controller.CreateNewSample(sampleInfo));
        }

        [TestMethod]
        public void Delete_Valid_Sample_True()
        {
            MySqlConnection _conn = new MySqlConnection("HELLO");
            Repository _repo = new Repository(_conn);
            var controller = new Controller(_repo);
            Sample validSampleInfo = new Sample();
            Assert.IsTrue(controller.DeleteSample(validSampleInfo));
        }

        [TestMethod]
        public void Delete_Invalid_Sample_False()
        {
            MySqlConnection _conn = new MySqlConnection("HELLO");
            Repository _repo = new Repository(_conn);
            var controller = new Controller(_repo);
            Sample invalidSampleInfo = new Sample();
            Assert.IsFalse(controller.DeleteSample(invalidSampleInfo));
        }

        [TestMethod]
        public void Create_Valid_Issue_True()
        {
            MySqlConnection _conn = new MySqlConnection("HELLO");
            Repository _repo = new Repository(_conn);
            var controller = new Controller(_repo);
            List<String> issue = new List<string> { "0", "Valid issue" };
            Assert.IsTrue(controller.CreateIssue(issue));
        }

        [TestMethod]
        public void Create_Invalid_Issue_False()
        {
            MySqlConnection _conn = new MySqlConnection("HELLO");
            Repository _repo = new Repository(_conn);
            var controller = new Controller(_repo);
            List<String> issue = new List<string> { "0", "INVALID issueEUEUEUEUEUEUEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" };
            Assert.IsFalse(controller.CreateIssue(issue));
        }

        [TestMethod]
        public void Delete_Valid_Issue_True()
        {
            MySqlConnection _conn = new MySqlConnection("HELLO");
            Repository _repo = new Repository(_conn);
            var controller = new Controller(_repo);
            Issue issue = new Issue();
            Assert.IsTrue(controller.DeleteIssue(issue));
        }

        [TestMethod]
        public void Delete_Invalid_Issue_False()
        {
            MySqlConnection _conn = new MySqlConnection("HELLO");
            Repository _repo = new Repository(_conn);
            var controller = new Controller(_repo);
            Issue issue = new Issue();
            Assert.IsFalse(controller.DeleteIssue(issue));
        }
    }
}