using BallSystem;
using UnityEngine;
using Zenject;

namespace CollectiblesSystem
{
    public class ScoreMultiplier : Collectible
    {
        [SerializeField] private float duration;
        [SerializeField] private float multiplier;
        private Ball _ball;

        [Inject]
        private void Construct(Ball ball)
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
