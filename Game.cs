namespace Pong;

public class Game
{
    public event Action? OnCollision;

    private const int FrameDuration = 16;
    private const int PaddlesHorizontalOffset = 4;
    private const int PaddlesVerticalHeight = 6;

    private readonly ConsoleRenderer _renderer;
    private readonly int _topArea;
    private readonly int _leftArea;
    private readonly int _bottomArea;
    private readonly int _rightArea;

    private Vector _ballPosition;
    private Vector _ballDirection;

    private Vector _leftPaddlePosition;
    private Vector _rightPaddlePosition;

    private int _leftPaddleScore;
    private int _rightPaddleScore;

    public Game(ConsoleRenderer renderer)
    {
        _renderer = renderer;
        _topArea = 0;
        _leftArea = 0;
        _bottomArea = _renderer.height - 1;
        _rightArea = _renderer.width - 1;

        ResetBall();

        _leftPaddlePosition = new Vector
        {
            x = PaddlesHorizontalOffset,
            y = _renderer.Center.y - PaddlesVerticalHeight / 2
        };
        _rightPaddlePosition = new Vector
        {
            x = _renderer.width - PaddlesHorizontalOffset,
            y = _renderer.Center.y - PaddlesVerticalHeight / 2
        };

        _leftPaddleScore = _rightPaddleScore = 0;
    }

    public void Start()
    {
        _renderer.DrawBall(_ballPosition);
        _renderer.DrawPaddle(_leftPaddlePosition, PaddlesVerticalHeight);
        _renderer.DrawPaddle(_rightPaddlePosition, PaddlesVerticalHeight);
        _renderer.DrawScore(_leftPaddleScore, _rightPaddleScore);
    }

    public void Update()
    {
        while (true)
        {
            _renderer.Clear();
            UpdateBall();

            Thread.Sleep(FrameDuration);
        }
    }

    private void UpdateBall()
    {
        _ballPosition += _ballDirection;
        if (_ballPosition.y == _topArea || _ballPosition.y == _bottomArea)
        {
            _ballDirection.y *= -1;
            OnCollision?.Invoke();
        }

        if (_ballPosition.x == _leftArea || _ballPosition.x == _rightArea)
        {
            _ballDirection.x *= -1;
            OnCollision?.Invoke();
        }

        _renderer.DrawBall(_ballPosition);
    }

    private void ResetBall()
    {
        _ballPosition = _renderer.Center;
        _ballDirection = new Vector
        {
            x = Random.Shared.NextDouble() > 0.5 ? 1 : -1,
            y = Random.Shared.NextDouble() > 0.5 ? 1 : -1
        };
    }
}
