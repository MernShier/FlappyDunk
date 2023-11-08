using UnityEngine;

namespace RingSystem
{
    public class PortalRing : Ring
    {
        [SerializeField] private Ring tpRing;

        protected override void Pass(Collider2D passer)
        {
            passer.transform.position = tpRing.transform.position;
            tpRing.DestroyRing();
            
            base.Pass(passer);
        }
    }
}