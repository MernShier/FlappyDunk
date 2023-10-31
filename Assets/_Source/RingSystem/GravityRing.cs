using BallSystem;
using Extensions;
using UnityEngine;
using Zenject;

namespace RingSystem
{
    public class GravityRing : Ring
    {
        [Inject] private Ball _ball;

        protected override void Pass(Transform passer)
        {
            _ball.ChangeGravity();

            base.Pass(passer);
        }
    }
}