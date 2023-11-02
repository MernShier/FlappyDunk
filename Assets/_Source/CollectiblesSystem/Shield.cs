using BallSystem;
using UnityEngine;
using Zenject;

namespace CollectiblesSystem
{
    public class Shield : Collectible
    {
        [SerializeField] private int value;
        private BallShield _ballShield;

        [Inject]
        private void Construct(BallShield ballShield)
        {
            _ballShield = ballShield;
        }
        
        protected override void PickUp(Transform collector)
        {
            _ballShield.AddShield(value);
            base.PickUp(collector);
        }
    }
}