using Extensions;
using UnityEngine;

namespace RingSystem
{
    public class PortalRing : Ring
    {
        [SerializeField] private PortalRing tpRing;

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (collisionConfig.BallLayer.Contains(col.gameObject.layer))
            {
                col.gameObject.transform.position = tpRing.transform.position;
            }

            tpRing.DestroyRing();
            base.OnTriggerEnter2D(col);
        }
    }
}