using BallSystem.Data;
using Extensions;
using UnityEngine;

namespace RingSystem
{
    public abstract class Ring : MonoBehaviour
    {
        [SerializeField] protected CollisionConfig collisionConfig;
        [SerializeField] protected GameObject ringBottom;
        protected virtual void OnTriggerEnter2D(Collider2D col)
        {
            if (collisionConfig.BallLayer.Contains(col.gameObject.layer))
            {
                DestroyRing();
            }
        }

        protected void DestroyRing()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}