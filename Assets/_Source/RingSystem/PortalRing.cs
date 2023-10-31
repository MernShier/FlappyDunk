using Extensions;
using UnityEngine;

namespace RingSystem
{
    public class PortalRing : Ring
    {
        [SerializeField] private PortalRing tpRing;
        
        protected override void Pass(Transform passer)
        {
            passer.gameObject.transform.position = tpRing.transform.position;
            tpRing.DestroyRing();
            
            base.Pass(passer);
        }
    }
}