using Xunit;
using System.Drawing;
using System.Collections.Generic;

namespace MarsRover.Tests
{
    public class RoverTestTheoryData : TheoryData<RoverTestParameter>
    {
        public RoverTestTheoryData()
        {
            Add(new RoverTestParameter
            {
                Plateau = new MarsPlateau(new Point(5, 5)),
                RoverParameters = new List<RoverParameter>()
                {
                    new RoverParameter
                    {
                        Case = "LMLMLMLMM",
                        Direction = Direction.North,
                        StartPosition = new Point(1, 2),
                    },
                    new RoverParameter
                    {
                        Case = "MMRMMRMRRM",
                        Direction = Direction.East,
                        StartPosition = new Point(3, 3),
                    }
                },
                Expected = "1 3 North\r\n5 1 East\r\n"
            });
        }
    }
}