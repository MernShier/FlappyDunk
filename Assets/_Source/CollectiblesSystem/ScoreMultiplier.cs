using ScoreSystem;
using UnityEngine;
using Zenject;

namespace CollectiblesSystem
{
    public class ScoreMultiplier : Collectible
    {
        [SerializeField] private float duration;
        [SerializeField] private float multiplier;
        private RingScore _ringScore;

        [Inject]
        private void Construct(RingScore ringScore)
        {
            _ringScore = ringScore;
        }
        
        protected override void PickUp(Transform collector)
        {
            _ringScore.StartMultiplyScore(duration, multiplier);
            base.PickUp(collector);
        }
    }
}