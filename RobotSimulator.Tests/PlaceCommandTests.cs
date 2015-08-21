using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotSimulator;
using RobotSimulator.Enums;

namespace RobotSimulator.Tests
{
    [TestClass]
    public class PlaceCommandTests
    {
        /// <summary>
        /// Place Robot inside table boundary
        /// </summary>
        [TestMethod]
        public void Place_Robot_InsideTableBoundary()
        {
            var robotInstructions = new RobotInstructions();

            var result = robotInstructions.Place(0, 0, FacingDirection.North);
            Assert.AreEqual(result,true);
                    
            var result2 = robotInstructions.Place(5, 5, FacingDirection.North);
            Assert.AreEqual(result2, true);
        }

        /// <summary>
        /// Place Robot outside table boundary
        /// </summary>
        [TestMethod]
        public void Place_Robot_OutsideTableBoundary()
        {
            var robotInstructions = new RobotInstructions();

            var result = robotInstructions.Place(0, -1, FacingDirection.North);
            Assert.AreEqual(result,false);
            Assert.AreEqual("Can not Place the Robot out of the table boundary.", RobotStatus._error);

            var result2 = robotInstructions.Place(6, 0, FacingDirection.North);
            Assert.AreEqual(result2, false);
            Assert.AreEqual("Can not Place the Robot out of the table boundary.", RobotStatus._error);
        }
    }
}
