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
    private Vector _leftPaddleDirection;
    private Vector _rightPaddlePosition;
    private Vector _rightPaddleDirection;

    private int _leftPaddleScore;
    private int _rightPaddleScore;

    private bool GameOver => _leftPaddleScore == 10 || _rightPaddleScore == 10;

    public Game(ConsoleRenderer renderer)
    {
        _renderer = renderer;
        _topArea = renderer.top;
        _leftArea = renderer.left;
        _bottomArea = _renderer.height - 1;
        _rightArea = _renderer.width - 1;

        _ballPosition = _renderer.Center;
        _ballDirection = new Vector
        {
            x = Random.Shared.NextDouble() > 0.5 ? 1 : -1,
            y = Random.Shared.NextDouble() > 0.5 ? 1 : -1
        };

        _leftPaddlePosition = new Vector
        {
            x = PaddlesHorizontalOffset,
            y = _renderer.Center.y - PaddlesVerticalHeight / 2
        };
        _leftPaddleDirection = Vector.Zero;

        _rightPaddlePosition = new Vector
        {
            x = _renderer.width - PaddlesHorizontalOffset,
            y = _renderer.Center.y - PaddlesVerticalHeight / 2
        };
        _rightPaddleDirection = Vector.Zero;

        _leftPaddleScore = _rightPaddleScore = 0;
    }

    public void Start()
    {

    }

    public void Update()
    {
        while (!GameOver)
        {
            _renderer.Clear();
            UpdateBall();

            UpdateRightPaddle();
            DrawEverything();
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
        // Check collision with paddles
        var xCol = _ballPosition.x == _leftPaddlePosition.x + 1 && _ballPosition.y >= _leftPaddlePosition.y && _ballPosition.y < _leftPaddlePosition.y + PaddlesVerticalHeight;
        var yCol = _ballPosition.x == _rightPaddlePosition.x - 1 && _ballPosition.y >= _rightPaddlePosition.y && _ballPosition.y < _rightPaddlePosition.y + PaddlesVerticalHeight;
        if (xCol || yCol)
        {
            _ballDirection.x *= -1;
            OnCollision?.Invoke();
        }

        if (_ballPosition.x == _leftArea)
        {
            _rightPaddleScore++;
            ResetBall();
        }
        if (_ballPosition.x == _rightArea)
        {
            _leftPaddleScore++;
            ResetBall();
        }
    }

    private void UpdateRightPaddle()
    {
        if (_ballPosition.y > _rightPaddlePosition.y + PaddlesVerticalHeight / 2)
            _rightPaddleDirection.y = 1;
        else if (_ballPosition.y < _rightPaddlePosition.y + PaddlesVerticalHeight / 2)
            _rightPaddleDirection.y = -1;
        else
            _rightPaddleDirection.y = 0;

        _rightPaddlePosition += _rightPaddleDirection;
        if (_rightPaddlePosition.y < _topArea)
        {
            _rightPaddlePosition.y = _topArea;
        }
        if (_rightPaddlePosition.y + PaddlesVerticalHeight > _bottomArea)
        {
            _rightPaddlePosition.y = _bottomArea - PaddlesVerticalHeight;
        }
    }

    private void ResetBall()
    {
        _renderer.DrawPaddle(_leftPaddlePosition, PaddlesVerticalHeight);
        _renderer.DrawPaddle(_rightPaddlePosition, PaddlesVerticalHeight);
        _renderer.DrawScore(_leftPaddleScore, _rightPaddleScore);
        Thread.Sleep(500);
        _ballPosition = _renderer.Center;
        _ballDirection = new Vector
        {
            x = Random.Shared.NextDouble() > 0.5 ? 1 : -1,
            y = Random.Shared.NextDouble() > 0.5 ? 1 : -1
        };
    }

    private void DrawEverything()
    {
        _renderer.DrawBall(_ballPosition);
        _renderer.DrawPaddle(_leftPaddlePosition, PaddlesVerticalHeight);
        _renderer.DrawPaddle(_rightPaddlePosition, PaddlesVerticalHeight);
        _renderer.DrawScore(_leftPaddleScore, _rightPaddleScore);
    }
}
