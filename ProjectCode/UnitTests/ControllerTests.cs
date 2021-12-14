using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoApp;
using Moq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace UnitTests
{
    /// <summary>
    /// Class to test every method in Controller.cs
    /// 
    /// Author: Clayton Rath
    /// </summary>
    [TestClass]
    public class ControllerTests
    {
        Mock<IRepository> _repo;
        Controller _controller;

        /// <summary>
        /// Constructor for test class. Creates a Mock Repository, and mocks the methods so the controller
        /// methods that call the Repository will work, even without an actual database being used.
        /// </summary>
        public ControllerTests()
        {
            _repo = new Mock<IRepository>();
            _controller = new(_repo.Object);
            _repo.Setup(t => t.AddNewSample(It.IsAny<Sample>())).Returns(true);
            _repo.Setup(t => t.RetrieveSampleByFields(It.IsAny<Sample>())).Returns(new Sample());
            _repo.Setup(t => t.RetrieveAllSamples()).Returns(new List<Sample>());
            _repo.Setup(t => t.EditSampleById(It.IsAny<Sample>())).Returns(true);
            _repo.Setup(t => t.DeleteSampleById(It.IsAny<int>())).Returns(true);
            _repo.Setup(t => t.RetrieveAllIssues()).Returns(new List<Issue>());
            _repo.Setup(t => t.CreateIssue(It.IsAny<Issue>())).Returns(true);
            _repo.Setup(t => t.DeleteIssueById(It.IsAny<int>())).Returns(true);
        }
        /// <summary>
        /// Test adding a valid sample
        /// </summary>
        [TestMethod]
        public void CreateValidSample()
        {
            List<String> sampleInfo = new List<String> { "1", "Valid sample", "TestRock", "FirstAge", "Here", "Oshkosh",
                                                          "WI", "USA", "10.2", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.AreEqual(_controller.CreateNewSample(sampleInfo, image).GetType(), typeof(Sample));
        }
        /// <summary>
        /// Test adding a sample with an invalid ID
        /// </summary>
        [TestMethod]
        public void AddInvalidID()
        {
            List<String> sampleInfo = new List<String> { "notAnInt", "Invalid sample ID", "TestRock", "FirstAge", "Here", "Oshkosh",
                                                          "WI", "USA", "10.2", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsNull(_controller.CreateNewSample(sampleInfo, image));
        }
        /// <summary>
         /// Test adding a sample with an invalid name
         /// </summary>
        [TestMethod]
        public void AddInvalidName()
        {
            List<String> sampleInfo = new List<String> { "1", "Invalid nameEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE", 
                                                               "TestRock", "FirstAge", "Here", "Oshkosh",
                                                               "WI", "USA", "10.2", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsNull(_controller.CreateNewSample(sampleInfo, image));
        }
        /// <summary>
        /// Test adding a sample with an invalid location description
        /// </summary>
        [TestMethod]
        public void AddInvalidLocationDescription()
        {
            List<String> sampleInfo = new List<String> { "1", "Sample Name", "TestRock", "FirstAge", 
                                                               "Invalid locationEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE", 
                                                               "Oshkosh", "WI", "USA", "10.2", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsNull(_controller.CreateNewSample(sampleInfo, image));
        }
        /// <summary>
        /// Test adding a sample with an invalid city
        /// </summary>
        [TestMethod]
        public void AddInvalidCity()
        {
            List<String> sampleInfo = new List<String> { "1", "Sample Name", "TestRock", "FirstAge", "Here",
                                                               "Invalid cityyyEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE",
                                                               "WI", "USA", "10.2", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsNull(_controller.CreateNewSample(sampleInfo, image));
        }
        /// <summary>
        /// Test adding a sample with an invalid latitude
        /// </summary>
        [TestMethod]
        public void AddInvalidLatitude()
        {
            List<String> sampleInfo = new List<String> { "1", "Sample Name", "TestRock", "FirstAge", "Here", "Oshkosh",
                                                          "WI", "USA", "notADouble", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsNull(_controller.CreateNewSample(sampleInfo, image));
        }
        /// <summary>
        /// Test adding a sample with an invalid longitude
        /// </summary>
        [TestMethod]
        public void AddInvalidLongitude()
        {
            List<String> sampleInfo = new List<String> { "1", "Sample Name", "TestRock", "FirstAge", "Here", "Oshkosh",
                                                          "WI", "USA", "10.2", "alsoNotADouble"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsNull(_controller.CreateNewSample(sampleInfo, image));
        }
        /// <summary>
        /// Test retrieve samples by a certain keyword
        /// </summary>
        [TestMethod]
        public void TestGetSamplesByKeyword()
        {
            string keyword = "searchTerm";
            Assert.AreEqual(_controller.GetSamplesByKeyword(keyword).GetType(), typeof(List<Sample>));
        }
        /// <summary>
        /// Test updating a sample with valid input
        /// </summary>
        [TestMethod]
        public void UpdateValidSample()
        {
            List<String> sampleInfo = new List<String> { "1", "1", "Valid sample", "TestRock", "FirstAge", "Here", "Oshkosh",
                                                          "WI", "USA", "10.2", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsTrue(_controller.UpdateSample(sampleInfo, image));
        }
        /// <summary>
        /// Test updating a sample with an invalid ID
        /// </summary>
        [TestMethod]
        public void UpdateWrongSampleID()
        {
            List<String> sampleInfo = new List<String> { "notAnInt", "notAnInt", "Invalid sample ID", "TestRock", "FirstAge", "Here", "Oshkosh",
                                                          "WI", "USA", "10.2", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsFalse(_controller.UpdateSample(sampleInfo, image));
        }
        /// <summary>
        /// Test updating a sample with an invalid name
        /// </summary>
        [TestMethod]
        public void UpdateWrongSampleName()
        {
            List<String> sampleInfo = new List<String> { "1", "1", "Invalid nameEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE",
                                                               "TestRock", "FirstAge", "Here", "Oshkosh",
                                                               "WI", "USA", "10.2", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsFalse(_controller.UpdateSample(sampleInfo, image));
        }
        /// <summary>
        /// Test updating a sample with an invalid location description
        /// </summary>
        [TestMethod]
        public void UpdateInvalidLocationDescription()
        {
            List<String> sampleInfo = new List<String> { "1", "1", "Sample Name", "TestRock", "FirstAge",
                                                               "Invalid locationEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE",
                                                               "Oshkosh", "WI", "USA", "10.2", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsFalse(_controller.UpdateSample(sampleInfo, image));
        }
        /// <summary>
        /// Test updating a sample with an invalid state
        /// </summary>
        [TestMethod]
        public void UpdateInvalidState()
        {
            List<String> sampleInfo = new List<String> { "1", "1", "Sample Name", "TestRock", "FirstAge", "Here", "Oshkosh",
                                                               "Invalid cityyyEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                               "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE",
                                                               "USA", "10.2", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsFalse(_controller.UpdateSample(sampleInfo, image));
        }
        /// <summary>
        /// Test updating a sample with an invalid latitude
        /// </summary>
        [TestMethod]
        public void UpdateInvalidLatitude()
        {
            List<String> sampleInfo = new List<String> { "1", "1", "Sample Name", "TestRock", "FirstAge", "Here", "Oshkosh",
                                                          "WI", "USA", "notADouble", "11.1"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsFalse(_controller.UpdateSample(sampleInfo, image));
        }
        /// <summary>
        /// Test updating a sample with an invalid longitiude
        /// </summary>
        [TestMethod]
        public void UpdateInvalidLongitude()
        {
            List<String> sampleInfo = new List<String> { "1", "1", "Sample Name", "TestRock", "FirstAge", "Here", "Oshkosh",
                                                          "WI", "USA", "10.2", "alsoNotADouble"};
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            Assert.IsFalse(_controller.UpdateSample(sampleInfo, image));
        }
        /// <summary>
        /// Test deleting an existing sample from the database
        /// </summary>
        [TestMethod]
        public void TestDeleteSample()
        {
            Sample sample = new Sample()
            {
                SampleId = 1,
                Name = "Valid sample",
                SampleType = "TestRock",
                GeologicAge = "GoodRock",
                LocationDescription = "The ground",
                City = "Oshkosh",
                State = "Wisconsin",
                Country = "US",
                Latitude = 4,
                Longitude = 3,
                Image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
            };
            Assert.IsTrue(_controller.DeleteSample(sample));
        }
        /// <summary>
        /// Test retrieving all issues
        /// </summary>
        [TestMethod]
        public void TestGetAllIssues()
        {
            Assert.AreEqual(_controller.GetAllIssues().GetType(), typeof(List<Issue>));
        }
        /// <summary>
        /// Test creating a valid issue
        /// </summary>
        [TestMethod]
        public void CreateValidIssue()
        {
            List<String> issue = new List<string> { "0", "Valid issue" };
            Assert.IsTrue(_controller.CreateIssue(issue));
        }
        /// <summary>
        /// Test creating an invalid issue
        /// </summary>
        [TestMethod]
        public void CreateInvalidIssueDescription()
        {
            List<String> issue = new List<string> { "0", "INVALID issueEUEUEUEUEUEUEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
                                                    "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" };
            Assert.IsFalse(_controller.CreateIssue(issue));
        }
        /// <summary>
        /// Test deleting an existing issue from the database
        /// </summary>
        [TestMethod]
        public void TestDeleteIssue()
        {
            Issue issue = new Issue() {referenceId=0, Type=Issue.IssueType.Misinformation, IssueDescription="I am about to be deleted" };
            Assert.IsTrue(_controller.DeleteIssue(issue));
        }
    }
}
