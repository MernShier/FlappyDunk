using BallSystem;
using Extensions;
using UnityEngine;
using Zenject;

namespace RingSystem
{
    public class MirrorRing : Ring
    {
        [Inject] private BallCam _ballCam;
        
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (collisionConfig.BallLayer.Contains(col.gameObject.layer))
            {
                _ballCam.transform.rotation = _ballCam.transform.rotation.z == 0 ? new Quaternion(0f, 0f, 180f,0) 
                    : new Quaternion().normalized;
            }
            base.OnTriggerEnter2D(col);
        }
    }
}