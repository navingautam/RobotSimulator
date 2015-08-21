using RobotSimulator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    public class RobotDriver
    {
        public RobotDriver(RobotInstructions robotInstructions)
        {
            this._robotInstructions = robotInstructions;
        }

        public RobotInstructions _robotInstructions { get; set; }

        /// <summary>
        /// Get command from the client and invokes correct instructions to the robot
        /// </summary>
        /// <param name="command"></param>
        /// <returns>string</returns>
        public string Command(string command)
        {
            string response = "";
            RobotPosition args = null;
            var instruction = GetInstruction(command, ref args);

            if(instruction==Instruction.Place)
            {
                var placeArgs = (RobotPosition)args;
                if (_robotInstructions.Place(placeArgs.X, placeArgs.Y, placeArgs.FacingDirection))
                {
                    response = "Robot placed on the table.";
                }
                else
                {
                    response = _robotInstructions._error;
                }
            }

            else if(instruction==Instruction.Move)
            {
                if (_robotInstructions.Move())
                {
                    response = "Robot Moved.";
                }
                else
                {
                    response = _robotInstructions._error;
                }
            }

            else if(instruction == Instruction.Left)
            {
                if (_robotInstructions.Left())
                {
                    response = "Robot rotated to the left.";
                }
                else
                {
                    response = _robotInstructions._error;
                }
            }

            else if(instruction==Instruction.Right)
            {
                if (_robotInstructions.Right())
                {
                    response = "Robot rotated to the Right.";
                }
                else
                {
                    response = _robotInstructions._error;
                }
            }

            else if(instruction==Instruction.Report)
            {
                response = _robotInstructions.Report() + "\n";
            }

            else
            {
                response = "Invalid command.";
            }
            
            return response;            
        }

        /// <summary>
        /// Separate the instructions and arguments from the send argument strings
        /// </summary>
        /// <param name="command"></param>
        /// <param name="args"></param>
        /// <returns>string</returns>
        public Instruction GetInstruction(string command, ref RobotPosition args)
        {
            Instruction instruction;
            string arguments = "";

            string[] separatearguments = command.Split(' ');
            if(separatearguments.Length>1)
            {
                command = separatearguments[0];
                arguments = separatearguments[1];
            }
            command = command.ToUpper();

            if (Enum.TryParse<Instruction>(command, true, out instruction))
            {
                if (instruction == Instruction.Place)
                {
                    if (!ParsePlaceArguments(arguments, ref args))
                    {
                        instruction = Instruction.Invalid;
                    }
                }
            }
            else
            {
                instruction = Instruction.Invalid;
            }
            return instruction;
        }
        /// <summary>
        /// Parse arguments received with Place Instruction
        /// </summary>
        /// <param name="argumentString"></param>
        /// <param name="args"></param>
        /// <returns>bool</returns>
        private bool ParsePlaceArguments(string argumentString, ref RobotPosition args)
        {
            var arguments = argumentString.Split(','); 
            int x, y;
            FacingDirection facingdirection;

            if (arguments.Length == 3 && GetCoordinate(arguments[0], out x) &&
                GetCoordinate(arguments[1], out y) && GetFacingDirection(arguments[2], out facingdirection))
            {
                args = new RobotPosition
                {
                    X = x,
                    Y = y,
                    FacingDirection = facingdirection,
                };
                return true;
            }
            return false;            
        }

        private bool GetCoordinate(string coordinate, out int coordinateValue)
        {
            return int.TryParse(coordinate, out coordinateValue);
        }

        private bool GetFacingDirection(string direction, out FacingDirection facingdirection)
        {
            return Enum.TryParse<FacingDirection>(direction, true, out facingdirection);
        }
    }    
}
