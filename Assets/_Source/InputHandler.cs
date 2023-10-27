using BallSystem;
using UnityEngine;
using Zenject;

public class InputHandler : MonoBehaviour
{
    [Inject] private Ball _ball;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            _ball.MoveUp();
        }
    }
}