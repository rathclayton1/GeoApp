using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoApp;
using Moq;
using System.Collections.Generic;

namespace UnitTests
{
    /// <summary>
    /// Class to test every method in Repository.cs
    /// Using Moq to simulate a database
    /// 
    /// Author: Clayton Rath
    /// </summary>
    [TestClass]
    public class RepoTests
    {
        /// <summary>
        /// Test adding a valid sample
        /// </summary>
        [TestMethod]
        public void AddValidSample()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(t => t.AddNewSample(It.IsAny<Sample>())).Returns(true);
            Sample sample = new() {SampleId=1, Name="Valid sample", SampleType="TestRock", GeologicAge="GoodRock", 
                                   LocationDescription="The ground", City="Oshkosh", State="Wisconsin", Country="US", Latitude=4, Longitude=3, 
                                   Image=new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
            };
            Assert.IsTrue(mockRepo.Object.AddNewSample(sample));         
        }
        /// <summary>
        /// Test retrieving a sample
        /// </summary>
        [TestMethod]
        public void RetrieveSamplebyId()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(t => t.RetrieveSampleById(It.IsAny<int>())).Returns(new Sample()
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
            });
            Assert.AreEqual(mockRepo.Object.RetrieveSampleById(1).GetType(), typeof(Sample));
        }
        /// <summary>
        /// Test deleting a sample from the database
        /// </summary>
        [TestMethod]
        public void DeleteSampleById()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(t => t.DeleteSampleById(It.IsAny<int>())).Returns(true);
            Assert.IsTrue(mockRepo.Object.DeleteSampleById(1));
        }
        /// <summary>
        /// Test updating a sample correctly
        /// </summary>
        [TestMethod]
        public void EditSamplebyId()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(t => t.EditSampleById(It.IsAny<Sample>())).Returns(true);
            Assert.IsTrue(mockRepo.Object.EditSampleById(new Sample()
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
            }));
        }
        /// <summary>
        /// Test retrieving all samples from the database
        /// </summary>
        [TestMethod]
        public void RetrieveAllSamples()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(t => t.RetrieveAllSamples()).Returns(new List<Sample> {new Sample()
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
            },
            new Sample()
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
            } 
            });
            Assert.AreEqual(mockRepo.Object.RetrieveAllSamples().GetType(), typeof(List<Sample>));
        }
        /// <summary>
        /// Test adding a valid issue to the database
        /// </summary>
        [TestMethod]
        public void AddValidIssue()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(t => t.CreateIssue(It.IsAny<Issue>())).Returns(true);
            Issue issue = new()
            {
                IssueDescription = "This is an issue",
                Type = Issue.IssueType.SystemIssue,
                referenceId=2,
            };
            Assert.IsTrue(mockRepo.Object.CreateIssue(issue));
        }
        /// <summary>
        /// Test deleting an issue by ID
        /// </summary>
        [TestMethod]
        public void DeleteIssueById()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(t => t.DeleteIssueById(It.IsAny<int>())).Returns(true);
            Assert.IsTrue(mockRepo.Object.DeleteIssueById(1));
        }
        /// <summary>
        /// Test retrieving all issues
        /// </summary>
        public void RetrieveAllIssues()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(t => t.RetrieveAllIssues()).Returns(new List<Issue> {new Issue()
            {
                IssueDescription = "This is an issue",
                Type = Issue.IssueType.SystemIssue,
                referenceId=2,
            },
            new Issue()
            {
                IssueDescription = "This is also an issue",
                Type = Issue.IssueType.SystemIssue,
                referenceId=1,
            }
            });
            Assert.AreEqual(mockRepo.Object.RetrieveAllIssues().GetType(), typeof(List<Issue>));
        }
    }
}
