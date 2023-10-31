using BallSystem;
using UnityEngine;
using Zenject;

public class InputHandler : MonoBehaviour
{
    private Ball _ball;

    [Inject]
    private void Init(Ball ball)
    {
        _ball = ball;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) || 
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            _ball.MoveUp();
        }
    }
}