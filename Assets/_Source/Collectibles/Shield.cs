using BallSystem;
using UnityEngine;
using Zenject;

namespace Collectibles
{
    public class Shield : Collectible
    {
        [SerializeField] private int value;
        [Inject] private BallShield _ballShield;
        
        protected override void PickUp(Transform collector)
        {
            _ballShield.AddShield(value);
            base.PickUp(collector);
        }
    }
}