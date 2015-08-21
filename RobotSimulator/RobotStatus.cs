using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotSimulator.Enums;

namespace RobotSimulator
{
    public static class RobotStatus
    {
        
        private const int TABLESIZE = 5;
        public static string _error = "";

        /// <summary>
        /// Gets the new value of x
        /// </summary>
        /// <param name="facingDirection"></param>
        /// <param name="x"></param>
        /// <returns>x</returns>
        public static int GetUpdatedX(FacingDirection facingDirection, int? x)
        {
            if (facingDirection == FacingDirection.East)
            {
                return x.Value + 1;
            }
            else
            {
                if (facingDirection == FacingDirection.West)
                {
                    return x.Value - 1;
                }
            }
            return x.Value;
        }

        /// <summary>
        /// Gets the new value of x
        /// </summary>
        /// <param name="facingDirection"></param>
        /// <param name="y"></param>
        /// <returns>y</returns>
        public static int GetUpdatedY(FacingDirection facingDirection, int? y)
        {
            if (facingDirection == FacingDirection.North)
            {
                return y.Value + 1;
            }
            else
            {
                if (facingDirection == FacingDirection.South)
                {
                    return y.Value - 1;
                }
            }
            return y.Value;
        }

        /// <summary>
        /// Gets the new facing direction
        /// </summary>
        /// <param name="RotateDirection"></param>
        /// <param name="facingDirection"></param>
        /// <returns></returns>
        public static FacingDirection GetFacingDirection(RotateDirection RotateDirection, FacingDirection facingDirection)
        {
            if (RotateDirection == RotateDirection.Left)
            {
                if (facingDirection == FacingDirection.East)
                    facingDirection = FacingDirection.North;
                else if (facingDirection == FacingDirection.North)
                    facingDirection = FacingDirection.West;
                else if (facingDirection == FacingDirection.West)
                    facingDirection = FacingDirection.South;
                else if (facingDirection == FacingDirection.South)
                    facingDirection = FacingDirection.East;
            }
            else if (RotateDirection == RotateDirection.Right)
            {
                if (facingDirection == FacingDirection.East)
                    facingDirection = FacingDirection.South;
                else if (facingDirection == FacingDirection.North)
                    facingDirection = FacingDirection.East;
                else if (facingDirection == FacingDirection.West)
                    facingDirection = FacingDirection.North;
                else if (facingDirection == FacingDirection.South)
                    facingDirection = FacingDirection.West;
            }
            return facingDirection;

        }

        /// <summary>
        /// Checks if the Robot is placed on table
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="action"></param>
        /// <returns>bool</returns>
        public static bool IsPlacedOnTable(int? x, int? y, Instruction action)
        {
            if (!x.HasValue || !y.HasValue)
            {
                string instructionaction = action.ToString();
                if (action == Instruction.Left || action == Instruction.Right)
                _error = String.Format("Robot can not rotate {0}!! Robot is not placed on the table.", instructionaction);
                if (action == Instruction.Report)
                    _error = "Can not generate the report!! Robot is not placed on the table.";
                if (action == Instruction.Move)
                    _error = "Robot can not move!! Robot is not placed on the table.";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the Robot position is inside the table
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="action"></param>
        /// <returns>bool</returns>
        public static bool IsOnTable(int x, int y, Instruction action)
        {
            if (x < 0 || y < 0 || x > TABLESIZE || y > TABLESIZE)
            {
                _error = String.Format("Can not {0} the Robot out of the table boundary.", action.ToString());
                return false;
            }
            return true;
        }
    }
}
