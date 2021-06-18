using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Tests
{
    public class RoverTestParameter
    {
        public Plateau Plateau { get; set; }
        public string Expected { get; set; }
        public IEnumerable<RoverParameter> RoverParameters { get; set; }
    }

    public class RoverParameter
    {
        public string Case { get; set; }
        public Direction Direction { get; set; }
        public Point StartPosition { get; set; }
    }
}