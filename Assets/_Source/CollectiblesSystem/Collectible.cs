using Collision.Data;
using UnityEngine;
using Utils.Extensions;
using Zenject;

namespace CollectiblesSystem
{
    public abstract class Collectible : MonoBehaviour
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
                PickUp(col);
            }
        }

        protected virtual void PickUp(Collider2D collector)
        {
            gameObject.SetActive(false);
        }
    }
}