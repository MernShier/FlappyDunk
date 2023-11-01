using System;
using UnityEngine;
using Zenject;

namespace BallSystem
{
    public class BallCam : MonoBehaviour
    {
        private Ball _ball;
        private float _baseBallPositionX;
        private float _baseCamPositionX;

        [Inject]
        private void Construct(Ball ball)
        {
            _ball = ball;
        }
        
        private void Start()
        {
            _baseBallPositionX = _ball.transform.position.x;
            _baseCamPositionX = transform.position.x;
        }

        private void Update()
        {
            transform.position = new Vector3(_baseCamPositionX + _ball.transform.position.x - _baseBallPositionX, transform.position.y,
                transform.position.z);
        }
    }
}