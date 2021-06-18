using System.Drawing;

namespace MarsRover
{
    public abstract class Plateau
    {
        public abstract Point Border { get; protected set; }
    }

    public class MarsPlateau : Plateau
    {
        public override Point Border { get; protected set; }

        public MarsPlateau(Point border)
        {
            Border = border;
        }
    }
}