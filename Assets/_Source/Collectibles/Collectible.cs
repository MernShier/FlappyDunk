using System;
using BallSystem;
using BallSystem.Data;
using Extensions;
using UnityEngine;
using Zenject;

namespace Collectibles
{
    public abstract class Collectible : MonoBehaviour
    {
        [Inject] protected CollisionConfig CollisionConfig;

        protected void OnTriggerEnter2D(Collider2D col)
        {
            if (CollisionConfig.BallLayer.Contains(col.gameObject.layer))
            {
                PickUp(col.transform);
            }
        }

        protected virtual void PickUp(Transform collector)
        {
            Destroy(gameObject);
        }
    }
}