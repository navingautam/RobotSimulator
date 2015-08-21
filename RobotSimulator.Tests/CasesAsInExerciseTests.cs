using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotSimulator;
using RobotSimulator.Enums;

namespace RobotSimulator.Tests
{
    [TestClass]
    public class CasesAsInExerciseTests
    {
        /// <summary>
        /// PLACE 0,0,NORTH
        /// MOVE
        /// REPORT
        /// </summary>
        [TestMethod]
        public void Move_Robot_After_Placing_On_Table_Report()
        {
            var robotInstructions = new RobotInstructions();

            var placeResult = robotInstructions.Place(0, 0, FacingDirection.North);
            Assert.AreEqual(placeResult, true);

            var moveResult = robotInstructions.Move();
            Assert.AreEqual(moveResult, true);

            var reportResult = robotInstructions.Report();
            Assert.AreEqual("0,1,NORTH",reportResult);
        }

        /// <summary>
        /// PLACE 0,0,NORTH
        /// LEFT
        /// REPORT
        /// </summary>
        [TestMethod]
        public void Rotate_Left_Robot_After_Placing_On_Table_Report()
        {
            var robotInstructions = new RobotInstructions();

            var placeResult = robotInstructions.Place(0, 0, FacingDirection.North);
            Assert.AreEqual(placeResult, true);

            var rotateResult = robotInstructions.Left();
            Assert.AreEqual(rotateResult, true);

            var reportResult = robotInstructions.Report();
            Assert.AreEqual("0,0,WEST", reportResult);
        }

        /// <summary>
        /// PLACE 1,2,EAST
        /// MOVE
        /// MOVE
        /// LEFT
        /// MOVE
        /// REPORT
        /// </summary>
        [TestMethod]
        public void Move_Move_Rotate_Left_Move_Robot_After_Placing_On_Table_Report()
        {
            var robotInstructions = new RobotInstructions();

            var placeResult = robotInstructions.Place(1,2, FacingDirection.East);
            Assert.AreEqual(placeResult, true);

            var moveResult1 = robotInstructions.Move();
            Assert.AreEqual(moveResult1, true);

            var moveResult2 = robotInstructions.Move();
            Assert.AreEqual(moveResult2, true);

            var rotateResult = robotInstructions.Left();
            Assert.AreEqual(rotateResult, true);

            var moveResult3 = robotInstructions.Move();
            Assert.AreEqual(moveResult3, true);

            var reportResult = robotInstructions.Report();
            Assert.AreEqual("3,3,NORTH", reportResult);
        }
    }
}
