using Xunit;
using System.Text;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        [Theory, ClassData(typeof(RoverTestTheoryData))]
        public void GetRoverPosition_ShouldAssertTrue_WhenPassedCorrectCommand(RoverTestParameter parameter)
        {
            var commandStringBuilder = new StringBuilder();
            foreach (var rover in parameter.RoverParameters)
            {
                MarsRover marsRover = new(rover.StartPosition, parameter.Plateau, rover.Direction);
                marsRover.StartEngine(rover.Case);
                var result = marsRover.GetCurrentPosition();
                commandStringBuilder.AppendLine(result);
            }
            Assert.Equal(parameter.Expected, commandStringBuilder.ToString());
        }
    }
}