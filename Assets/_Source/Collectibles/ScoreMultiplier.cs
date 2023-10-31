using BallSystem;
using BallSystem.Data;
using UnityEngine;
using Zenject;

namespace Collectibles
{
    public class ScoreMultiplier : Collectible
    {
        [SerializeField] private float duration;
        [SerializeField] private float multiplier;
        private Ball _ball;

        [Inject]
        private void Init(Ball ball)
        {
            _ball = ball;
        }
        
        protected override void PickUp(Transform collector)
        {
            _ball.StartMultiplyScore(duration, multiplier);
            base.PickUp(collector);
        }
    }
}
