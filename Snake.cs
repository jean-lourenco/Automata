namespace Snaker;

public readonly record struct Point(float X, float Y);
public enum Direction { Up, Right, Down, Left, };

public class Snake
{
    public Direction Direction { get; }
    public int Velocity { get; }
    public LinkedList<Point> Body { get; }
    public Point Head => Body.Last!.Value;
    public int BlockSize = 10;

    public Snake(int initialVelocity)
    {
        Body = new LinkedList<Point>(new[] { new Point(0, 0), new Point(1 * BlockSize, 0), new Point(2 * BlockSize, 0) });
        Direction = Direction.Right;
        Velocity = initialVelocity;
    }

    public void Move(int deltaTime)
    {

    }
}