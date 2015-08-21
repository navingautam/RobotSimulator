using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Enums
{
    public enum FacingDirection
    {
        North = 1,
        East,
        South,
        West
    }

    public enum RotateDirection
    {
        Left=-1,
        Right = 1
    }

    public enum Instruction
    {
        Invalid = 0,
        Place,
        Move,
        Left,
        Right,
        Report
    }

}
