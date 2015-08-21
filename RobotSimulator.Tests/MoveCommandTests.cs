using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotSimulator;
using RobotSimulator.Enums;

namespace RobotSimulator.Tests
{
    [TestClass]
    public class MoveCommandTests
    {
        /// <summary>
        /// Move Robot after placing on table
        /// </summary>
        [TestMethod]
        public void Move_Robot_After_Placing_On_Table()
        {
            var robotInstructions = new RobotInstructions();

            var placeResult = robotInstructions.Place(0, 0, FacingDirection.North);
            Assert.AreEqual(placeResult, true);

            var moveResult = robotInstructions.Move();
            Assert.AreEqual(moveResult, true);

        }

        /// <summary>
        /// Move Robot before placing on table
        /// </summary>
        [TestMethod]
        public void Move_Robot_Before_Placing_On_Table()
        {
            var robotInstructions = new RobotInstructions();

            var moveResult = robotInstructions.Move();
            Assert.AreEqual(moveResult, false);
            Assert.AreEqual("Robot can not move!! Robot is not placed on the table.", robotInstructions._error);
        }

        /// <summary>
        /// Move Robot out of table boundary after placing on table
        /// </summary>
        [TestMethod]
        public void Move_Robot_After_Placing_On_Table_But_Out_Of_Table_Boundary()
        {
            var robotInstructions = new RobotInstructions();

            var placeResult = robotInstructions.Place(0, 0, FacingDirection.South);
            Assert.AreEqual(placeResult, true);

            var moveResult = robotInstructions.Move();
            Assert.AreEqual("Can not Move the Robot out of the table boundary.", robotInstructions._error);

        }
    }
}
