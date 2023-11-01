using System;
using BallSystem;
using BallSystem.Data;
using UnityEngine;
using Utils.Extensions;
using Zenject;

namespace Collectibles
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
                PickUp(col.transform);
            }
        }

        protected virtual void PickUp(Transform collector)
        {
            gameObject.SetActive(false);
        }
    }
}