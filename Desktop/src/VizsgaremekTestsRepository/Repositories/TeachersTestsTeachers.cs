using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vizsgaremek.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.Repositories.Tests
{
    [TestClass()]
    public class TeachersTestsTeachers
    {
        [TestMethod()]
        public void TeachersTest()
        {
            Teachers teachers = new Teachers();
            Assert.AreEqual(6, teachers.AllTeachers.Count, "Konstruktor nem hoz létre hat teszt tanárt");
        }

        [TestMethod()]
        public void MakeTestDataTest()
        {
            Teachers teachers = new Teachers();
            Assert.AreEqual(6, teachers.AllTeachers.Count, "Konstruktor nem hoz létre hat teszt tanárt");
        }

        [TestMethod()]
        public void GetAllTeachersTest()
        {
            Assert.Fail();
        }
        /*
        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertTest()
        {
            Assert.Fail();
        }*/
    }
}