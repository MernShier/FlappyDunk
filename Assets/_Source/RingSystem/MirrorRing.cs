using BallSystem;
using UnityEngine;
using Zenject;

namespace RingSystem
{
    public class MirrorRing : Ring
    {
        private BallCam _ballCam;
        
        [Inject]
        private void Construct(BallCam ballCam)
        {
            _ballCam = ballCam;
        }
        
        protected override void Pass(Collider2D passer)
        {
            _ballCam.transform.rotation = _ballCam.transform.rotation.z == 0 ? new Quaternion(0f, 0f, 180f,0) 
                : new Quaternion().normalized;
            
            base.Pass(passer);
        }
    }
}