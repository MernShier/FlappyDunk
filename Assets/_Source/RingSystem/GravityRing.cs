using BallSystem;
using UnityEngine;
using Zenject;

namespace RingSystem
{
    public class GravityRing : Ring
    {
        private Ball _ball;
        
        [Inject]
        private void Construct(Ball ball)
        {
            _ball = ball;
        }

        protected override void Pass(Collider2D passer)
        {
            _ball.ChangeGravity();

            base.Pass(passer);
        }
    }
}