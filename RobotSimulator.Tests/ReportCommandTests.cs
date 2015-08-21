using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotSimulator;
using RobotSimulator.Enums;

namespace RobotSimulator.Tests
{
    [TestClass]
    public class ReportCommandTests
    {
        /// <summary>
        /// Report after placing Robot on table
        /// </summary>
        [TestMethod]
        public void Report_After_Placing_On_Table()
        {
            var robotInstructions = new RobotInstructions();

            var placeResult = robotInstructions.Place(0, 0, FacingDirection.North);
            Assert.AreEqual(placeResult, true);

            var reportResult = robotInstructions.Report();
            Assert.AreEqual("0,0,NORTH", reportResult);
        }

        /// <summary>
        /// Report before placing Robot on table
        /// </summary>
        [TestMethod]
        public void Report_Before_Placing_On_Table()
        {
            var robotInstructions = new RobotInstructions();

            var reportResult = robotInstructions.Report();
            Assert.AreEqual("Can not generate the report!! Robot is not placed on the table.", reportResult);
        }

        /// <summary>
        /// Report after placing Robot on table and them moving it
        /// </summary>
        [TestMethod]
        public void Report_After_Placing_On_Table_After_Moving()
        {
            var robotInstructions = new RobotInstructions();

            var placeResult = robotInstructions.Place(0, 0, FacingDirection.North);
            Assert.AreEqual(placeResult, true);

            var moveResult = robotInstructions.Move();
            Assert.AreEqual(moveResult, true);

            var reportResult = robotInstructions.Report();
            Assert.AreEqual("0,1,NORTH", reportResult);
        }

        /// <summary>
        /// Report after placing Robot on table and then rotating it
        /// </summary>
        [TestMethod]
        public void Report_After_Placing_On_Table_After_Rotating()
        {
            var robotInstructions = new RobotInstructions();

            var placeResult = robotInstructions.Place(0, 0, FacingDirection.North);
            Assert.AreEqual(placeResult, true);

            var leftRotateResult = robotInstructions.Left();
            Assert.AreEqual(leftRotateResult, true);

            var reportResult = robotInstructions.Report();
            Assert.AreEqual("0,0,WEST", reportResult);
        }

        /// <summary>
        /// Report after placing Robot on table and then rotating and moving it
        /// </summary>
        [TestMethod]
        public void Report_After_Placing_On_Table_After_Rotating_And_Moving()
        {
            var robotInstructions = new RobotInstructions();

            var placeResult = robotInstructions.Place(0, 0, FacingDirection.North);
            Assert.AreEqual(placeResult, true);

            var rightRotateResult = robotInstructions.Right();
            Assert.AreEqual(rightRotateResult, true);

            var moveResult = robotInstructions.Move();
            Assert.AreEqual(moveResult, true);

            var reportResult = robotInstructions.Report();
            Assert.AreEqual("1,0,EAST", reportResult);
        }

        /// <summary>
        /// Report after placing Robot on table and then moving and rotating it
        /// </summary>
        [TestMethod]
        public void Report_After_Placing_On_Table_After_Moving_And_Rotating()
        {
            var robotInstructions = new RobotInstructions();

            var placeResult = robotInstructions.Place(0, 0, FacingDirection.North);
            Assert.AreEqual(placeResult, true);
            
            var moveResult = robotInstructions.Move();
            Assert.AreEqual(moveResult, true);

            var rightRotateResult = robotInstructions.Right();
            Assert.AreEqual(rightRotateResult, true);

            var reportResult = robotInstructions.Report();
            Assert.AreEqual("0,1,EAST", reportResult);
        }
    }
}
