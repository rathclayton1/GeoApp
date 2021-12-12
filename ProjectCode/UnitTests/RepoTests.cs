using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoApp;
using Moq;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace UnitTests
{
    [TestClass]
    public class RepoTests
    {
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
        [TestMethod]
        public void DeleteSampleById()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(t => t.DeleteSampleById(It.IsAny<int>())).Returns(true);
            Assert.IsTrue(mockRepo.Object.DeleteSampleById(1));
        }
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
        [TestMethod]
        public void DeleteIssueById()
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(t => t.DeleteIssueById(It.IsAny<int>())).Returns(true);
            Assert.IsTrue(mockRepo.Object.DeleteIssueById(1));
        }
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
