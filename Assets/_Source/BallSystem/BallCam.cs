using System;
using UnityEngine;
using Zenject;

namespace BallSystem
{
    public class BallCam : MonoBehaviour
    {
        [Inject] private Ball _ball;
        private float _baseBallPositionX;

        private void Start()
        {
            _baseBallPositionX = _ball.transform.position.x;
        }

        private void Update()
        {
            transform.position = new Vector3(_ball.transform.position.x - _baseBallPositionX, transform.position.y,
                transform.position.z);
        }
    }
}