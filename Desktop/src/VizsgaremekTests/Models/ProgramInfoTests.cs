using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.Models.Tests
{
    [TestClass()]
    public class ProgramInfoTests
    {
        [TestMethod()]
        public void ProgramInfoTestVersion()
        {
            // arrange
            ProgramInfo programInfo = new ProgramInfo();
            Version expected = new Version(0, 0, 3, 0);

            // act
            Version actual = programInfo.Version;

            // assert
            Assert.AreEqual(expected, actual, "Version is not 0.0.3.0");
        }

        [TestMethod()]
        public void ProgramInfoTesTitle()
        {
            // arrange
            ProgramInfo programInfo = new ProgramInfo();
            Version expected = new Version(0, 0, 3, 0);

            // act
            String actual = programInfo.Title;

            // assert
            Assert.AreEqual(expected, actual, "Version is not 0.0.3.0");
        }

        [TestMethod()]
        public void ProgramInfoTestDescription()
        {
            // arrange
            ProgramInfo programInfo = new ProgramInfo();
            Version expected = new Version(0, 0, 3, 0);

            // act
            String actual = programInfo.Description;

            // assert
            Assert.AreEqual(expected, actual, "Version is not 0.0.3.0");
        }

        [TestMethod()]
        public void ProgramInfoTestCompany()
        {
            // arrange
            ProgramInfo programInfo = new ProgramInfo();
            Version expected = new Version(0, 0, 3, 0);

            // act
            String actual = programInfo.Company;

            // assert
            Assert.AreEqual(expected, actual, "Version is not 0.0.3.0");
        }



    }
}