using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarsRover
{
    //INFO: Coordinate system was used to determine direction.
    public enum Direction
    {
        East = 0,
        North = 90,
        West = 180,
        South = 270
    }

    public interface IRover
    {
        string GetCurrentPosition();
        void StartEngine(string commands);
    }

    public class MarsRover : IRover
    {
        public Direction _direction;
        private Point _roverPosition;
        private readonly Plateau _plateau;

        private readonly IDictionary<string, Action> movementMethodDictionary;
        private readonly IDictionary<Direction, Action> forwardMoveDictionary;

        public MarsRover(Point startPosition, Plateau plateau, Direction direction)
        {
            _plateau = plateau;
            _direction = direction;
            _roverPosition = startPosition;

            movementMethodDictionary = new Dictionary<string, Action>()
            {
                { "L", () => TurnLeft() },
                { "R", () => TurnRight() },
                { "M", () => Move() }
            };

            forwardMoveDictionary = new Dictionary<Direction, Action>
            {
                { Direction.North, () => {_roverPosition = new Point(_roverPosition.X, _roverPosition.Y + 1);} },
                { Direction.East, () => {_roverPosition = new Point(_roverPosition.X + 1, _roverPosition.Y);} },
                { Direction.South, () => {_roverPosition = new Point(_roverPosition.X, _roverPosition.Y - 1);} },
                { Direction.West, () => {_roverPosition = new Point(_roverPosition.X - 1, _roverPosition.Y);} }
            };
        }

        public void StartEngine(string commands)
        {
            if (!CommandValidator(commands))
            {
                throw new Exception("Inccorect format. Please enter only L-R-M keys");
            }

            foreach (var command in commands)
            {
                movementMethodDictionary[command.ToString()].Invoke();

                if (_roverPosition.X > _plateau.Border.X || _roverPosition.Y > _plateau.Border.Y)
                {
                    throw new Exception("Rover crossed planetary boundary!");
                }
            }
        }

        private void Move()
        {
            forwardMoveDictionary[_direction].Invoke();
        }

        private void TurnLeft()
        {
            var newDirection = (int)_direction + 90;
            _direction = newDirection.Equals(360) ? 0 : (Direction)newDirection;
        }

        private void TurnRight()
        {
            var newDirection = (int)_direction - 90;
            _direction = newDirection.Equals(-90) ? (Direction)270 : (Direction)newDirection;
        }

        public string GetCurrentPosition()
        {
            return string.Format("{0} {1} {2}", _roverPosition.X, _roverPosition.Y, _direction);
        }

        private static bool CommandValidator(string commands)
        {
            if (string.IsNullOrWhiteSpace(commands))
            {
                return false;
            }
            else if (!Regex.IsMatch(commands, "^([LRM]|[lrm])+$"))
            {
                return false;
            }
            return true;
        }
    }
}