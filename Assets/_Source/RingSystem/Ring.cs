using BallSystem.Data;
using UnityEngine;
using Utils.Extensions;
using Zenject;

namespace RingSystem
{
    public abstract class Ring : MonoBehaviour
    {
        private CollisionConfig _collisionConfig;

        [Inject]
        private void Construct(CollisionConfig collisionConfig)
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
            transform.parent.gameObject.SetActive(false);
        }
    }
}