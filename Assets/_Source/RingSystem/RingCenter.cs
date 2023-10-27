using Extensions;
using UnityEngine;

namespace RingSystem
{
    public class RingCenter : MonoBehaviour
    {
        [SerializeField] private LayerMask ballLayer;
        [SerializeField] private GameObject ringBottom;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (ballLayer.Contains(col.gameObject.layer))
            {
                DestroyRing();
            }
        }

        private void DestroyRing()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}