using BallSystem.Data;
using Extensions;
using UnityEngine;
using Zenject;

namespace RingSystem
{
    public abstract class Ring : MonoBehaviour
    {
        private CollisionConfig _collisionConfig;

        [Inject]
        private void Init(CollisionConfig collisionConfig)
        {
            _collisionConfig = collisionConfig;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_collisionConfig.BallLayer.Contains(col.gameObject.layer))
            {
                Pass(col.transform);
            }
        }

        protected virtual void Pass(Transform passer)
        {
            DestroyRing();
        }

        protected void DestroyRing()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}