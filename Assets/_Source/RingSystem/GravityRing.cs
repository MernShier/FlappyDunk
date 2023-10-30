using BallSystem;
using Extensions;
using UnityEngine;
using Zenject;

namespace RingSystem
{
    public class GravityRing : Ring
    {
        [Inject] private Ball _ball;
        
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (collisionConfig.BallLayer.Contains(col.gameObject.layer))
            {
                _ball.ChangeGravity();
            }
            base.OnTriggerEnter2D(col);
        }
    }
}