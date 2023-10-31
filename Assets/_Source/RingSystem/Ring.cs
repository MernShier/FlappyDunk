using BallSystem.Data;
using Extensions;
using UnityEngine;
using Zenject;

namespace RingSystem
{
    public abstract class Ring : MonoBehaviour
    {
        [Inject] protected CollisionConfig CollisionConfig;
        
        protected void OnTriggerEnter2D(Collider2D col)
        {
            if (CollisionConfig.BallLayer.Contains(col.gameObject.layer))
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