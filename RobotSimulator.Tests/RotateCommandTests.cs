using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotSimulator;
using RobotSimulator.Enums;

namespace RobotSimulator.Tests
{
    [TestClass]
    public class RotateCommandTests
    {
        /// <summary>
        /// Rotate Robot after placing on table
        /// </summary>
        [TestMethod]
        public void Rotate_Robot_After_Placing_On_Table()
        {
            var robotInstructions = new RobotInstructions();

            var placeResult = robotInstructions.Place(0, 0, FacingDirection.North);
            Assert.AreEqual(placeResult, true);

            var moveResult = robotInstructions.Left();
            Assert.AreEqual(moveResult, true);

            var moveResult2 = robotInstructions.Right();
            Assert.AreEqual(moveResult2, true);

        }

        /// <summary>
        /// Rotate Robot before placing on table
        /// </summary>
        [TestMethod]
        public void Rotate_Robot_Before_Placing_On_Table()
        {
            var robotInstructions = new RobotInstructions();
            
            var moveResult = robotInstructions.Left();
            Assert.AreEqual(moveResult, false);
            Assert.AreEqual("Robot can not rotate Left!! Robot is not placed on the table.", RobotStatus._error);

            var moveResult2 = robotInstructions.Right();
            Assert.AreEqual(moveResult2, false);
            Assert.AreEqual("Robot can not rotate Right!! Robot is not placed on the table.", RobotStatus._error);

        }
    }
}
