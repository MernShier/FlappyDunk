using BallSystem;
using UnityEngine;
using Zenject;

namespace Collectibles
{
    public class ScoreMultiplier : Collectible
    {
        [SerializeField] private float duration;
        [SerializeField] private float multiplier;
        [Inject] private Ball _ball;
        
        protected override void PickUp(Transform collector)
        {
            _ball.StartMultiplyScore(duration, multiplier);
            base.PickUp(collector);
        }
    }
}
