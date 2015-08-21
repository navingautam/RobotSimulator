using RobotSimulator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    public class RobotInstructions
    {

        public RobotInstructions()
        {
            _error = "";
        }

        public string _error { get; set; }
                
        private int? _x;
        private int? _y;
        private FacingDirection _facingDirection;

        /// <summary>
        /// Place the Robot on the table
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="facingDirection"></param>
        /// <returns>bool</returns>
        public bool Place(int x, int y, FacingDirection facingDirection)
        {
            if (RobotStatus.IsOnTable(x, y,Instruction.Place))
            {
                _x = x;
                _y = y;
                _facingDirection = facingDirection;
                return true;
            }
            else
            {
                _error = RobotStatus._error;
            }
            return false;
        }

        /// <summary>
        /// Move the Robot
        /// </summary>
        /// <returns>bool</returns>
        public bool Move()
        {
            if (RobotStatus.IsPlacedOnTable(_x, _y,Instruction.Move))
            {
                int updatedx = RobotStatus.GetUpdatedX(_facingDirection, _x);
                int updatedy = RobotStatus.GetUpdatedY(_facingDirection, _y);
                if (RobotStatus.IsOnTable(updatedx, updatedy,Instruction.Move))
                {
                    _x = updatedx;
                    _y = updatedy;
                    return true;
                }
                else
                {
                    _error = RobotStatus._error;
                }
            }
            else
            {
                _error = RobotStatus._error;
            }
            
            return false;
        }

        /// <summary>
        /// Rotate the Robot to the Left
        /// </summary>
        /// <returns>bool</returns>
        public bool Left()
        {
            if (RobotStatus.IsPlacedOnTable(_x, _y,Instruction.Left))
            {

                _facingDirection = RobotStatus.GetFacingDirection(RotateDirection.Left, _facingDirection);
                return true;
            }
            else
            {
                _error = RobotStatus._error;
            }
            return false;
        }

        /// <summary>
        /// Rotate the Robot to the right
        /// </summary>
        /// <returns>bool</returns>
        public bool Right()
        {
            if (RobotStatus.IsPlacedOnTable(_x, _y,Instruction.Right))
            {
                _facingDirection = RobotStatus.GetFacingDirection(RotateDirection.Right, _facingDirection);
                return true;
            }
            else
            {
                _error = RobotStatus._error;
            }
            return false;
        }

        /// <summary>
        /// Generate Report of the Robot position
        /// </summary>
        /// <returns>string</returns>
        public string Report()
        {
            if (RobotStatus.IsPlacedOnTable(_x, _y,Instruction.Report))
            {
                return String.Format("{0},{1},{2}", _x.Value, _y.Value, _facingDirection.ToString().ToUpper());
            }
            else
            {
                _error = RobotStatus._error;
            }
            return _error;
        }
    }
}
